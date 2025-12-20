// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

public class CommentThreadProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";
    public static readonly string AllThreadsRelatedToChannelIdKey = "allThreadsRelatedToChannelIdKey";
    public static readonly string IdKey = "id";
    public static readonly string VideoIdKey = "videoId";
    public static readonly string MaxResultsKey = "maxResults";
    public static readonly string ModerationStatusKey = "moderationStatus";
    public static readonly string OrderKey = "order";
    public static readonly string PageTokenKey = "pageToken";
    public static readonly string SearchTermsKey = "searchTerms";
    public static readonly string TextFormatKey = "textFormat";

    public CommentThreadProperties()
    { }

    public CommentThreadProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public CommentThreadProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }

    public string? AllThreadsRelatedToChannelId
    {
        get => GetParameter<string>(AllThreadsRelatedToChannelIdKey);
        set => SetParameter(AllThreadsRelatedToChannelIdKey, value);
    }

    public StringValues? Id
    {
        get => GetParameter<string>(IdKey);
        set => SetParameter(IdKey, value);
    }

    public string? VideoId
    {
        get => GetParameter<string>(VideoIdKey);
        set => SetParameter(VideoIdKey, value);
    }

    public uint? MaxResults
    {
        get => GetParameter<uint>(MaxResultsKey);
        set => SetParameter(MaxResultsKey, value);
    }

    public CommentThreadModerationStatus? ModerationStatus
    {
        get => GetParameter<CommentThreadModerationStatus>(ModerationStatusKey);
        set => SetParameter(ModerationStatusKey, value);
    }

    public CommentThreadOrder? Order
    {
        get => GetParameter<CommentThreadOrder>(OrderKey);
        set => SetParameter(OrderKey, value);
    }

    public string? PageToken
    {
        get => GetParameter<string>(PageTokenKey);
        set => SetParameter(PageTokenKey, value);
    }

    public string? SearchTerms
    {
        get => GetParameter<string>(SearchTermsKey);
        set => SetParameter(SearchTermsKey, value);
    }

    public string? TextFormat
    {
        get => GetParameter<string>(TextFormatKey);
        set => SetParameter(TextFormatKey, value);
    }
}