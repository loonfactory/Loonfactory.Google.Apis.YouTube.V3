// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class YouTubeMemberProperties : YouTubeProperties
{
    public static readonly string PartsKey = "part";
    public static readonly string ModeKey = "mode";
    public static readonly string MaxResultsKey = "maxResults";
    public static readonly string PageTokenKey = "pageToken";
    public static readonly string HasAccessToLevelKey = "hasAccessToLevel";
    public static readonly string FilterByMemberChannelIdKey = "filterByMemberChannelId";

    public YouTubeMemberProperties()
    { }

    public YouTubeMemberProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public YouTubeMemberProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues? Parts
    {
        get => GetParameter<string>(PartsKey);
        set => SetParameter(PartsKey, value);
    }

    public string? Mode
    {
        get => GetParameter<string>(ModeKey);
        set => SetParameter(ModeKey, value);
    }

    public ushort? MaxResults
    {
        get => GetParameter<ushort>(MaxResultsKey);
        set => SetParameter(MaxResultsKey, value);
    }

    public string? PageToken
    {
        get => GetParameter<string>(PageTokenKey);
        set => SetParameter(PageTokenKey, value);
    }

    public string? HasAccessToLevel
    {
        get => GetParameter<string>(HasAccessToLevelKey);
        set => SetParameter(HasAccessToLevelKey, value);
    }

    public string? FilterByMemberChannelId
    {
        get => GetParameter<string>(FilterByMemberChannelIdKey);
        set => SetParameter(FilterByMemberChannelIdKey, value);
    }
}