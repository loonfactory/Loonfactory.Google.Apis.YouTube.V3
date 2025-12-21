// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public interface IPlaylistsService
{
    Task<PlaylistListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<PlaylistListResponse> ListByChannelIdAsync(
        StringValues part,
        string channelId,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<PlaylistListResponse> ListByMineAsync(
        StringValues part,
        bool mine,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<PlaylistResource> InsertAsync(
        StringValues part,
        PlaylistResource resource,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default);

    Task<PlaylistResource> UpdateAsync(
        StringValues part,
        PlaylistResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);
}
