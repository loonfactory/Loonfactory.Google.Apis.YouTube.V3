// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public class PlaylistListResponse
{
    public string? Kind { get; set; }
    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }
    public string? NextPageToken { get; set; }
    public string? PrevPageToken { get; set; }
    public YouTubePageInfo? PageInfo { get; set; }
    public IEnumerable<PlaylistResource>? Items { get; set; }

}
