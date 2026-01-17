// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

public interface IThumbnailHandler : IYouTubeHandler
{
    Task<YouTubeResult<ThumbnailSetResponse>> HandleThumbnailSetAsync(
        Stream thumbnail,
        string contentType,
        ThumbnailProperties properties,
        CancellationToken cancellationToken);
}
