// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Searchs;

public class SearchProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";
    public static readonly string ChannelIdKey = "channelId";
    public static readonly string ForContentOwnerKey = "forContentOwner";
    public static readonly string ForDeveloperKey = "forDeveloper";
    public static readonly string ForMineKey = "forMine";
    public static readonly string ChannelTypeKey = "channelType";
    public static readonly string EventTypeKey = "eventType";
    public static readonly string LocationKey = "location";
    public static readonly string LocationRadiusKey = "locationRadius";
    public static readonly string MaxResultsKey = "maxResults";
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";
    public static readonly string OrderKey = "order";
    public static readonly string PageTokenKey = "pageToken";
    public static readonly string PublishedAfterKey = "publishedAfter";
    public static readonly string PublishedBeforeKey = "publishedBefore";
    public static readonly string QKey = "q";
    public static readonly string RegionCodeKey = "regionCode";
    public static readonly string RelevanceLanguageKey = "relevanceLanguage";
    public static readonly string SafeSearchKey = "safeSearch";
    public static readonly string TopicIdKey = "topicId";
    public static readonly string TypeKey = "type";
    public static readonly string VideoCaptionKey = "videoCaption";
    public static readonly string VideoCategoryIdKey = "videoCategoryId";
    public static readonly string VideoDefinitionKey = "videoDefinition";
    public static readonly string VideoDimensionKey = "videoDimension";
    public static readonly string VideoDurationKey = "videoDuration";
    public static readonly string VideoEmbeddableKey = "videoEmbeddable";
    public static readonly string VideoLicenseKey = "videoLicense";

    public SearchProperties()
    { }

    public SearchProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public SearchProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }

    public StringValues? ChannelId
    {
        get => GetParameter<StringValues>(ChannelIdKey);
        set => SetParameter(ChannelIdKey, value);
    }

    public string? ForContentOwner
    {
        get => GetParameter<string>(ForContentOwnerKey);
        set => SetParameter(ForContentOwnerKey, value);
    }

    public string? ForDeveloper
    {
        get => GetParameter<string>(ForDeveloperKey);
        set => SetParameter(ForDeveloperKey, value);
    }

    public bool? ForMine
    {
        get => GetParameter<bool>(ForMineKey);
        set => SetParameter(ForMineKey, value);
    }

    public string? ChannelType
    {
        get => GetParameter<string>(ChannelTypeKey);
        set => SetParameter(ChannelTypeKey, value);
    }

    public string? EventType
    {
        get => GetParameter<string>(EventTypeKey);
        set => SetParameter(EventTypeKey, value);
    }

    public string? Location
    {
        get => GetParameter<string>(LocationKey);
        set => SetParameter(LocationKey, value);
    }

    public string? LocationRadius
    {
        get => GetParameter<string>(LocationRadiusKey);
        set => SetParameter(LocationRadiusKey, value);
    }

    public uint? MaxResults
    {
        get => GetParameter<uint>(MaxResultsKey);
        set => SetParameter(MaxResultsKey, value);
    }

    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(OnBehalfOfContentOwnerKey);
        set => SetParameter(OnBehalfOfContentOwnerKey, value);
    }

    public string? Order
    {
        get => GetParameter<string>(OrderKey);
        set => SetParameter(OrderKey, value);
    }

    public string? PageToken
    {
        get => GetParameter<string>(PageTokenKey);
        set => SetParameter(PageTokenKey, value);
    }

    public DateTimeOffset? PublishedAfter
    {
        get => GetParameter<DateTimeOffset>(PublishedAfterKey);
        set => SetParameter(PublishedAfterKey, value);
    }

    public DateTimeOffset? PublishedBefore
    {
        get => GetParameter<DateTimeOffset>(PublishedBeforeKey);
        set => SetParameter(PublishedBeforeKey, value);
    }

    public string? Q
    {
        get => GetParameter<string>(QKey);
        set => SetParameter(QKey, value);
    }

    public string? RegionCode
    {
        get => GetParameter<string>(RegionCodeKey);
        set => SetParameter(RegionCodeKey, value);
    }

    public string? RelevanceLanguage
    {
        get => GetParameter<string>(RelevanceLanguageKey);
        set => SetParameter(RelevanceLanguageKey, value);
    }

    public string? SafeSearch
    {
        get => GetParameter<string>(SafeSearchKey);
        set => SetParameter(SafeSearchKey, value);
    }

    public StringValues? TopicId
    {
        get => GetParameter<StringValues>(TopicIdKey);
        set => SetParameter(TopicIdKey, value);
    }

    public string? Type
    {
        get => GetParameter<string>(TypeKey);
        set => SetParameter(TypeKey, value);
    }

    public string? VideoCaption
    {
        get => GetParameter<string>(VideoCaptionKey);
        set => SetParameter(VideoCaptionKey, value);
    }

    public string? VideoCategoryId
    {
        get => GetParameter<string>(VideoCategoryIdKey);
        set => SetParameter(VideoCategoryIdKey, value);
    }

    public string? VideoDefinition
    {
        get => GetParameter<string>(VideoDefinitionKey);
        set => SetParameter(VideoDefinitionKey, value);
    }

    public string? VideoDimension
    {
        get => GetParameter<string?>(VideoDimensionKey);
        set => SetParameter(VideoDimensionKey, value);
    }

    public string? VideoDuration
    {
        get => GetParameter<string>(VideoDurationKey);
        set => SetParameter(VideoDurationKey, value);
    }

    public string? VideoEmbeddable
    {
        get => GetParameter<string>(VideoEmbeddableKey);
        set => SetParameter(VideoEmbeddableKey, value);
    }

    public string? VideoLicense
    {
        get => GetParameter<string>(VideoLicenseKey);
        set => SetParameter(VideoLicenseKey, value);
    }
}
