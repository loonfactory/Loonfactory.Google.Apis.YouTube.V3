// Licensed under the MIT license by loonfactory.

using System.Net.Mime;

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

public static class ThumbnailDefaults
{
    private const string UploadApiRootUrl = "https://www.googleapis.com/upload/youtube/v3";
    public static readonly string SetEndpoint = $"{UploadApiRootUrl}/thumbnails/set";

    public static readonly IReadOnlySet<string> AllowedUploadContentTypes =
        new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            MediaTypeNames.Image.Jpeg,        // "image/jpeg"
            MediaTypeNames.Image.Png,         // "image/png"
            MediaTypeNames.Application.Octet, // "application/octet-stream"
        };

}
