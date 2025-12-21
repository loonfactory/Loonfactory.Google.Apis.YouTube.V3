// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

public interface ICaptionHandler : IYouTubeHandler
{
    public Task<YouTubeResult<CaptionListResponse>> HandleCaptionListAsync(CaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<CaptionResource>> HandleCaptionInsertAsync(CaptionResource resource, StreamContent? content, CaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<CaptionResource>> HandleCaptionUpdateAsync(CaptionResource resource, StreamContent? content, CaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<Stream>> HandleCaptionDownloadAsync(CaptionProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult> HandleCaptionDeleteAsync(CaptionProperties properties, CancellationToken cancellationToken);
}
