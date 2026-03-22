// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public interface IVideoHandler : IYouTubeHandler
{
    Task<YouTubeResult<VideoListResponse>> HandleVideoListAsync(
        VideoProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<VideoResource>> HandleVideoInsertAsync(
        VideoResource resource,
        StreamContent? content,
        VideoProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<VideoResource>> HandleVideoUpdateAsync(
        VideoResource resource,
        StreamContent? content,
        VideoProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult> HandleVideoDeleteAsync(
        VideoProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult> HandleVideoRateAsync(
        VideoProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<VideoGetRatingResponse>> HandleVideoGetRatingAsync(
        VideoProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult> HandleVideoReportAbuseAsync(
        VideoReportAbuseRequest resource,
        VideoProperties properties,
        CancellationToken cancellationToken);
}
