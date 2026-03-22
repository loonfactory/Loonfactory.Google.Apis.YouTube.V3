// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Watermarks;

/// <summary>
/// Represents timing information for when a watermark is displayed.
/// </summary>
public class WatermarkTiming
{
    /// <summary>
    /// The timing type that indicates whether the offset is from the start or end of playback.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// The time offset in milliseconds.
    /// </summary>
    public ulong? OffsetMs { get; set; }

    /// <summary>
    /// The display duration in milliseconds.
    /// </summary>
    public ulong? DurationMs { get; set; }
}
