// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

public class VideoCategoryListResponse
{
    public string? Kind { get; set; }

    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public YouTubePageInfo? PageInfo { get; set; }

    public IEnumerable<VideoCategoryResource>? Items { get; set; }
}
