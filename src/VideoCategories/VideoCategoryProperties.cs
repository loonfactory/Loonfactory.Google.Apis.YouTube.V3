// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <summary>
/// Provides parameters for video category requests.
/// </summary>
public class VideoCategoryProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";
    public static readonly string HlKey = "hl";
    public static readonly string IdKey = "id";
    public static readonly string RegionCodeKey = "regionCode";

    public VideoCategoryProperties()
    { }

    public VideoCategoryProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public VideoCategoryProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// Gets or sets the resource parts to include in the response.
    /// </summary>
    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }

    /// <summary>
    /// Gets or sets the language for text values in the response.
    /// </summary>
    public string? Hl
    {
        get => GetParameter<string>(HlKey);
        set => SetParameter(HlKey, value);
    }

    /// <summary>
    /// Gets or sets the video category ids to retrieve.
    /// </summary>
    public StringValues? Id
    {
        get => GetParameter<StringValues>(IdKey);
        set => SetParameter(IdKey, value);
    }

    /// <summary>
    /// Gets or sets the region for which to retrieve categories.
    /// </summary>
    public string? RegionCode
    {
        get => GetParameter<string>(RegionCodeKey);
        set => SetParameter(RegionCodeKey, value);
    }
}
