// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public interface IPlaylistImagesService
{
    public Task<PlaylistImageListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<PlaylistImageListResponse> ListByPlaylistIdAsync(
        StringValues part,
        string playlistId,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<PlaylistImageResource> UpdateAsync(
        StringValues part,
        PlaylistImageResource resource,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );
    
    public Task<PlaylistImageResource> UpdateAsync(
        StringValues part,
        PlaylistImageResource resource,
        StreamContent content,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<PlaylistImageResource> InsertAsync(
        StringValues part,
        PlaylistImageResource resource,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    );

    public Task<PlaylistImageResource> InsertAsync(
        StringValues part,
        PlaylistImageResource resource,
        StreamContent content,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    );
    
    public Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );
}
