// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// A YouTubeCaptionResource represents a YouTube caption track.
/// A caption track is associated with exactly one YouTube video.
/// </summary>
public class CaptionResource
{
    /// <summary>
    /// Identifies the API resource's type.
    /// The value will be <c>"youtube#caption"</c>.
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    /// <summary>
    /// The ID that YouTube uses to uniquely identify the caption track.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The snippet object contains basic details about the caption.
    /// </summary>
    public CaptionSnippet? Snippet { get; set; }
}