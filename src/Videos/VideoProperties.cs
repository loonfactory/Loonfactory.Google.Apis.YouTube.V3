// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideoProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";
    public static readonly string ChartKey = "chart";
    public static readonly string HlKey = "hl";
    public static readonly string IdKey = "id";
    public static readonly string MaxHeightKey = "maxHeight";
    public static readonly string MaxResultsKey = "maxResults";
    public static readonly string MaxWidthKey = "maxWidth";
    public static readonly string MyRatingKey = "myRating";
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";
    public static readonly string OnBehalfOfContentOwnerChannelKey = "onBehalfOfContentOwnerChannel";
    public static readonly string PageTokenKey = "pageToken";
    public static readonly string RegionCodeKey = "regionCode";
    public static readonly string VideoCategoryIdKey = "videoCategoryId";
    public static readonly string AutoLevelsKey = "autoLevels";
    public static readonly string NotifySubscribersKey = "notifySubscribers";
    public static readonly string RatingKey = "rating";

    public VideoProperties()
    { }

    public VideoProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public VideoProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }

    public string? Chart
    {
        get => GetParameter<string>(ChartKey);
        set => SetParameter(ChartKey, value);
    }

    public string? Hl
    {
        get => GetParameter<string>(HlKey);
        set => SetParameter(HlKey, value);
    }

    public StringValues Id
    {
        get => GetParameter<StringValues>(IdKey);
        set => SetParameter(IdKey, value);
    }

    public uint? MaxHeight
    {
        get => GetParameter<uint?>(MaxHeightKey);
        set => SetParameter(MaxHeightKey, value);
    }

    public uint? MaxResults
    {
        get => GetParameter<uint?>(MaxResultsKey);
        set => SetParameter(MaxResultsKey, value);
    }

    public uint? MaxWidth
    {
        get => GetParameter<uint?>(MaxWidthKey);
        set => SetParameter(MaxWidthKey, value);
    }

    public string? MyRating
    {
        get => GetParameter<string>(MyRatingKey);
        set => SetParameter(MyRatingKey, value);
    }

    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(OnBehalfOfContentOwnerKey);
        set => SetParameter(OnBehalfOfContentOwnerKey, value);
    }

    public string? OnBehalfOfContentOwnerChannel
    {
        get => GetParameter<string>(OnBehalfOfContentOwnerChannelKey);
        set => SetParameter(OnBehalfOfContentOwnerChannelKey, value);
    }

    public string? PageToken
    {
        get => GetParameter<string>(PageTokenKey);
        set => SetParameter(PageTokenKey, value);
    }

    public string? RegionCode
    {
        get => GetParameter<string>(RegionCodeKey);
        set => SetParameter(RegionCodeKey, value);
    }

    public string? VideoCategoryId
    {
        get => GetParameter<string>(VideoCategoryIdKey);
        set => SetParameter(VideoCategoryIdKey, value);
    }

    public bool? AutoLevels
    {
        get => GetParameter<bool?>(AutoLevelsKey);
        set => SetParameter(AutoLevelsKey, value);
    }

    public bool? NotifySubscribers
    {
        get => GetParameter<bool?>(NotifySubscribersKey);
        set => SetParameter(NotifySubscribersKey, value);
    }

    public string? Rating
    {
        get => GetParameter<string>(RatingKey);
        set => SetParameter(RatingKey, value);
    }
}
