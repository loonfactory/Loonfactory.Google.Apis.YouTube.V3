// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class MemberResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public MemberSnippet? Snippet { get; set; }
}