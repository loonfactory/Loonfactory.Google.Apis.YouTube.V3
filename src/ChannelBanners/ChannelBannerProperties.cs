// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

public class ChannelBannerProperties : YouTubeProperties
{

    /// <summary>
    /// The parameter key for the "onBehalfOfContentOwner" argument being used for a challenge request.
    /// </summary>
    public static readonly string onBehalfOfContentOwnerKey = "onBehalfOfContentOwner";

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelBannerProperties"/>.
    /// </summary>
    public ChannelBannerProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelBannerProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public ChannelBannerProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ChannelBannerProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public ChannelBannerProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// The "onBehalfOfContentOwner" parameter value being used for a challenge request.
    /// </summary>
    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(onBehalfOfContentOwnerKey);
        set => SetParameter(onBehalfOfContentOwnerKey, value);
    }
}