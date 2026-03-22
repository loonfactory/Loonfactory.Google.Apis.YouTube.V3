// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Watermarks;

namespace Loonfactory.Google.Apis.YouTube.V3;

public sealed class WatermarkPropertiesTests
{
    [Fact]
    public void Constructor_WithItems_UsesProvidedItemsDictionary()
    {
        var items = new Dictionary<string, string?>
        {
            ["state"] = "value"
        };

        var properties = new WatermarkProperties(items);

        Assert.Same(items, properties.Items);
        Assert.Equal("value", properties.Items["state"]);
    }

    [Fact]
    public void Constructor_WithItemsAndParameters_UsesProvidedDictionaries()
    {
        var items = new Dictionary<string, string?>();
        var parameters = new Dictionary<string, object?>
        {
            [WatermarkProperties.ChannelIdKey] = "UC123"
        };

        var properties = new WatermarkProperties(items, parameters);

        Assert.Same(items, properties.Items);
        Assert.Same(parameters, properties.Parameters);
    }

    [Fact]
    public void ChannelId_RoundTripsValue()
    {
        var properties = new WatermarkProperties
        {
            ChannelId = "UC123"
        };

        Assert.Equal("UC123", properties.ChannelId);
    }

    [Fact]
    public void OnBehalfOfContentOwner_RoundTripsValue()
    {
        var properties = new WatermarkProperties
        {
            OnBehalfOfContentOwner = "content-owner-id"
        };

        Assert.Equal("content-owner-id", properties.OnBehalfOfContentOwner);
    }
}
