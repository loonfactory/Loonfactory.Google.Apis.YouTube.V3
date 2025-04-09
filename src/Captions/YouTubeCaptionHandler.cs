// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Provides functionality to handle YouTube caption operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of <see cref="YouTubeCaptionHandler" />.
/// </remarks>
/// <param name="options">The monitor for the options instance.</param>
/// <param name="logger">The <see cref="ILoggerFactory"/>.</param>
/// <param name="encoder">The <see cref="UrlEncoder"/>.</param>
public class YouTubeCaptionHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : YouTubeHandler(options, logger, encoder), IYouTubeCaptionHandler
{
    public virtual async Task<YouTubeResult<Stream>> HandleCaptionDownloadAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("@TODO");
        }

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Get,
            $"{YouTubeCaptionDefaults.DownloadEndpoint}{properties.Id}",
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<Stream>.Success(await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false)),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }

    /// <summary>
    /// Asynchronously handles the deletion of a YouTube caption.
    /// </summary>
    /// <param name="properties">The <see cref="YouTubeCaptionProperties"/> required for caption deletion.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="properties"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when required properties are missing or invalid.</exception>
    public virtual async Task<YouTubeResult> HandleCaptionDeleteAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The caption id must be provided in the properties.");
        }

        if (string.IsNullOrEmpty(properties.AccessToken))
        {
            throw new InvalidOperationException("An access token must be provided in the properties.");
        }

        var endpoint = BuildChallengeUrl(YouTubeCaptionDefaults.DeleteEndpoint, properties);

        var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult.NoResult,
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }

    public virtual async Task<YouTubeResult<YouTubeCaptionListResource>> HandleCaptionListAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.VideoId))
        {
            throw new InvalidOperationException("@TODO");
        }

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        if (string.IsNullOrEmpty(properties.AccessToken))
        {
            throw new InvalidOperationException("An access token must be provided in the properties.");
        }

        var endpoint = BuildChallengeUrl(YouTubeCaptionDefaults.ListEndpoint, properties);

        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return YouTubeResult<YouTubeCaptionListResource>.Success(
            JsonSerializer.Deserialize<YouTubeCaptionListResource>(body, YouTubeDefaults.JsonSerializerOptions)!
        );
    }

    public virtual Task<YouTubeResult<YouTubeCaptionResource>> HandleCaptionInsertAsync(
        YouTubeCaptionResource resource,
        StreamContent? content,
        YouTubeCaptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        if (string.IsNullOrEmpty(resource.Snippet?.VideoId))
        {
            throw new InvalidOperationException("@TODO");
        }

        if (string.IsNullOrEmpty(resource.Snippet?.Language))
        {
            throw new InvalidOperationException("@TODO");
        }

        if (string.IsNullOrEmpty(resource.Snippet?.Name))
        {
            throw new InvalidOperationException("@TODO");
        }

        var endpoint = BuildChallengeUrl(YouTubeCaptionDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandleCaptionUploadAsync(request, resource, content, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<YouTubeCaptionResource>> HandleCaptionUpdateAsync(
        YouTubeCaptionResource resource,
        StreamContent? content,
        YouTubeCaptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("@TODO");
        }

        var endpoint = BuildChallengeUrl(YouTubeCaptionDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return InternalHandleCaptionUploadAsync(request, resource, content, properties, cancellationToken);
    }

    private Task<YouTubeResult<YouTubeCaptionResource>> InternalHandleCaptionUploadAsync(
        HttpRequestMessage request,
        YouTubeCaptionResource resource,
        StreamContent? content,
        YouTubeCaptionProperties properties,
        CancellationToken cancellationToken)
    {
        return UploadAsync(
            request,
            resource,
            content,
            properties,
            cancellationToken
        );
    }
}