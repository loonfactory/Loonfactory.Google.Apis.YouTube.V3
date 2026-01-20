// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// Represents the set of thumbnail images available for a YouTube resource.
/// </summary>
/// <remarks>
/// Different types of resources may support different thumbnail sizes.
/// </remarks>
public class ThumbnailResource
{
    /// <summary>
    /// The default image for this resource.
    /// </summary>
    public Thumbnail? Default { get; set; }

    /// <summary>
    /// The medium quality image for this resource.
    /// </summary>
    public Thumbnail? Medium { get; set; }

    /// <summary>
    /// The high quality image for this resource.
    /// </summary>
    public Thumbnail? High { get; set; }

    /// <summary>
    /// The standard quality image for this resource.
    /// </summary>
    public Thumbnail? Standard { get; set; }

    /// <summary>
    /// The maximum resolution quality image for this resource.
    /// </summary>
    public Thumbnail? Maxres { get; set; }
}