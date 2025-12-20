// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

public interface ICommentThreadHandler : IYouTubeHandler
{
    public Task<YouTubeResult<CommentListResponse>> HandleCommentThreadListAsync(
        CommentThreadProperties properties,
        CancellationToken cancellationToken
    );

    public Task<YouTubeResult<CommentThreadResource>> HandleCommentThreadInsertAsync(
        CommentThreadResource resource,
        CommentThreadProperties properties,
        CancellationToken cancellationToken
    );
}
