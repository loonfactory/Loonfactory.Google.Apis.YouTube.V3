// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// Represents a response for a thumbnail set operation.
/// </summary>
public class ThumbnailSetResponse
{
    /// <summary>
    /// Identifies the resource type.
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    /// <summary>
    /// A list of thumbnails.
    /// </summary>
    public IEnumerable<ThumbnailResource>? Items { get; set; }
}