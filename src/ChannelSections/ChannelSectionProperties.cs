// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

/// <summary>
/// <see cref="YouTubeProperties"/> for a YouTube ChannelSection challenge.
/// </summary>
public class ChannelSectionProperties : YouTubeProperties
{

    public static readonly string PartKey = "part";

    public static readonly string ChannelIdKey = "channelId";

    public static readonly string IdKey = "id";

    public static readonly string MineKey = "mine";

    /// <summary>
    /// The parameter key for the "onBehalfOfContentOwner" argument being used for a challenge request.
    /// </summary>
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";
    public static readonly string OnBehalfOfContentOwnerChannelKey = "onBehalfOfContentOwnerChannel";

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelSectionProperties"/>.
    /// </summary>
    public ChannelSectionProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelSectionProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public ChannelSectionProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelSectionProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public ChannelSectionProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public string? Id
    {
        get => GetParameter<string>(IdKey);
        set => SetParameter(IdKey, value);
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
    
    public string? ChannelId
    {
        get => GetParameter<string>(ChannelIdKey);
        set => SetParameter(ChannelIdKey, value);
    }

    public string[]? Mine
    {
        get => GetParameter<string[]>(MineKey);
        set => SetParameter(MineKey, value);
    }

    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }
}