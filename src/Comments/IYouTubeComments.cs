// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public interface IYouTubeComments
{
    public Task<YouTubeCommentListResource> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeCommentListResource> ListByParentIdAsync(
        StringValues part,
        string parentId,
        uint? maxResults = null,
        string? pageToken = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeCommentResource> UpdateAsync(
        StringValues part,
        YouTubeCommentResource resource,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeCommentResource> InsertAsync(
        StringValues part,
        YouTubeCommentResource resource,
        CancellationToken cancellationToken = default
    );

    public Task DeleteAsync(
        StringValues id,
        CancellationToken cancellationToken = default
    );

    public Task SetModerationStatusAsync(
        StringValues id,
        YouTubeCommentModerationStatus moderationStatus,
        bool? banAuthor = null,
        CancellationToken cancellationToken = default
    );
}
