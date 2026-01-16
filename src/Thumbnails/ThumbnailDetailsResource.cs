// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// Container for multiple thumbnail sizes.
/// </summary>
public class ThumbnailResource
{
    public Thumbnail? Default { get; set; }
    public Thumbnail? Medium { get; set; }
    public Thumbnail? High { get; set; }
    public Thumbnail? Standard { get; set; }
    public Thumbnail? Maxres { get; set; }
}
