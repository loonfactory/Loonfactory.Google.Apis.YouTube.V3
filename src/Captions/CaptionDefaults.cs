// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Defines endpoints for YouTube caption operations.
/// </summary>
public static class CaptionDefaults
{
    private const string ApiRootUrl = "https://www.googleapis.com/youtube/v3";
    private const string UploadRootUrl = "https://www.googleapis.com/upload/youtube/v3";
    /// <summary>
    /// The endpoint for caption list requests.
    /// </summary>
    public static readonly string ListEndpoint = $"{ApiRootUrl}/captions";

    /// <summary>
    /// The endpoint for caption insert requests.
    /// </summary>
    public static readonly string InsertEndpoint = $"{UploadRootUrl}/captions";

    /// <summary>
    /// The endpoint for caption update requests.
    /// </summary>
    public static readonly string UpdateEndpoint = $"{UploadRootUrl}/captions";

    /// <summary>
    /// The endpoint for caption download requests.
    /// </summary>
    public static readonly string DownloadEndpoint = $"{ApiRootUrl}/captions/";

    /// <summary>
    /// The endpoint for caption delete requests.
    /// </summary>
    public static readonly string DeleteEndpoint = $"{ApiRootUrl}/captions";
}
