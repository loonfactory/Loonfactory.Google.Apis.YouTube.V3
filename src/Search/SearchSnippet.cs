// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

namespace Loonfactory.Google.Apis.YouTube.V3.Search;

public class SearchSnippet
{
    public DateTimeOffset? PublishedAt { get; set; }
    public string? ChannelId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Dictionary<string, Thumbnail>? Thumbnails { get; set; }
    public string? ChannelTitle { get; set; }
    public string? LiveBroadcastContent { get; set; }
}
