// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// Represents a thumbnail image.
/// </summary>
public class Thumbnail
{
    /// <summary>
    /// The thumbnail image URL.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// The thumbnail image width.
    /// </summary>
    public uint? Width { get; set; }

    /// <summary>
    /// The thumbnail image height.
    /// </summary>
    public uint? Height { get; set; }
}
