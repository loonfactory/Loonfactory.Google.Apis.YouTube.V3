// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;

public interface IVideoAbuseReportReasonHandler : IYouTubeHandler
{
    Task<YouTubeResult<VideoAbuseReportReasonListResponse>> HandleVideoAbuseReportReasonListAsync(
        VideoAbuseReportReasonProperties properties,
        CancellationToken cancellationToken);
}
