// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;

public class VideoAbuseReportReasonListResponse
{
    public string? Kind { get; set; }

    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public IEnumerable<VideoAbuseReportReasonResource>? Items { get; set; }
}
