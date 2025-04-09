// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

/// <summary>
/// @TODO
/// </summary>
public class YouTubePlaylistImageResource
{
    /// <summary>
    /// @TODO
    /// </summary>
    public string? Kind { get; set; }

    public string? Id { get; set; }

    public YouTubePlaylistImageSnippetResource? Snippet { get; set; }
}