// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public interface ICommentsService
{
    public Task<CommentListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default
    );

    public Task<CommentListResponse> ListByParentIdAsync(
        StringValues part,
        string parentId,
        uint? maxResults = null,
        string? pageToken = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default
    );

    public Task<CommentResource> UpdateAsync(
        StringValues part,
        CommentResource resource,
        CancellationToken cancellationToken = default
    );

    public Task<CommentResource> InsertAsync(
        StringValues part,
        CommentResource resource,
        CancellationToken cancellationToken = default
    );

    public Task DeleteAsync(
        StringValues id,
        CancellationToken cancellationToken = default
    );

    public Task SetModerationStatusAsync(
        StringValues id,
        CommentModerationStatus moderationStatus,
        bool? banAuthor = null,
        CancellationToken cancellationToken = default
    );
}
