// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3;

public abstract class YouTubeListResource<T>
{
    public virtual string? Kind { get; set; }

    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public virtual string? ETag { get; set; }

    public virtual IEnumerable<T>? Items { get; set; }
}