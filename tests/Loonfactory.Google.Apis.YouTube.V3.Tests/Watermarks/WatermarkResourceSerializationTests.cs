// Licensed under the MIT license by loonfactory.

using System.Text.Json;
using Loonfactory.Google.Apis.YouTube.V3.Watermarks;

namespace Loonfactory.Google.Apis.YouTube.V3;

public sealed class WatermarkResourceSerializationTests
{
    [Fact]
    public void Serialize_DoesNotIncludeImageBytes()
    {
        var resource = new WatermarkResource
        {
            TargetChannelId = "UC_TARGET",
            ImageBytes = [0x41, 0x42, 0x43],
            Position = new WatermarkPosition
            {
                Type = "corner",
                CornerPosition = "topRight"
            },
            Timing = new WatermarkTiming
            {
                Type = "offsetFromStart",
                OffsetMs = 0,
                DurationMs = 5000
            }
        };

        var json = JsonSerializer.Serialize(resource, YouTubeDefaults.JsonSerializerOptions);

        Assert.Contains("\"targetChannelId\":\"UC_TARGET\"", json, StringComparison.Ordinal);
        Assert.DoesNotContain("imageBytes", json, StringComparison.Ordinal);
    }
}
