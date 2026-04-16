// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;

public class VideoAbuseReportReasonHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IVideoAbuseReportReasonHandler
{
    public virtual Task<YouTubeResult<VideoAbuseReportReasonListResponse>> HandleVideoAbuseReportReasonListAsync(
        VideoAbuseReportReasonProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);
        if (properties.Part is null)
        {
            throw new ArgumentNullException(nameof(properties), "The properties.Part parameter is null.");
        }

        if (properties.Part.Value.Count == 0)
        {
            throw new ArgumentException("The properties.Part parameter must be provided in the properties.");
        }

        return ExecuteAsync<VideoAbuseReportReasonListResponse>(
            HttpMethod.Get,
            VideoAbuseReportReasonDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }
}
