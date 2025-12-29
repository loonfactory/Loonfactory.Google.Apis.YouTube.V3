// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

/// <summary>
/// Basic details about the playlist item.
/// </summary>
public class PlaylistItemSnippet
{
    public string? ChannelId { get; set; }
    public string? PlaylistId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public YouTubeThumbnailDetailsResource? Thumbnails { get; set; }
    public uint? Position { get; set; }
    public DateTimeOffset? PublishedAt { get; set; }
    public string? ChannelTitle { get; set; }
    public PlaylistItemId? ResourceId { get; set; }
    public string? VideoOwnerChannelTitle { get; set; }
    public string? VideoOwnerChannelId { get; set; }
}
