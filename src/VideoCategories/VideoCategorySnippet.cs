// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <summary>
/// Represents the snippet for a video category.
/// </summary>
public class VideoCategorySnippet
{
    /// <summary>
    /// The channel that the video category is associated with.
    /// </summary>
    public string? ChannelId { get; set; }

    /// <summary>
    /// The video category title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Indicates whether the category can be associated with a video.
    /// </summary>
    public bool? Assignable { get; set; }
}
