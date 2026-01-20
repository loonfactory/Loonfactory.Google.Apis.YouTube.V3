// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// A thumbnail resource identifies different thumbnail image sizes associated with a resource.
/// </summary>
public interface IThumbnailService
{
    /// <param name="stream">
    /// <para>The thumbnail stream content to upload. The upload payload content type is <c>application/octet-stream</c>.</para>
    /// </param>
    /// <inheritdoc cref="SetAsync(string, Stream, string, string?, CancellationToken)" />
    Task<ThumbnailSetResponse> SetAsync(
        string videoId,
        Stream stream,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a custom video thumbnail to YouTube and sets it for a video.
    /// </summary>
    /// <remarks>
    /// <para>This method supports media upload. Uploaded files must conform to these constraints:</para>
    /// <list type="bullet">
    ///   <item>
    ///     <description><b>Maximum file size:</b> 2MB</description>
    ///   </item>
    ///   <item>
    ///     <description>
    ///       <b>Accepted media MIME types:</b>
    ///       <c>image/jpeg</c>, <c>image/png</c>, <c>application/octet-stream</c>
    ///     </description>
    ///   </item>
    /// </list>    
    /// </remarks>
    /// <param name="videoId">
    /// The <paramref name="videoId"/> specifies a YouTube video ID for which the custom video thumbnail is being provided.
    /// </param>
    /// <param name="stream">
    /// <para>The thumbnail stream content to upload.</para>
    /// </param>
    /// <param name="contentType">
    /// <para>The <paramref name="contentType"/> specifies the MIME type of the upload payload.</para>
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// The <paramref name="onBehalfOfContentOwner"/> parameter indicates that the request's authorization credentials identify a YouTube CMS user
    /// who is acting on behalf of the content owner specified in the parameter value.
    /// This parameter is intended for YouTube content partners that own and manage many different YouTube channels.
    /// It allows content owners to authenticate once and get access to all their video and channel data,
    /// without having to provide authentication credentials for each individual channel.
    /// The actual CMS account that the user authenticates with must be linked to the specified YouTube content owner.
    /// </param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests. The default value is None.    
    /// </param>
    /// <returns>The thumbnail set response.</returns>
    Task<ThumbnailSetResponse> SetAsync(
        string videoId,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);
}
