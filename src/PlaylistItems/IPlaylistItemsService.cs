// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

public interface IPlaylistItemsService
{
    Task<PlaylistItemListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? onBehalfOfContentOwner = null,
        string? videoId = null,
        CancellationToken cancellationToken = default);

    Task<PlaylistItemListResponse> ListByPlaylistIdAsync(
        StringValues part,
        string playlistId,
        uint? maxResults = null,
        string? pageToken = null,
        string? onBehalfOfContentOwner = null,
        string? videoId = null,
        CancellationToken cancellationToken = default);

    Task<PlaylistItemResource> InsertAsync(
        StringValues part,
        PlaylistItemResource resource,
        CancellationToken cancellationToken = default);

    Task<PlaylistItemResource> UpdateAsync(
        StringValues part,
        PlaylistItemResource resource,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);
}
