// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Watermarks;

/// <summary>
/// Represents the spatial position of a watermark in the video player.
/// </summary>
public class WatermarkPosition
{
    /// <summary>
    /// The manner in which the watermark is positioned.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// The corner in which the watermark appears.
    /// </summary>
    public string? CornerPosition { get; set; }
}
