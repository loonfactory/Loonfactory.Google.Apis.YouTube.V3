// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class YouTubeI18nLanguageProperties : YouTubeProperties
{
    public static readonly string PartsKey = "parts";

    public static readonly string Hlkey = "hl";

    public YouTubeI18nLanguageProperties()
    { }

    public YouTubeI18nLanguageProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public YouTubeI18nLanguageProperties(IDictionary<string, string?> items, IDictionary<string, StringValues> parameters)
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