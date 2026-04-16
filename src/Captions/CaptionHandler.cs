// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Provides functionality to handle YouTube caption operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of <see cref="CaptionHandler" />.
/// </remarks>
/// <param name="options">The monitor for the options instance.</param>
/// <param name="logger">The <see cref="ILoggerFactory"/>.</param>
public class CaptionHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), ICaptionHandler
{
    public virtual async Task<YouTubeResult<Stream>> HandleCaptionDownloadAsync(
        CaptionProperties properties,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The caption id must be provided in the properties.");
        }

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("The part parameter must be provided in the properties.");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Get,
            $"{CaptionDefaults.DownloadEndpoint}{properties.Id}",
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return await HandleResponseAsync<Stream>(response, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously handles the deletion of a YouTube caption.
    /// </summary>
    /// <param name="properties">The <see cref="CaptionProperties"/> required for caption deletion.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="properties"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when required properties are missing or invalid.</exception>
    public virtual Task<YouTubeResult> HandleCaptionDeleteAsync(
        CaptionProperties properties,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The caption id must be provided in the properties.");
        }

        return AuthorizationExecuteAsync(
            HttpMethod.Delete,
            CaptionDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<CaptionListResponse>> HandleCaptionListAsync(
        CaptionProperties properties,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.VideoId))
        {
            throw new InvalidOperationException("The videoId must be provided in the properties.");
        }

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("The part parameter must be provided in the properties.");
        }

        return AuthorizationExecuteAsync<CaptionListResponse>(
            HttpMethod.Get,
            CaptionDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<CaptionResource>> HandleCaptionInsertAsync(
        CaptionResource resource,
        StreamContent? content,
        CaptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("The part parameter must be provided in the properties.");
        }

        if (string.IsNullOrEmpty(resource.Snippet?.VideoId))
        {
            throw new InvalidOperationException("The snippet.videoId must be provided in the resource.");
        }

        if (string.IsNullOrEmpty(resource.Snippet?.Language))
        {
            throw new InvalidOperationException("The snippet.language must be provided in the resource.");
        }

        if (string.IsNullOrEmpty(resource.Snippet?.Name))
        {
            throw new InvalidOperationException("The snippet.name must be provided in the resource.");
        }

        var endpoint = BuildChallengeUrl(CaptionDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return UploadAsync(
            request,
            resource,
            content,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<CaptionResource>> HandleCaptionUpdateAsync(
        CaptionResource resource,
        StreamContent? content,
        CaptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("The part parameter must be provided in the properties.");
        }

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The caption id must be provided in the resource.");
        }

        var endpoint = BuildChallengeUrl(CaptionDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return UploadAsync(
            request,
            resource,
            content,
            properties,
            cancellationToken
        );
    }
}