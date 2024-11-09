// Licensed under the MIT license by loonfactory.

using System.Text.Json;

namespace Loonfactory.Google.Apis.YouTube.V3;

public static class YouTubeDefaults
{
    public static JsonSerializerOptions JsonSerializerOptions { get; } = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
}