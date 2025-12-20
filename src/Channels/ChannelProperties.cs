// Licensed under the MIT license by loonfactory.

using System.Globalization;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Channels;

public class ChannelProperties : YouTubeProperties
{

    /// <summary>
    /// The parameter key for the "onBehalfOfContentOwner" argument being used for a challenge request.
    /// </summary>
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";
    public static readonly string PartKey = "part";
    public static readonly string ForHandleKey = "forHandle";
    public static readonly string ForUsernameKey = "forUsername";
    public static readonly string IdKey = "id";
    public static readonly string ManagedByMeKey = "managedByMe";
    public static readonly string MineKey = "mine";
    public static readonly string HlKey = "hl";
    public static readonly string MaxResultsKey = "maxResults";
    public static readonly string PageTokenKey = "pageToken";

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelProperties"/>.
    /// </summary>
    public ChannelProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public ChannelProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public ChannelProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// The "onBehalfOfContentOwner" parameter value being used for a challenge request.
    /// </summary>
    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(OnBehalfOfContentOwnerKey);
        set => SetParameter(OnBehalfOfContentOwnerKey, value);
    }

    public StringValues? Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }

    public string? ForHandle
    {
        get => GetParameter<string>(ForHandleKey);
        set => SetParameter(ForHandleKey, value);
    }

    public string? ForUsername
    {
        get => GetParameter<string>(ForUsernameKey);
        set => SetParameter(ForUsernameKey, value);
    }

    public string? Id
    {
        get => GetParameter<string>(IdKey);
        set => SetParameter(IdKey, value);
    }

    public bool? ManagedByMe
    {
        get => GetParameter<bool?>(ManagedByMeKey);
        set => SetParameter(ManagedByMeKey, value);
    }

    public bool? Mine
    {
        get => GetParameter<bool?>(MineKey);
        set => SetParameter(MineKey, value);
    }

    public string? Hl
    {
        get => GetParameter<string>(HlKey);
        set => SetParameter(HlKey, value);
    }

    public int? MaxResults
    {
        get => GetParameter<int?>(MaxResultsKey);
        set => SetParameter(MaxResultsKey, value?.ToString(CultureInfo.InvariantCulture));
    }

    public string? PageToken
    {
        get => GetParameter<string>(PageTokenKey);
        set => SetParameter(PageTokenKey, value);
    }
}