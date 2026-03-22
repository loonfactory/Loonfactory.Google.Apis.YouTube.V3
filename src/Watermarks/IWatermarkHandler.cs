// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Watermarks;

/// <summary>
/// Defines a contract for a handler of watermark operations.
/// </summary>
public interface IWatermarkHandler : IYouTubeHandler
{
    /// <summary>
    /// Handles a request to upload and set a channel watermark.
    /// </summary>
    /// <param name="resource">The watermark metadata resource.</param>
    /// <param name="stream">The watermark content to upload.</param>
    /// <param name="contentType">The MIME type of the upload payload.</param>
    /// <param name="properties">The request properties.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The operation result.</returns>
    Task<YouTubeResult> HandleSetAsync(
        WatermarkResource resource,
        Stream stream,
        string contentType,
        WatermarkProperties properties,
        CancellationToken cancellationToken);

    /// <summary>
    /// Handles a request to unset a channel watermark.
    /// </summary>
    /// <param name="properties">The request properties.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The operation result.</returns>
    Task<YouTubeResult> HandleUnsetAsync(
        WatermarkProperties properties,
        CancellationToken cancellationToken);
}
