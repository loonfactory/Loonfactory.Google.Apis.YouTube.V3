// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

/// <summary>
/// Represents a playlist resource returned by the YouTube Data API.
/// </summary>
public class PlaylistResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? Id { get; set; }

    public PlaylistSnippet? Snippet { get; set; }
    public PlaylistStatus? Status { get; set; }
    public PlaylistContentDetails? ContentDetails { get; set; }
    public PlaylistPlayer? Player { get; set; }
    public Dictionary<string, YouTubeLocalizedResource>? Localizations { get; set; }
}
