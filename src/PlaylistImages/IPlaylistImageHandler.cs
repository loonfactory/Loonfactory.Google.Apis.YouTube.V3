// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public interface IPlaylistImageHandler : IYouTubeHandler
{
    public Task<YouTubeResult<PlaylistImageListResponse>> HandlePlaylistImageListAsync(
        PlaylistImageProperties properties,
        CancellationToken cancellationToken
    );

    public Task<YouTubeResult<PlaylistImageResource>> HandlePlaylistImageInsertAsync(
        PlaylistImageResource resource,
        StreamContent content,
        PlaylistImageProperties properties,
        CancellationToken cancellationToken
    );

    public Task<YouTubeResult<PlaylistImageResource>> HandlePlaylistImageUpdateAsync(
        PlaylistImageResource resource,
        StreamContent content,
        PlaylistImageProperties properties,
        CancellationToken cancellationToken
    );

    public Task<YouTubeResult> HandlePlaylistImageDeleteAsync(PlaylistImageProperties properties, CancellationToken cancellationToken);
}
