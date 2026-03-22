// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideoListResponse
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? NextPageToken { get; set; }
    public string? PrevPageToken { get; set; }
    public YouTubePageInfo? PageInfo { get; set; }
    public IEnumerable<VideoResource>? Items { get; set; }
}
