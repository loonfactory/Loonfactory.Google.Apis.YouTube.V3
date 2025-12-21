// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public class PlaylistImageProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";
    public static readonly string IdKey = "id";
    public static readonly string PlaylistIdKey = "playlistId";
    public static readonly string MaxResultsKey = "maxResults";
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";
    public static readonly string OnBehalfOfContentOwnerChannelKey = "onBehalfOfContentOwnerChannel";
    public static readonly string PageTokenKey = "pageToken";

    public PlaylistImageProperties()
    { }

    public PlaylistImageProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public PlaylistImageProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }

    public string? Id
    {
        get => GetParameter<string>(IdKey);
        set => SetParameter(IdKey, value);
    }

    public string? PlaylistId
    {
        get => GetParameter<string>(PlaylistIdKey);
        set => SetParameter(PlaylistIdKey, value);
    }

    public uint? MaxResults
    {
        get => GetParameter<uint>(MaxResultsKey);
        set => SetParameter(MaxResultsKey, value);
    }

    /// <summary>
    /// The "onBehalfOfContentOwner" parameter value being used for a challenge request.
    /// </summary>
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
}