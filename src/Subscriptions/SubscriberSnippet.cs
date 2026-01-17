// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

namespace Loonfactory.Google.Apis.YouTube.V3.Subscriptions;

public class SubscriberSnippet
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ChannelId { get; set; }
    public Dictionary<string, Thumbnail>? Thumbnails { get; set; }
}
