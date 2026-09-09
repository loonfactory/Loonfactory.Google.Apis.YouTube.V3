// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Provides asynchronous access to YouTube caption tracks.
/// </summary>
/// <remarks>
/// <para>Use an OAuth token authorized for <c>https://www.googleapis.com/auth/youtube.force-ssl</c>
/// or <c>https://www.googleapis.com/auth/youtubepartner</c>.</para>
/// <para>Content-owner delegation is for YouTube partners. The authenticated CMS account must
/// be linked to the specified owner; it can then manage that owner's channels without separate channel logins.</para>
/// <para>API errors include permission failures and missing resources. See each operation's reference for details.</para>
/// </remarks>
public interface ICaptionsService
{
    /// <summary>
    /// Retrieves caption metadata for a video.
    /// </summary>
    /// <remarks>The response contains metadata, not caption text. Use DownloadAsync to retrieve the caption data.</remarks>
    /// <param name="part">The resource parts to include, such as <c>id</c> or <c>snippet</c>.</param>
    /// <param name="videoId">The video identifier.</param>
    /// <param name="id">Optional comma-separated caption identifiers belonging to <paramref name="videoId"/>. <see langword="null"/> omits the filter.</param>
    /// <param name="onBehalfOfContentOwner">The content partner owner identifier, or <see langword="null"/> to omit delegation.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the caption metadata list.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/list" />
    public Task<CaptionListResponse> ListAsync(
        StringValues part,
        string videoId,
        string? id = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits a new caption track.
    /// </summary>
    /// <remarks>This overload sends metadata only. YouTube requires caption content for insertion and may return <c>contentRequired</c>. Use a stream overload to upload a track.</remarks>
    /// <param name="part">The resource parts to return; use <c>snippet</c>.</param>
    /// <param name="resource">The caption metadata. <c>snippet.videoId</c>, <c>snippet.language</c>, and <c>snippet.name</c> are required; <c>snippet.isDraft</c> is optional.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/insert" />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        CaptionResource resource,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits a new caption track.
    /// </summary>
    /// <remarks>This overload sends metadata only. YouTube requires caption content for insertion and may return <c>contentRequired</c>. Use a stream overload to upload a track.</remarks>
    /// <param name="part">The resource parts to return; use <c>snippet</c>.</param>
    /// <param name="onBehalfOfContentOwner">The linked content partner owner identifier. This overload requires a non-null value; the API parameter itself is optional.</param>
    /// <param name="resource">The caption metadata. <c>snippet.videoId</c>, <c>snippet.language</c>, and <c>snippet.name</c> are required; <c>snippet.isDraft</c> is optional.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/insert" />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits a new caption track.
    /// </summary>
    /// <param name="part">The resource parts to return; use <c>snippet</c>.</param>
    /// <param name="resource">The caption metadata. <c>snippet.videoId</c>, <c>snippet.language</c>, and <c>snippet.name</c> are required; <c>snippet.isDraft</c> is optional.</param>
    /// <param name="stream">The caption data to upload. The API limits uploads to 100 MB.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/insert" />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        CaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits a new caption track.
    /// </summary>
    /// <param name="part">The resource parts to return; use <c>snippet</c>.</param>
    /// <param name="onBehalfOfContentOwner">The linked content partner owner identifier. This overload requires a non-null value; the API parameter itself is optional.</param>
    /// <param name="resource">The caption metadata. <c>snippet.videoId</c>, <c>snippet.language</c>, and <c>snippet.name</c> are required; <c>snippet.isDraft</c> is optional.</param>
    /// <param name="stream">The caption data to upload. The API limits uploads to 100 MB.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/insert" />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits a new caption track.
    /// </summary>
    /// <param name="part">The resource parts to return; use <c>snippet</c>.</param>
    /// <param name="onBehalfOfContentOwner">The linked content partner owner identifier. This overload requires a non-null value; the API parameter itself is optional.</param>
    /// <param name="resource">The caption metadata. <c>snippet.videoId</c>, <c>snippet.language</c>, and <c>snippet.name</c> are required; <c>snippet.isDraft</c> is optional.</param>
    /// <param name="stream">The caption data to upload. The API limits uploads to 100 MB.</param>
    /// <param name="contentType">The media MIME type. The API accepts <c>text/xml</c>, <c>application/octet-stream</c>, and <c>*/*</c>.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/insert" />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing caption track.
    /// </summary>
    /// <remarks>
/// <para>The part parameter selects both writable fields and response fields. Use <c>snippet</c>
/// for draft-status changes, otherwise <c>id</c>.</para>
/// <para>Omitting an existing writable property during an update can delete its value.
/// A stream overload replaces the caption file; metadata-only updates can change draft status.</para>
/// </remarks>
    /// <param name="part">The resource parts to include, such as <c>id</c> or <c>snippet</c>.</param>
    /// <param name="resource">The caption metadata. <c>id</c> is required; <c>snippet.isDraft</c> can be changed.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/update" />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        CaptionResource resource,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing caption track.
    /// </summary>
    /// <remarks>
/// <para>The part parameter selects both writable fields and response fields. Use <c>snippet</c>
/// for draft-status changes, otherwise <c>id</c>.</para>
/// <para>Omitting an existing writable property during an update can delete its value.
/// A stream overload replaces the caption file; metadata-only updates can change draft status.</para>
/// </remarks>
    /// <param name="part">The resource parts to include, such as <c>id</c> or <c>snippet</c>.</param>
    /// <param name="onBehalfOfContentOwner">The linked content partner owner identifier. This overload requires a non-null value; the API parameter itself is optional.</param>
    /// <param name="resource">The caption metadata. <c>id</c> is required; <c>snippet.isDraft</c> can be changed.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/update" />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing caption track.
    /// </summary>
    /// <remarks>
/// <para>The part parameter selects both writable fields and response fields. Use <c>snippet</c>
/// for draft-status changes, otherwise <c>id</c>.</para>
/// <para>Omitting an existing writable property during an update can delete its value.
/// A stream overload replaces the caption file; metadata-only updates can change draft status.</para>
/// </remarks>
    /// <param name="part">The resource parts to include, such as <c>id</c> or <c>snippet</c>.</param>
    /// <param name="resource">The caption metadata. <c>id</c> is required; <c>snippet.isDraft</c> can be changed.</param>
    /// <param name="stream">The caption data to upload. The API limits uploads to 100 MB.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/update" />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        CaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing caption track.
    /// </summary>
    /// <remarks>
/// <para>The part parameter selects both writable fields and response fields. Use <c>snippet</c>
/// for draft-status changes, otherwise <c>id</c>.</para>
/// <para>Omitting an existing writable property during an update can delete its value.
/// A stream overload replaces the caption file; metadata-only updates can change draft status.</para>
/// </remarks>
    /// <param name="part">The resource parts to include, such as <c>id</c> or <c>snippet</c>.</param>
    /// <param name="onBehalfOfContentOwner">The linked content partner owner identifier. This overload requires a non-null value; the API parameter itself is optional.</param>
    /// <param name="resource">The caption metadata. <c>id</c> is required; <c>snippet.isDraft</c> can be changed.</param>
    /// <param name="stream">The caption data to upload. The API limits uploads to 100 MB.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/update" />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing caption track.
    /// </summary>
    /// <remarks>
/// <para>The part parameter selects both writable fields and response fields. Use <c>snippet</c>
/// for draft-status changes, otherwise <c>id</c>.</para>
/// <para>Omitting an existing writable property during an update can delete its value.
/// A stream overload replaces the caption file; metadata-only updates can change draft status.</para>
/// </remarks>
    /// <param name="part">The resource parts to include, such as <c>id</c> or <c>snippet</c>.</param>
    /// <param name="onBehalfOfContentOwner">The linked content partner owner identifier. This overload requires a non-null value; the API parameter itself is optional.</param>
    /// <param name="resource">The caption metadata. <c>id</c> is required; <c>snippet.isDraft</c> can be changed.</param>
    /// <param name="stream">The caption data to upload. The API limits uploads to 100 MB.</param>
    /// <param name="contentType">The media MIME type. The API accepts <c>text/xml</c>, <c>application/octet-stream</c>, and <c>*/*</c>.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the resulting caption resource.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/update" />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Downloads caption data.
    /// </summary>
    /// <remarks>
/// <para>The authenticated user must be allowed to edit the video. The response is a binary file;
/// the caller must dispose the returned stream.</para>
/// <para>Conversion failures use <c>couldNotConvert</c>; check the requested format, language,
/// and track processing status.</para>
/// </remarks>
    /// <param name="id">The caption identifier.</param>
    /// <param name="onBehalfOfContentOwner">The content partner owner identifier, or <see langword="null"/> to omit delegation.</param>
    /// <param name="tfmt">The desired output format.
    /// <list type="bullet">
    /// <item><term>sbv</term><description>SubViewer.</description></item>
    /// <item><term>scc</term><description>Scenarist Closed Caption.</description></item>
    /// <item><term>srt</term><description>SubRip.</description></item>
    /// <item><term>ttml</term><description>Timed Text Markup Language.</description></item>
    /// <item><term>vtt</term><description>Web Video Text Tracks.</description></item>
    /// </list>
    /// <see langword="null"/> preserves the original format.</param>
    /// <param name="tlang">The target ISO 639-1 language code for machine translation. <see langword="null"/> preserves the original language.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the downloaded stream.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/download" />
    public Task<Stream> DownloadAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        string? tfmt = null,
        string? tlang = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a caption track.
    /// </summary>
    /// <remarks>A successful API response is <c>204 No Content</c>.</remarks>
    /// <param name="id">The caption identifier.</param>
    /// <param name="onBehalfOfContentOwner">The content partner owner identifier, or <see langword="null"/> to omit delegation.</param>
    /// <param name="cancellationToken">The token used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <seealso href="https://developers.google.com/youtube/v3/docs/captions/delete" />
    public Task DeleteAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );
}
