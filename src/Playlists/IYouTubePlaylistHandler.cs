// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public interface IYouTubePlaylistHandler : IYouTubeHandler
{
    Task<YouTubeResult<YouTubePlaylistListResponse>> HandlePlaylistListAsync(
        YouTubePlaylistProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<YouTubePlaylistResource>> HandlePlaylistInsertAsync(
        YouTubePlaylistResource resource,
        YouTubePlaylistProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<YouTubePlaylistResource>> HandlePlaylistUpdateAsync(
        YouTubePlaylistResource resource,
        YouTubePlaylistProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult> HandlePlaylistDeleteAsync(
        YouTubePlaylistProperties properties,
        CancellationToken cancellationToken);
}
