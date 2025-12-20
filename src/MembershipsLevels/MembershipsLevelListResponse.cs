// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public class MembershipsLevelListResponse
{
    public string? Kind { get; set; }
    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }
    public string? NextPageToken { get; set; }
    public YouTubePageInfo? PageInfo { get; set; }
    public IEnumerable<MembershipsLevelResource>? Items { get; set; }
}