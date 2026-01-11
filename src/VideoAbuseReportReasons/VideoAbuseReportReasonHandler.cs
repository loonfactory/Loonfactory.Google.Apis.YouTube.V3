// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;

public class VideoAbuseReportReasonHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), IVideoAbuseReportReasonHandler
{
    public virtual async Task<YouTubeResult<VideoAbuseReportReasonListResponse>> HandleVideoAbuseReportReasonListAsync(
        VideoAbuseReportReasonProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);
        if (properties.Part is null)
        {
            throw new ArgumentNullException(nameof(properties), "The properties.Part parameter is null.");
        }

        if (properties.Part?.Count == 0)
        {
            throw new ArgumentException("The properties.Part parameter must be provided in the properties.");
        }

        var response = await SendAsync(
            HttpMethod.Get,
            VideoAbuseReportReasonDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<VideoAbuseReportReasonListResponse>.Success((
                await response.Content.ReadFromJsonAsync<VideoAbuseReportReasonListResponse>(
                    YouTubeDefaults.JsonSerializerOptions,
                    cancellationToken
                ).ConfigureAwait(false))!),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}
