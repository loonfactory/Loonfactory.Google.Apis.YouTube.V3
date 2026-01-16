// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

public interface IThumbnailService
{
    Task<ThumbnailSetResponse> SetAsync(
        string videoId,
        Stream thumbnail,
        string contentType = "image/jpeg",
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);
}
