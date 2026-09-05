// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class I18nLanguageProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";

    public static readonly string Hlkey = "hl";

    public I18nLanguageProperties()
    { }

    public I18nLanguageProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public I18nLanguageProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
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
