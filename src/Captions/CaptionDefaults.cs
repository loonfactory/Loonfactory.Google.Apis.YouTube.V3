// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

public static class CaptionDefaults
{
    private const string ApiRootUrl = "https://www.googleapis.com/youtube/v3";
    private const string UploadRootUrl = "https://www.googleapis.com/upload/youtube/v3";
    /// <summary>
    /// Endpoint URL for listing captions.
    /// </summary>
    public static readonly string ListEndpoint = $"{ApiRootUrl}/captions";

    /// <summary>
    /// Endpoint URL for inserting new captions.
    /// </summary>
    public static readonly string InsertEndpoint = $"{UploadRootUrl}/captions";

    /// <summary>
    /// Endpoint URL for updating existing captions.
    /// </summary>
    public static readonly string UpdateEndpoint = $"{UploadRootUrl}/captions";

    /// <summary>
    /// Endpoint URL for downloading captions.
    /// </summary>
    public static readonly string DownloadEndpoint = $"{ApiRootUrl}/captions/";

    /// <summary>
    /// Endpoint URL for deleting captions.
    /// </summary>
    public static readonly string DeleteEndpoint = $"{ApiRootUrl}/captions";
}