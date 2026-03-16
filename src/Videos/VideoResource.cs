// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideoResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? Id { get; set; }
    public VideoSnippet? Snippet { get; set; }
    public VideoStatus? Status { get; set; }
    public VideoContentDetails? ContentDetails { get; set; }
    public VideoStatistics? Statistics { get; set; }
    public VideoPlayer? Player { get; set; }
    public VideoLiveStreamingDetails? LiveStreamingDetails { get; set; }
    public Dictionary<string, YouTubeLocalizedResource>? Localizations { get; set; }
}
