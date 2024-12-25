// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

public interface IYouTubeCommentThreadHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeCommentListResource>> HandleCommentThreadListAsync(
        YouTubeCommentThreadProperties properties,
        CancellationToken cancellationToken
    );

    public Task<YouTubeResult<YouTubeCommentThreadResource>> HandleCommentThreadInsertAsync(
        YouTubeCommentThreadResource resource,
        YouTubeCommentThreadProperties properties,
        CancellationToken cancellationToken
    );
}
