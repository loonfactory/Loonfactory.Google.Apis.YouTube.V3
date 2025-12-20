// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public class PlaylistProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";
    public static readonly string ChannelIdKey = "channelId";
    public static readonly string IdKey = "id";
    public static readonly string MineKey = "mine";
    public static readonly string hlKey = "hl";
    public static readonly string MaxResultsKey = "maxResults";
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";
    public static readonly string OnBehalfOfContentOwnerChannelKey = "onBehalfOfContentOwnerChannel";
    public static readonly string PageTokenKey = "pageToken";

    public PlaylistProperties()
    { }

    public PlaylistProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public PlaylistProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }
    
    public string? ChannelId
    {
        get => GetParameter<string>(ChannelIdKey);
        set => SetParameter(ChannelIdKey, value);
    }
    public string? Id
    {
        get => GetParameter<string>(IdKey);
        set => SetParameter(IdKey, value);
    }

    public bool? Mine
    {
        get => GetParameter<bool>(MineKey);
        set => SetParameter(MineKey, value);
    }

    public string? Hl
    {
        get => GetParameter<string>(hlKey);
        set => SetParameter(hlKey, value);
    }

    public uint? MaxResults
    {
        get => GetParameter<uint>(MaxResultsKey);
        set => SetParameter(MaxResultsKey, value);
    }

    public string? PageToken
    {
        get => GetParameter<string>(PageTokenKey);
        set => SetParameter(PageTokenKey, value);
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
}
