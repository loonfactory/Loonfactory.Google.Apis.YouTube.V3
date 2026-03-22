// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Videos;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3;

public sealed class VideoPropertiesTests
{
    [Fact]
    public void Constructor_WithItems_UsesProvidedItemsDictionary()
    {
        var items = new Dictionary<string, string?>
        {
            ["state"] = "value"
        };

        var properties = new VideoProperties(items);

        Assert.Same(items, properties.Items);
        Assert.Equal("value", properties.Items["state"]);
    }

    [Fact]
    public void Constructor_WithItemsAndParameters_UsesProvidedDictionaries()
    {
        var items = new Dictionary<string, string?>();
        var parameters = new Dictionary<string, object?>
        {
            [VideoProperties.PartKey] = new StringValues("snippet")
        };

        var properties = new VideoProperties(items, parameters);

        Assert.Same(items, properties.Items);
        Assert.Same(parameters, properties.Parameters);
    }

    [Fact]
    public void Part_RoundTripsValue()
    {
        var properties = new VideoProperties();

        properties.Part = "snippet";

        Assert.Equal("snippet", properties.Part.ToString());
    }

    [Fact]
    public void Id_RoundTripsValue()
    {
        var properties = new VideoProperties();

        properties.Id = "abc123";

        Assert.Equal("abc123", properties.Id.ToString());
    }

    [Fact]
    public void Chart_RoundTripsValue()
    {
        var properties = new VideoProperties();

        properties.Chart = "mostPopular";

        Assert.Equal("mostPopular", properties.Chart);
    }

    [Fact]
    public void NotifySubscribers_RoundTripsValue()
    {
        var properties = new VideoProperties();

        properties.NotifySubscribers = true;

        Assert.True(properties.NotifySubscribers);
    }
}
