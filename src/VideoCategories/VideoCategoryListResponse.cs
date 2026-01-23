// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <summary>
/// Represents a response that contains a list of video categories.
/// </summary>
public class VideoCategoryListResponse
{
    /// <summary>
    /// The type of the API resource.
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// The ETag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    /// <summary>
    /// Paging details for the list response.
    /// </summary>
    public YouTubePageInfo? PageInfo { get; set; }

    /// <summary>
    /// The list of video category resources.
    /// </summary>
    public IEnumerable<VideoCategoryResource>? Items { get; set; }
}
