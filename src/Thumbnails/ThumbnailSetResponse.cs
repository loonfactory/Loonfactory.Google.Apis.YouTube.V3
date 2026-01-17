// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

public class ThumbnailSetResponse
{
    public string? Kind { get; set; }

    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    /// <summary>
    /// The uploaded thumbnail images.
    /// </summary>
    public ThumbnailResource? Items { get; set; }
}
