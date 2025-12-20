// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public class I18nRegionListResponse
{
    public string? Kind { get; set; }
    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }
    public IEnumerable<I18nRegionResource>? Items { get; set; }
}