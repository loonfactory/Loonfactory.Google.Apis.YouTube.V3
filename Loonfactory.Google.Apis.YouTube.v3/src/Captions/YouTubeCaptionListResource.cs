// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.v3.Captions;

/// <summary>
/// The YouTubeCaptionList represents a list of YouTube caption resources.
/// </summary>
public class YouTubeCaptionListResource
{
    /// <summary>
    /// Identifies the API resource's type.
    /// The value will be <c>"youtube#captionListResponse"</c>.
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    /// <summary>
    /// A list of captions that match the request criteria.
    /// </summary>
    public IEnumerable<YouTubeCaptionResource>? Items { get; set; }
}