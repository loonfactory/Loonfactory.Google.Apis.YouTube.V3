// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Contains the metadata returned by a caption list request.
/// </summary>
/// <remarks>The items contain metadata only. Caption text is retrieved through the download operation.</remarks>
/// <seealso href="https://developers.google.com/youtube/v3/docs/captions/list" />
public class CaptionListResponse
{
    /// <summary>
    /// Gets or sets the response kind, <c>youtube#captionListResponse</c>.
    /// </summary>
    public string? Kind { get; set; }
    /// <summary>
    /// Gets or sets the response entity tag.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }
    /// <summary>
    /// Gets or sets the returned caption resources.
    /// </summary>
    public IEnumerable<CaptionResource>? Items { get; set; }
}
