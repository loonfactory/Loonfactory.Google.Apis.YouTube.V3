// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

public interface IYouTubePlaylistItemHandler : IYouTubeHandler
{
    Task<YouTubeResult<YouTubePlaylistItemListResource>> HandlePlaylistItemListAsync(
        YouTubePlaylistItemProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<YouTubePlaylistItemResource>> HandlePlaylistItemInsertAsync(
        YouTubePlaylistItemResource resource,
        YouTubePlaylistItemProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<YouTubePlaylistItemResource>> HandlePlaylistItemUpdateAsync(
        YouTubePlaylistItemResource resource,
        YouTubePlaylistItemProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult> HandlePlaylistItemDeleteAsync(
        YouTubePlaylistItemProperties properties,
        CancellationToken cancellationToken);
}
