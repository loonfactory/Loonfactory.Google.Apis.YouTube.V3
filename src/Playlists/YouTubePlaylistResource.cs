// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

/// <summary>
/// Represents a playlist resource returned by the YouTube Data API.
/// </summary>
public class YouTubePlaylistResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? Id { get; set; }

    public YouTubePlaylistSnippetResource? Snippet { get; set; }
    public YouTubePlaylistStatusResource? Status { get; set; }
    public YouTubePlaylistContentDetailsResource? ContentDetails { get; set; }
    public YouTubePlaylistPlayerResource? Player { get; set; }
    public Dictionary<string, YouTubeLocalizedResource>? Localizations { get; set; }
}
