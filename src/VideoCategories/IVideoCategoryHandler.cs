// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <summary>
/// Defines a contract for a handler of video category operations.
/// </summary>
public interface IVideoCategoryHandler : IYouTubeHandler
{
    /// <summary>
    /// Sends a request to retrieve video categories.
    /// </summary>
    /// <param name="properties">The request properties.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The result containing the video category list response.</returns>
    Task<YouTubeResult<VideoCategoryListResponse>> HandleVideoCategoryListAsync(
        VideoCategoryProperties properties,
        CancellationToken cancellationToken);
}
