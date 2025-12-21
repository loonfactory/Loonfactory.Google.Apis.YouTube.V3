// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

/// <summary>
/// Additional details about the video in the playlist.
/// </summary>
public class PlaylistItemContentDetails
{
    public string? VideoId { get; set; }
    public string? StartAt { get; set; }
    public string? EndAt { get; set; }
    public string? Note { get; set; }
    public DateTime? VideoPublishedAt { get; set; }
}
