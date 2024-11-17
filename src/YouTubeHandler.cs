// Licensed under the MIT license by loonfactory.

using System.Text.Encodings.Web;
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
        var parameters = properties.Parameters.Select(item => new KeyValuePair<string, StringValues>(
            item.Key,
            item.Value is IEnumerable<object> values
                ? values.Select(obj => obj.ToString()).ToArray()
                : item.Value?.ToString()
        )).ToList();
        parameters.Add(new("key", Options.Key));

        return QueryHelpers.AddQueryString(uri, parameters);
    }
}