// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

/// <summary>
/// Interface for managing YouTube comment threads using the YouTube Data API.
/// </summary>
public interface IYouTubeCommentThreads
{
    /// <summary>
    /// Retrieves all comment threads related to a specific channel ID.
    /// </summary>
    /// <param name="part">Specifies the properties of the comment thread resource to retrieve.</param>
    /// <param name="allThreadsRelatedToChannelId">The ID of the channel whose comment threads are being retrieved.</param>
    /// <param name="maxResults">The maximum number of items to include in the response (1 to 100).</param>
    /// <param name="moderationStatus">Filter threads by their moderation status.</param>
    /// <param name="order">Specifies the order in which threads are sorted.</param>
    /// <param name="pageToken">Token for the next page of results.</param>
    /// <param name="searchTerms">Filter threads containing the specified text.</param>
    /// <param name="textFormat">Specifies whether the response includes plain text or HTML-formatted content.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation, containing a list of YouTube comment threads.</returns>
    public Task<YouTubeCommentListResource> GetByAllThreadsRelatedToChannelIdAsync(
        StringValues part,
        string allThreadsRelatedToChannelId,
        uint? maxResults = null,
        YouTubeCommentThreadModerationStatus? moderationStatus = null,
        YouTubeCommentThreadOrder? order = null,
        string? pageToken = null,
        string? searchTerms = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves specific comment threads by their IDs.
    /// </summary>
    /// <param name="part">Specifies the properties of the comment thread resource to retrieve.</param>
    /// <param name="id">The ID(s) of the comment threads to retrieve.</param>
    /// <param name="maxResults">The maximum number of items to include in the response (1 to 100).</param>
    /// <param name="pageToken">Token for the next page of results.</param>
    /// <param name="searchTerms">Filter threads containing the specified text.</param>
    /// <param name="textFormat">Specifies whether the response includes plain text or HTML-formatted content.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation, containing a list of YouTube comment threads.</returns>
    public Task<YouTubeCommentListResource> GetByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? searchTerms = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves comment threads associated with a specific video.
    /// </summary>
    /// <param name="part">Specifies the properties of the comment thread resource to retrieve.</param>
    /// <param name="videoId">The ID of the video whose comment threads are being retrieved.</param>
    /// <param name="maxResults">The maximum number of items to include in the response (1 to 100).</param>
    /// <param name="moderationStatus">Filter threads by their moderation status.</param>
    /// <param name="order">Specifies the order in which threads are sorted.</param>
    /// <param name="pageToken">Token for the next page of results.</param>
    /// <param name="searchTerms">Filter threads containing the specified text.</param>
    /// <param name="textFormat">Specifies whether the response includes plain text or HTML-formatted content.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation, containing a list of YouTube comment threads.</returns>
    public Task<YouTubeCommentListResource> GetByVideoIdAsync(
        StringValues part,
        string videoId,
        uint? maxResults = null,
        YouTubeCommentThreadModerationStatus? moderationStatus = null,
        YouTubeCommentThreadOrder? order = null,
        string? pageToken = null,
        string? searchTerms = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Inserts a new comment thread.
    /// </summary>
    /// <param name="part">Specifies the properties of the comment thread resource to include in the response.</param>
    /// <param name="resource">The comment thread resource to insert.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation, containing the inserted YouTube comment thread resource.</returns>
    public Task<YouTubeCommentThreadResource> InsertAsync(
        StringValues part,
        YouTubeCommentThreadResource resource,
        CancellationToken cancellationToken = default
    );
}
