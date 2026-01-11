// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Subscriptions;

/// <summary>
/// </summary>
public class SubscriptionResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }
    public string? Id { get; set; }
    public SubscriptionSnippet? Snippet { get; set; }
    public SubscriptionContentDetails? ContentDetails { get; set; }
    public SubscriberSnippet? SubscriberSnippet { get; set; }
}
