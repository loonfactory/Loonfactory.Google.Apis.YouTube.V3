// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// The YouTubeCaptionList represents a list of YouTube caption resources.
/// </summary>
public class CaptionListResponse
{
    public string? Kind { get; set; }
    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }
    public IEnumerable<CaptionResource>? Items { get; set; }
}