// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// Container for multiple thumbnail sizes.
/// </summary>
public class YouTubeThumbnailDetailsResource
{
    [JsonPropertyName("default")]
    public YouTubeThumbnailResource? Default { get; set; }
    public YouTubeThumbnailResource? Medium { get; set; }
    public YouTubeThumbnailResource? High { get; set; }
    public YouTubeThumbnailResource? Standard { get; set; }
    public YouTubeThumbnailResource? Maxres { get; set; }
}
