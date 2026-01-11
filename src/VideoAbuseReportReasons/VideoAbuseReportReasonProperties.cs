// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;

public class VideoAbuseReportReasonProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";
    public static readonly string HlKey = "hl";
    public static readonly string IdKey = "id";

    public VideoAbuseReportReasonProperties()
    { }

    public VideoAbuseReportReasonProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public VideoAbuseReportReasonProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }

    public string? Hl
    {
        get => GetParameter<string>(HlKey);
        set => SetParameter(HlKey, value);
    }

    public StringValues? Id
    {
        get => GetParameter<StringValues>(IdKey);
        set => SetParameter(IdKey, value);
    }
}
