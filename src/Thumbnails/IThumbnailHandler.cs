// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// Defines a contract for a handler of thumbnail operations.
/// </summary>
public interface IThumbnailHandler : IYouTubeHandler
{
    /// <summary>
    /// Handles a request to upload and set a custom thumbnail for a video.
    /// </summary>
    /// <param name="stream">The thumbnail content to upload.</param>
    /// <param name="contentType">The MIME type of the upload payload.</param>
    /// <param name="properties">The request properties.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
    /// <returns>The operation result.</returns>
    Task<YouTubeResult<ThumbnailSetResponse>> HandleSetAsync(
        Stream stream,
        string contentType,
        ThumbnailProperties properties,
        CancellationToken cancellationToken);
}
