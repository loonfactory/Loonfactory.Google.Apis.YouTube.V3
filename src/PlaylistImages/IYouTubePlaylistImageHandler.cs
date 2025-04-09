// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public interface IYouTubePlaylistImageHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubePlaylistImageListResource>> HandlePlaylistImageListAsync(
        YouTubePlaylistImageProperties properties,
        CancellationToken cancellationToken
    );

    public Task<YouTubeResult<YouTubePlaylistImageResource>> HandlePlaylistImageInsertAsync(
        YouTubePlaylistImageResource resource,
        StreamContent content,
        YouTubePlaylistImageProperties properties,
        CancellationToken cancellationToken
    );

    public Task<YouTubeResult<YouTubePlaylistImageResource>> HandlePlaylistImageUpdateAsync(
        YouTubePlaylistImageResource resource,
        StreamContent content,
        YouTubePlaylistImageProperties properties,
        CancellationToken cancellationToken
    );

    public Task<YouTubeResult> HandlePlaylistImageDeleteAsync(YouTubePlaylistImageProperties properties, CancellationToken cancellationToken);
}
