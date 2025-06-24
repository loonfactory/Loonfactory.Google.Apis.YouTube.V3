// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

/// <summary>
/// Basic details about the playlist item.
/// </summary>
public class YouTubePlaylistItemSnippetResource
{
    public string? PlaylistId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Position { get; set; }
    public DateTime? PublishedAt { get; set; }
}
