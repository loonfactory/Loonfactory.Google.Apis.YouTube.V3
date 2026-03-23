// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Watermarks;

/// <summary>
/// Defines a contract for setting and unsetting channel watermarks.
/// </summary>
public interface IWatermarkService
{
    /// <summary>
    /// Sets a channel watermark using JSON payload metadata that includes image bytes.
    /// </summary>
    /// <param name="channelId">The YouTube channel ID for which the watermark is being provided.</param>
    /// <param name="resource">The watermark metadata resource. <see cref="WatermarkResource.ImageBytes"/> must be set.</param>
    /// <param name="onBehalfOfContentOwner">Indicates that the authenticated CMS user is acting on behalf of the specified content owner.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    Task SetAsync(
        string channelId,
        WatermarkResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a watermark image and applies it to the specified channel.
    /// </summary>
    /// <inheritdoc cref="SetAsync(string, WatermarkResource, Stream, string, string?, CancellationToken)" />
    Task SetAsync(
        string channelId,
        WatermarkResource resource,
        Stream stream,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a watermark image and applies it to the specified channel.
    /// </summary>
    /// <remarks>
    /// <para>This method supports media upload. Uploaded files must conform to these constraints:</para>
    /// <list type="bullet">
    ///   <item>
    ///     <description>
    ///       <b>Accepted media MIME types:</b>
    ///       <c>image/jpeg</c>, <c>image/png</c>, <c>application/octet-stream</c>
    ///     </description>
    ///   </item>
    /// </list>
    /// </remarks>
    /// <param name="channelId">
    /// The YouTube channel ID for which the watermark is being provided.
    /// </param>
    /// <param name="resource">
    /// The watermark metadata resource.
    /// </param>
    /// <param name="stream">
    /// The watermark image stream content to upload.
    /// </param>
    /// <param name="contentType">
    /// The MIME type of the upload payload.
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// Indicates that the authenticated CMS user is acting on behalf of the specified content owner.
    /// </param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests.
    /// </param>
    Task SetAsync(
        string channelId,
        WatermarkResource resource,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the watermark image for the specified channel.
    /// </summary>
    /// <param name="channelId">
    /// The YouTube channel ID for which the watermark should be removed.
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// Indicates that the authenticated CMS user is acting on behalf of the specified content owner.
    /// </param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests.
    /// </param>
    Task UnsetAsync(
        string channelId,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);
}
