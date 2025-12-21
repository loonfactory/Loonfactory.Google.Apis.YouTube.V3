// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public interface IPlaylistHandler : IYouTubeHandler
{
    Task<YouTubeResult<PlaylistListResponse>> HandlePlaylistListAsync(
        PlaylistProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<PlaylistResource>> HandlePlaylistInsertAsync(
        PlaylistResource resource,
        PlaylistProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<PlaylistResource>> HandlePlaylistUpdateAsync(
        PlaylistResource resource,
        PlaylistProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult> HandlePlaylistDeleteAsync(
        PlaylistProperties properties,
        CancellationToken cancellationToken);
}
