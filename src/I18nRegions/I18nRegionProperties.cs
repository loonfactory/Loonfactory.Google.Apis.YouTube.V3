// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public class I18nRegionProperties : YouTubeProperties
{
    public static readonly string PartsKey = "parts";

    public static readonly string Hlkey = "hl";

    public I18nRegionProperties()
    { }

    public I18nRegionProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public I18nRegionProperties(IDictionary<string, string?> items, IDictionary<string, StringValues?> parameters)
        : base(items, (IDictionary<string, object?>)parameters)
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