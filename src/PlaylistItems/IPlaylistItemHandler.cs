// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

public interface IPlaylistItemHandler : IYouTubeHandler
{
    Task<YouTubeResult<PlaylistItemListResponse>> HandlePlaylistItemListAsync(
        PlaylistItemProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<PlaylistItemResource>> HandlePlaylistItemInsertAsync(
        PlaylistItemResource resource,
        PlaylistItemProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<PlaylistItemResource>> HandlePlaylistItemUpdateAsync(
        PlaylistItemResource resource,
        PlaylistItemProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult> HandlePlaylistItemDeleteAsync(
        PlaylistItemProperties properties,
        CancellationToken cancellationToken);
}
