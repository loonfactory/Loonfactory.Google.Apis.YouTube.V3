// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3;

public abstract class YouTubeHandler : IYouTubeHandler
{
    /// <summary>
    /// Gets or sets the options associated with this YouTube handler.
    /// </summary>
    public YouTubeOptions Options { get; private set; } = default!;

    /// <summary>
    /// Gets the <see cref="ILogger"/>.
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// Gets the <see cref="UrlEncoder"/>.
    /// </summary>
    protected UrlEncoder UrlEncoder { get; }

    /// <summary>
    /// Gets the current time, primarily for unit testing.
    /// </summary>
    protected TimeProvider TimeProvider { get; private set; } = TimeProvider.System;

    /// <summary>
    /// Gets the <see cref="IOptionsMonitor{TOptions}"/> to detect changes to options.
    /// </summary>
    protected IOptionsMonitor<YouTubeOptions> OptionsMonitor { get; }

    /// <summary>
    /// The handler calls methods on the events which give the application control at certain points where processing is occurring.
    /// If it is not provided a default instance is supplied which does nothing when the methods are called.
    /// </summary>
    protected virtual object? Events { get; set; }

    /// <summary>
    /// Gets the <see cref="HttpClient"/> instance used to communicate with the YouTube.
    /// </summary>
    protected HttpClient Backchannel => Options.Backchannel;

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeCaptionHandler" />.
    /// </summary>
    /// <param name="options">The monitor for the options instance.</param>
    /// <param name="logger">The <see cref="ILoggerFactory"/>.</param>
    /// <param name="encoder">The <see cref="UrlEncoder"/>.</param>
    protected YouTubeHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    {
        Logger = logger.CreateLogger(this.GetType().FullName!);
        UrlEncoder = encoder;
        OptionsMonitor = options;
    }

    /// <summary>
    /// Initialize the handler, resolve the options and validate them.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InitializeAsync()
    {
        Options = OptionsMonitor.CurrentValue;

        TimeProvider = Options.TimeProvider ?? TimeProvider.System;

        await InitializeEventsAsync().ConfigureAwait(false);
        await InitializeHandlerAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Initializes the events object, called once per request by <see cref="InitializeAsync(YouTubeScheme, HttpContext context)"/>.
    /// </summary>
    protected virtual Task InitializeEventsAsync() => Task.CompletedTask;

    /// <summary>
    /// Called after options/events have been initialized for the handler to finish initializing itself.
    /// </summary>
    /// <returns>A task</returns>
    protected virtual Task InitializeHandlerAsync() => Task.CompletedTask;

    /// <summary>
    /// Constructs the challenge url.
    /// </summary>
    /// <param name="uri">The base URI of the challenge.</param>
    /// <param name="properties">The <see cref="YouTubeProperties"/>.</param>
    /// <returns>The challenge url.</returns>
    protected virtual string BuildChallengeUrl<T>(string uri, in T properties) where T : YouTubeProperties
    {
        var parameters = properties.Parameters
            .Where(item => item.Key != YouTubeProperties.AccessTokenKey)
            .Select(item => new KeyValuePair<string, StringValues>(
                item.Key,
                item.Value is IEnumerable<object> values
                 ? values.Select(obj => obj.ToString()).ToArray()
                    : item.Value?.ToString()
            )).ToList();

        parameters.Add(new("key", Options.Key));

        return QueryHelpers.AddQueryString(uri, parameters);
    }

    protected internal virtual HttpRequestMessage CreateHttpRequestMessage(
        HttpMethod method,
        string requestUri,
        YouTubeProperties properties
    )
    {
        var endpoint = BuildChallengeUrl(requestUri, properties);
        return new HttpRequestMessage(method, endpoint);
    }

    protected internal virtual Task<HttpResponseMessage> SendAsync(
       HttpMethod method,
       string requestUri,
       YouTubeProperties properties,
       CancellationToken cancellationToken = default
    )
    {
        var request = CreateHttpRequestMessage(method, requestUri, properties);
        if (!string.IsNullOrWhiteSpace(properties.AccessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                properties.AccessToken
            );
        }

        return Backchannel.SendAsync(request, cancellationToken);
    }

    protected internal virtual Task<HttpResponseMessage> AuthorizationSendAsync(
        HttpMethod method,
        string requestUri,
        YouTubeProperties properties,
        CancellationToken cancellationToken = default
    )
    {
        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);

        return SendAsync(method, requestUri, properties, cancellationToken);
    }

    protected internal static void ThrowIfAccessTokenNullOrEmpty(string? accessToken)
    {
        if (string.IsNullOrEmpty(accessToken))
        {
            throw new InvalidOperationException("An access token must be provided in the properties.");
        }
    }

    protected virtual async Task<YouTubeResult<T>> UploadAsync<T, K>(
        HttpRequestMessage request,
        T resource,
        StreamContent? content,
        K properties,
        CancellationToken cancellationToken
    ) where T : class
      where K : YouTubeProperties
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        var jsonContent = JsonContent.Create(resource);

        if (content != null)
        {
            request.Content = new MultipartContent("related") {
                jsonContent,
                content
            };
        }
        else
        {
            request.Content = jsonContent;
        }

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<T>.Success(
                JsonSerializer.Deserialize<T>(body, YouTubeDefaults.JsonSerializerOptions)!
            ),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}