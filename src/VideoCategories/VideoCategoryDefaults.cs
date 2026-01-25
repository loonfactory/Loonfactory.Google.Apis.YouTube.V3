// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <summary>
/// Provides defaults for video category operations.
/// </summary>
public static class VideoCategoryDefaults
{
    private const string ApiRootUrl = "https://www.googleapis.com/youtube/v3";

    /// <summary>
    /// Endpoint URL for listing video categories.
    /// </summary>
    public static readonly string ListEndpoint = $"{ApiRootUrl}/videoCategories";
}
