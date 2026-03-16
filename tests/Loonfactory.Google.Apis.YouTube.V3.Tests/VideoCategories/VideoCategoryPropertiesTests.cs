// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.VideoCategories;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3;

public sealed class VideoCategoryPropertiesTests
{
    [Fact]
    public void Constructor_WithItems_UsesProvidedItemsDictionary()
    {
        var items = new Dictionary<string, string?>
        {
            ["state"] = "value"
        };

        var properties = new VideoCategoryProperties(items);

        Assert.Same(items, properties.Items);
        Assert.Equal("value", properties.Items["state"]);
    }

    [Fact]
    public void Constructor_WithItemsAndParameters_UsesProvidedDictionaries()
    {
        var items = new Dictionary<string, string?>();
        var parameters = new Dictionary<string, object?>
        {
            [VideoCategoryProperties.PartKey] = new StringValues("snippet")
        };

        var properties = new VideoCategoryProperties(items, parameters);

        Assert.Same(items, properties.Items);
        Assert.Same(parameters, properties.Parameters);
    }

    [Fact]
    public void Part_RoundTripsValue()
    {
        var properties = new VideoCategoryProperties();

        properties.Part = new StringValues(["snippet", "id"]);

        Assert.Equal(new[] { "snippet", "id" }, properties.Part!.Value.ToArray());
    }

    [Fact]
    public void Hl_RoundTripsValue()
    {
        var properties = new VideoCategoryProperties();

        properties.Hl = "ko";

        Assert.Equal("ko", properties.Hl);
    }

    [Fact]
    public void Id_RoundTripsValue()
    {
        var properties = new VideoCategoryProperties();

        properties.Id = new StringValues(["1", "2"]);

        Assert.Equal(new[] { "1", "2" }, properties.Id!.Value.ToArray());
    }

    [Fact]
    public void RegionCode_RoundTripsValue()
    {
        var properties = new VideoCategoryProperties();

        properties.RegionCode = "KR";

        Assert.Equal("KR", properties.RegionCode);
    }
}
