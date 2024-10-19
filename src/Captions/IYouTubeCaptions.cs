// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// A caption resource represents a YouTube caption track. A caption track is associated with exactly one YouTube video.
/// </summary>
public interface IYouTubeCaptions
{
    /// <summary>
    /// Retrieves a list of caption tracks that are associated with a specified video.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="videoId">
    /// The <c>videoId</c> parameter specifies the YouTube video ID of the video for which the API should return caption tracks.
    /// </param>
    /// <param name="id">
    /// The <c>id</c> parameter specifies a comma-separated list of IDs that identify the caption resources to retrieve.
    /// Each ID must identify a caption track associated with the specified video.
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// </param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// If successful, this method returns a <see cref="YouTubeCaptionListResource"/>.
    /// </returns>
    public Task<YouTubeCaptionListResource> ListAsync(
        IEnumerable<string> part,
        string videoId,
        string? id = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a caption track.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="resource">
    /// The <see cref="YouTubeCaptionResource"/> representing the caption track to insert.
    /// </param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// If successful, returns the inserted <see cref="YouTubeCaptionResource"/>.
    /// </returns>
    public Task<YouTubeCaptionResource> InsertAsync(
        IEnumerable<string> part,
        YouTubeCaptionResource resource,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a caption track on behalf of the content owner.
    /// </summary>
    /// <param name="part">The <c>part</c> parameter specifies the caption resource parts that the API response will include.</param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to insert.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the inserted <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> InsertAsync(
        IEnumerable<string> part,
        string? onBehalfOfContentOwner,
        YouTubeCaptionResource resource,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a caption track with additional data provided in a stream.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to insert.</param>
    /// <param name="stream">The stream to upload.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the inserted <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> InsertAsync(
        IEnumerable<string> part,
        YouTubeCaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a caption track with additional data provided in a stream on behalf of the content owner.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// <para>This parameter is optional.</para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to insert.</param>
    /// <param name="stream">The stream containing the data to upload.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the inserted <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> InsertAsync(
        IEnumerable<string> part,
        string? onBehalfOfContentOwner,
        YouTubeCaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a caption track with additional data provided in a stream and specify the content type.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// <para>This parameter is optional.</para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to insert.</param>
    /// <param name="stream">The stream containing the data to upload.</param>
    /// <param name="contentType">The content type of the data in the stream.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the inserted <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> InsertAsync(
        IEnumerable<string> part,
        string? onBehalfOfContentOwner,
        YouTubeCaptionResource resource,
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a caption track. When updating a caption track, you can change the track's draft status.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to update.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the updated <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> UpdateAsync(
        IEnumerable<string> part,
        YouTubeCaptionResource resource,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a caption track on behalf of the content owner. When updating a caption track, you can change the track's draft status.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to update.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the updated <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> UpdateAsync(
        IEnumerable<string> part,
        string? onBehalfOfContentOwner,
        YouTubeCaptionResource resource,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a caption track with additional data provided in a stream. When updating a caption track, you can change the track's draft status, upload new data for the track, or both.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to update.</param>
    /// <param name="stream">The stream containing the data to upload.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the updated <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> UpdateAsync(
        IEnumerable<string> part,
        YouTubeCaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a caption track. When updating a caption track, you can change the track's draft status, upload a new caption file for the track, or both.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// <para>This parameter is optional.</para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to update.</param>
    /// <param name="stream">The stream containing the data to upload.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the updated <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> UpdateAsync(
        IEnumerable<string> part,
        string? onBehalfOfContentOwner,
        YouTubeCaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a caption track with additional data provided in a stream and specify the content type. When updating a caption track, you can change the track's draft status, upload new data for the track, or both.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies the caption resource parts that the API response will include.
    /// <para>
    /// The list below contains the part names that you can include in the parameter value:
    /// </para>
    /// <para>
    /// <strong>id</strong> – The unique identifier for the caption track.
    /// </para>
    /// <para>
    /// <strong>snippet</strong> – Contains basic details about the caption track, such as its language and name.
    /// </para>
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// <para>This parameter is optional.</para>
    /// </param>
    /// <param name="resource">The <see cref="YouTubeCaptionResource"/> representing the caption track to update.</param>
    /// <param name="stream">The stream containing the data to upload.</param>
    /// <param name="contentType">The content type of the data in the stream.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>If successful, returns the updated <see cref="YouTubeCaptionResource"/>.</returns>
    public Task<YouTubeCaptionResource> UpdateAsync(
        IEnumerable<string> part,
        string? onBehalfOfContentOwner,
        YouTubeCaptionResource resource,
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Downloads a caption track.
    /// </summary>
    /// <remarks>
    /// The caption track is returned in its original format unless the request specifies a value for the <c>tfmt</c> parameter,
    /// and in its original language unless the request specifies a value for the <c>tlang</c> parameter.
    /// </remarks>
    /// <param name="id">
    /// The <c>id</c> parameter identifies the caption track that is being retrieved.
    /// The value is a caption track ID as identified by the <c>id</c> property in a caption resource.
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// <para>This parameter is optional.</para>
    /// </param>
    /// <param name="tfmt">
    /// Converts the captions into this format. Supported options are <c>sbv</c>, <c>srt</c>, and <c>vtt</c>.
    /// This parameter is optional.
    /// </param>
    /// <param name="tlang">
    /// The language code; machine translates the captions into this language.
    /// This parameter is optional.
    /// </param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// If successful, returns a <see cref="Stream"/> containing the downloaded caption track data.
    /// </returns>
    public Task<Stream> DownloadAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        string? tfmt = null,
        string? tlang = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a specified caption track.
    /// </summary>
    /// <param name="id">
    /// The <c>id</c> parameter identifies the caption track that is being deleted.
    /// The value is a caption track ID as identified by the <c>id</c> property in a caption resource.
    /// </param>
    /// <param name="onBehalfOfContentOwner">
    /// <para><em>Note:</em> This parameter is intended exclusively for YouTube content partners.</para>
    /// <para>
    /// The <c>onBehalfOfContentOwner</c> parameter indicates that the request's authorization credentials identify a
    /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value.
    /// </para>
    /// <para>This parameter is optional.</para>
    /// </param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous delete operation.
    /// </returns>
    public Task DeleteAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );
}
