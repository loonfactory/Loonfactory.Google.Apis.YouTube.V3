// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public class YouTubeI18nRegionProperties : YouTubeProperties
{
    public static readonly string PartsKey = "parts";

    public static readonly string Hlkey = "hl";

    public YouTubeI18nRegionProperties()
    { }

    public YouTubeI18nRegionProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public YouTubeI18nRegionProperties(IDictionary<string, string?> items, IDictionary<string, StringValues> parameters)
        : base(items, parameters)
    { }

    public string?[]? Parts
    {
        get => GetParameter<string?[]>(PartsKey);
        set => SetParameter(PartsKey, value);
    }

    public string? Hl
    {
        get => GetParameter<string>(Hlkey);
        set => SetParameter(Hlkey, value);
    }
}