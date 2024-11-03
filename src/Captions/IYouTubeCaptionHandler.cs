// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

public interface IYouTubeCaptionHandler
{
    public Task<YouTubeResult<YouTubeCaptionListResource>> HandleCaptionListAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<YouTubeCaptionResource>> HandleCaptionInsertAsync(YouTubeCaptionResource resource, StreamContent? content, YouTubeCaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<YouTubeCaptionResource>> HandleCaptionUpdateAsync(YouTubeCaptionResource resource, StreamContent? content, YouTubeCaptionProperties properties, CancellationToken cancellationToken);

    public Task HandleCaptionDeleteAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken);
}
