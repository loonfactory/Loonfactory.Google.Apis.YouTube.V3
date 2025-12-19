// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public interface IYouTubePlaylists
{
    Task<YouTubePlaylistListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<YouTubePlaylistListResponse> ListByChannelIdAsync(
        StringValues part,
        string channelId,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<YouTubePlaylistListResponse> ListByMineAsync(
        StringValues part,
        bool mine,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<YouTubePlaylistResource> InsertAsync(
        StringValues part,
        YouTubePlaylistResource resource,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default);

    Task<YouTubePlaylistResource> UpdateAsync(
        StringValues part,
        YouTubePlaylistResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);
}
