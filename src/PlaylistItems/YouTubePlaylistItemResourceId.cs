// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

/// <summary>
/// Identifies the video associated with the playlist item.
/// </summary>
public class YouTubePlaylistItemResourceId
{
    public string? Kind { get; set; }
    public string? VideoId { get; set; }
    public string? PlaylistId { get; set; }
    public string? ChannelId { get; set; }
}
