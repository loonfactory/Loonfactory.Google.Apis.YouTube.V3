// Licensed under the MIT license by loonfactory.

using System.Net.Mime;

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

public static class ThumbnailDefaults
{
    private const string UploadApiRootUrl = "https://www.googleapis.com/upload/youtube/v3";

    /// <summary>
    /// Endpoint URL for setting thumbnails.
    /// </summary>
    public static readonly string SetEndpoint = $"{UploadApiRootUrl}/thumbnails/set";

    /// <summary>
    /// Allowed upload content types for thumbnail requests.
    /// </summary>
    public static readonly IReadOnlySet<string> AllowedUploadContentTypes =
        new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            MediaTypeNames.Image.Jpeg,
            MediaTypeNames.Image.Png,
            MediaTypeNames.Application.Octet,
        };
}
