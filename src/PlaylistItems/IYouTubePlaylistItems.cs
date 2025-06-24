// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

public interface IYouTubePlaylistItems
{
    Task<YouTubePlaylistItemListResource> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? onBehalfOfContentOwner = null,
        string? videoId = null,
        CancellationToken cancellationToken = default);

    Task<YouTubePlaylistItemListResource> ListByPlaylistIdAsync(
        StringValues part,
        string playlistId,
        uint? maxResults = null,
        string? pageToken = null,
        string? onBehalfOfContentOwner = null,
        string? videoId = null,
        CancellationToken cancellationToken = default);

    Task<YouTubePlaylistItemResource> InsertAsync(
        StringValues part,
        YouTubePlaylistItemResource resource,
        CancellationToken cancellationToken = default);

    Task<YouTubePlaylistItemResource> UpdateAsync(
        StringValues part,
        YouTubePlaylistItemResource resource,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);
}
