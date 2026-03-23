// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Watermarks;

/// <summary>
/// Represents parameters for watermark operations.
/// </summary>
public class WatermarkProperties : YouTubeProperties
{
    /// <summary>
    /// The parameter name for <see cref="ChannelId"/>.
    /// </summary>
    public static readonly string ChannelIdKey = "channelId";

    /// <summary>
    /// The parameter name for <see cref="OnBehalfOfContentOwner"/>.
    /// </summary>
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";

    /// <summary>
    /// Initializes a new instance of <see cref="WatermarkProperties"/>.
    /// </summary>
    public WatermarkProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="WatermarkProperties"/> with initial items.
    /// </summary>
    public WatermarkProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="WatermarkProperties"/> with initial items and parameters.
    /// </summary>
    public WatermarkProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// Gets or sets the YouTube channel ID for watermark operations.
    /// </summary>
    public string? ChannelId
    {
        get => GetParameter<string>(ChannelIdKey);
        set => SetParameter(ChannelIdKey, value);
    }

    /// <summary>
    /// Gets or sets the content owner on whose behalf the request is made.
    /// </summary>
    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(OnBehalfOfContentOwnerKey);
        set => SetParameter(OnBehalfOfContentOwnerKey, value);
    }
}
