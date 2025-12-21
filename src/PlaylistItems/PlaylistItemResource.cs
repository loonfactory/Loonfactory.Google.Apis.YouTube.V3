// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

/// <summary>
/// Represents a playlist item resource returned by the YouTube Data API.
/// </summary>
public class PlaylistItemResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? Id { get; set; }

    public PlaylistItemSnippet? Snippet { get; set; }
    public PlaylistItemContentDetails? ContentDetails { get; set; }
    public PlaylistItemStatus? Status { get; set; }
}
