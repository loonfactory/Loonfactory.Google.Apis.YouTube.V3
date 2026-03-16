// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public static class VideoDefaults
{
    private const string ApiRootUrl = "https://www.googleapis.com/youtube/v3";
    private const string UploadRootUrl = "https://www.googleapis.com/upload/youtube/v3";

    public static readonly string ListEndpoint = $"{ApiRootUrl}/videos";
    public static readonly string InsertEndpoint = $"{UploadRootUrl}/videos";
    public static readonly string UpdateEndpoint = $"{UploadRootUrl}/videos";
    public static readonly string DeleteEndpoint = $"{ApiRootUrl}/videos";
    public static readonly string RateEndpoint = $"{ApiRootUrl}/videos/rate";
    public static readonly string GetRatingEndpoint = $"{ApiRootUrl}/videos/getRating";
    public static readonly string ReportAbuseEndpoint = $"{ApiRootUrl}/videos/reportAbuse";
}
