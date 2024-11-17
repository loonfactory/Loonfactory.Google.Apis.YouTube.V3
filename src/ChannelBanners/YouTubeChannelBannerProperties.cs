// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

public class YouTubeChannelBannerProperties : YouTubeProperties
{

    /// <summary>
    /// The parameter key for the "onBehalfOfContentOwner" argument being used for a challenge request.
    /// </summary>
    public static readonly string onBehalfOfContentOwnerKey = "onBehalfOfContentOwner";

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeChannelBannerProperties"/>.
    /// </summary>
    public YouTubeChannelBannerProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeChannelBannerProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public YouTubeChannelBannerProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeChannelBannerProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public YouTubeChannelBannerProperties(IDictionary<string, string?> items, IDictionary<string, StringValues> parameters)
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