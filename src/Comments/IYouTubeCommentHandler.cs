// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public interface IYouTubeCommentHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeCommentListResource>> HandleCommentListAsync(YouTubeCommentProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult<YouTubeCommentResource>> HandleCommentInsertAsync(YouTubeCommentResource resource, YouTubeCommentProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult<YouTubeCommentResource>> HandleCommentUpdateAsync(YouTubeCommentResource resource, YouTubeCommentProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult> HandleCommentDeleteAsync(YouTubeCommentProperties properties, CancellationToken cancellationToken);
    
    public Task<YouTubeResult> HandleSetModerationStatus(YouTubeCommentProperties properties, CancellationToken cancellationToken);
}
