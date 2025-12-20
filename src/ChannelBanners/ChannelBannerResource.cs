// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

public class ChannelBannerResource
{
    /// <summary>
    /// Identifies the API resource's type.
    /// The value will be <c>"youtube#caption"</c>.
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    /// <summary>
    /// @TODO
    /// </summary>
    public string? Url { get; set; }
}