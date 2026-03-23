// Licensed under the MIT license by loonfactory.

using System.Net.Mime;

namespace Loonfactory.Google.Apis.YouTube.V3.Watermarks;

/// <summary>
/// Provides defaults for watermark operations.
/// </summary>
public static class WatermarkDefaults
{
    private const string ApiRootUrl = "https://www.googleapis.com/youtube/v3";
    private const string UploadApiRootUrl = "https://www.googleapis.com/upload/youtube/v3";

    /// <summary>
    /// Endpoint URL for setting watermarks using metadata-only JSON requests.
    /// </summary>
    public static readonly string SetEndpoint = $"{ApiRootUrl}/watermarks/set";

    /// <summary>
    /// Endpoint URL for setting watermarks using media upload requests.
    /// </summary>
    public static readonly string SetUploadEndpoint = $"{UploadApiRootUrl}/watermarks/set";

    /// <summary>
    /// Endpoint URL for unsetting watermarks.
    /// </summary>
    public static readonly string UnsetEndpoint = $"{ApiRootUrl}/watermarks/unset";

    /// <summary>
    /// Allowed upload content types for watermark requests.
    /// </summary>
    public static readonly IReadOnlySet<string> AllowedUploadContentTypes =
        new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            MediaTypeNames.Image.Jpeg,
            MediaTypeNames.Image.Png,
            MediaTypeNames.Application.Octet,
        };
}
