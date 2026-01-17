// Licensed under the MIT license by loonfactory.

using System.Net.Mime;

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// Provides methods for uploading and setting custom thumbnails for YouTube videos.
/// </summary>
/// <remarks>
/// The service validates upload content types and delegates request execution to an <see cref="IThumbnailHandler"/>.
/// </remarks>
public class ThumbnailService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : IThumbnailService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers ?? throw new ArgumentNullException(nameof(handlers));
    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider ?? throw new ArgumentNullException(nameof(accessTokenProvider));

    /// <inheritdoc />
    public Task<ThumbnailSetResponse> SetAsync(
        string videoId,
        Stream stream,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(videoId);
        ArgumentNullException.ThrowIfNull(stream);

        return SetAsync(
            videoId,
            stream,
            MediaTypeNames.Application.Octet,
            onBehalfOfContentOwner,
            cancellationToken);
    }

    /// <inheritdoc />
    public Task<ThumbnailSetResponse> SetAsync(
        string videoId,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(videoId);
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentException.ThrowIfNullOrWhiteSpace(contentType);

        // Validate only the media type against the allow list.
        var mediaType = contentType.Split(';', 2)[0].Trim();
        if (!ThumbnailDefaults.AllowedUploadContentTypes.Contains(mediaType))
        {
            var allowed = string.Join(", ", ThumbnailDefaults.AllowedUploadContentTypes.OrderBy(x => x, StringComparer.Ordinal));
            throw new ArgumentException($"contentType must be one of: {allowed}.", nameof(contentType));
        }

        // Preserve the original value (including parameters) when sending the request.
        return InternalSetAsync(
            videoId,
            stream,
            contentType,
            onBehalfOfContentOwner,
            cancellationToken
        );
    }

    private async Task<ThumbnailSetResponse> InternalSetAsync(
       string videoId,
       Stream stream,
       string contentType,
       string? onBehalfOfContentOwner,
       CancellationToken cancellationToken
    )
    {
        var handler = await Handlers.GetHandlerAsync<IThumbnailHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("IThumbnailHandler could not be obtained.");

        var token = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(token))
        {
            // TODO: Replace with appropriate authentication exception when available
            throw new InvalidOperationException("Access token could not be obtained.");
        }

        var properties = new ThumbnailProperties
        {
            VideoId = videoId,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = token,
        };

        var result = await handler.HandleThumbnailSetAsync(stream, contentType, properties, cancellationToken)
            .ConfigureAwait(false);

        if (!result.Succeeded)
        {
            //@TODO: Implement error handling
            throw new InvalidOperationException("Thumbnail upload failed. [TODO: unify error handling]");
        }

        return result.Resource;
    }
}
