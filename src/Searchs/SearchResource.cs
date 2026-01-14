// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Searchs;

/// <summary>
/// </summary>
public class SearchResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public YouTubeResourceId? Id { get; set; }

    public SearchSnippet? Snippet { get; set; }
}
