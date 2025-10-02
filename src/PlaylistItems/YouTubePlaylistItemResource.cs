// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

/// <summary>
/// Represents a playlist item resource returned by the YouTube Data API.
/// </summary>
public class YouTubePlaylistItemResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? Id { get; set; }

    public YouTubePlaylistItemSnippetResource? Snippet { get; set; }
    public YouTubePlaylistItemContentDetailsResource? ContentDetails { get; set; }
    public YouTubePlaylistItemStatusResource? Status { get; set; }
}
