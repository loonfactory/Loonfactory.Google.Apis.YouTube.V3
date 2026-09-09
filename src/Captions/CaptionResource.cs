// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Represents caption metadata used in requests and responses.
/// </summary>
/// <remarks>Each track belongs to one video. Members may be absent in partial responses or requests; required fields depend on the operation.</remarks>
/// <seealso href="https://developers.google.com/youtube/v3/docs/captions" />
public class CaptionResource
{
    /// <summary>
    /// Gets or sets the resource kind, <c>youtube#caption</c>.
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// Gets or sets the resource entity tag.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    /// <summary>
    /// Gets or sets the caption identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the selected caption metadata.
    /// </summary>
    public CaptionSnippet? Snippet { get; set; }
}
