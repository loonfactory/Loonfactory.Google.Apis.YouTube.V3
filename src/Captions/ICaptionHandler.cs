// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Handles HTTP operations for YouTube caption tracks.
/// </summary>
public interface ICaptionHandler : IYouTubeHandler
{
    /// <summary>
    /// Sends a caption list request.
    /// </summary>
    /// <param name="properties">The request parameters and OAuth access token.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task containing the operation result.</returns>
    public Task<YouTubeResult<CaptionListResponse>> HandleCaptionListAsync(CaptionProperties properties, CancellationToken cancellationToken);
    /// <summary>
    /// Sends a caption insert request.
    /// </summary>
    /// <param name="resource">The caption metadata.</param>
    /// <param name="content">The media content, or <see langword="null"/> for a metadata-only request.</param>
    /// <param name="properties">The request parameters and OAuth access token.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task containing the operation result.</returns>
    /// <remarks>YouTube requires media content when inserting a caption.</remarks>
    public Task<YouTubeResult<CaptionResource>> HandleCaptionInsertAsync(CaptionResource resource, StreamContent? content, CaptionProperties properties, CancellationToken cancellationToken);
    /// <summary>
    /// Sends a caption update request.
    /// </summary>
    /// <param name="resource">The caption metadata.</param>
    /// <param name="content">The media content, or <see langword="null"/> for a metadata-only request.</param>
    /// <param name="properties">The request parameters and OAuth access token.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task containing the operation result.</returns>
    public Task<YouTubeResult<CaptionResource>> HandleCaptionUpdateAsync(CaptionResource resource, StreamContent? content, CaptionProperties properties, CancellationToken cancellationToken);
    /// <summary>
    /// Sends a caption download request.
    /// </summary>
    /// <param name="properties">The request parameters and OAuth access token.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task containing the operation result.</returns>
    /// <remarks>The caller must dispose the stream returned on success.</remarks>
    public Task<YouTubeResult<Stream>> HandleCaptionDownloadAsync(CaptionProperties properties, CancellationToken cancellationToken);
    /// <summary>
    /// Sends a caption delete request.
    /// </summary>
    /// <param name="properties">The request parameters and OAuth access token.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task containing the operation result.</returns>
    public Task<YouTubeResult> HandleCaptionDeleteAsync(CaptionProperties properties, CancellationToken cancellationToken);
}
