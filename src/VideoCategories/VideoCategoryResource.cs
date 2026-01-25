// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <summary>
/// Represents a videoCategory resource.
/// </summary>
public class VideoCategoryResource
{
    /// <summary>
    /// The type of the API resource.
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// The ETag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    /// <summary>
    /// The ID that YouTube uses to uniquely identify the video category.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The snippet for the video category.
    /// </summary>
    public VideoCategorySnippet? Snippet { get; set; }
}
