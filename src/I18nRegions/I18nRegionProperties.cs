// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public class I18nRegionProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";

    public static readonly string Hlkey = "hl";

    public I18nRegionProperties()
    { }

    public I18nRegionProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public I18nRegionProperties(IDictionary<string, string?> items, IDictionary<string, StringValues?> parameters)
        : base(items, (IDictionary<string, object?>)parameters)
    { }

    public string?[]? Part
    {
        get => GetParameter<string?[]>(PartKey);
        set => SetParameter(PartKey, value);
    }

    public string? Hl
    {
        get => GetParameter<string>(Hlkey);
        set => SetParameter(Hlkey, value);
    }
}
