// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

public interface IYouTubeCaptionHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeCaptionListResource>> HandleCaptionListAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<YouTubeCaptionResource>> HandleCaptionInsertAsync(YouTubeCaptionResource resource, StreamContent? content, YouTubeCaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<YouTubeCaptionResource>> HandleCaptionUpdateAsync(YouTubeCaptionResource resource, StreamContent? content, YouTubeCaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<Stream>> HandleCaptionDownloadAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult> HandleCaptionDeleteAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken);
}
