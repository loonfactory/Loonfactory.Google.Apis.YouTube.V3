// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public interface ICommentHandler : IYouTubeHandler
{
    public Task<YouTubeResult<CommentListResponse>> HandleCommentListAsync(CommentProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult<CommentResource>> HandleCommentInsertAsync(CommentResource resource, CommentProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult<CommentResource>> HandleCommentUpdateAsync(CommentResource resource, CommentProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult> HandleCommentDeleteAsync(CommentProperties properties, CancellationToken cancellationToken);
    
    public Task<YouTubeResult> HandleSetModerationStatus(CommentProperties properties, CancellationToken cancellationToken);
}
