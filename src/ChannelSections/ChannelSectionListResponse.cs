// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

/// <summary>
/// The ChannelSectionListResponse represents a list of YouTube ChannelSection resources.
/// </summary>
public class ChannelSectionListResponse
{
    public string? Kind { get; set; }
    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }
    public IEnumerable<ChannelSectionResource>? Items { get; set; }
}