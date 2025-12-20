// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public class MembershipsLevelResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? Id { get; set; }

}