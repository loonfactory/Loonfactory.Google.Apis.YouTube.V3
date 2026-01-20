// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <summary>
/// Represents parameters for thumbnail operations.
/// </summary>
/// <remarks>
/// This type provides strongly-typed accessors for parameters used by YouTube thumbnail requests.
/// </remarks>
public class ThumbnailProperties : YouTubeProperties
{
    /// <summary>
    /// The parameter name for <see cref="VideoId"/>.
    /// </summary>
    public static readonly string VideoIdKey = "videoId";

    /// <summary>
    /// The parameter name for <see cref="OnBehalfOfContentOwner"/>.
    /// </summary>
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";

    /// <summary>
    /// Initializes a new instance of <see cref="ThumbnailProperties"/>.
    /// </summary>
    public ThumbnailProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ThumbnailProperties"/> with initial items.
    /// </summary>
    public ThumbnailProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="ThumbnailProperties"/> with initial items and parameters.
    /// </summary>
    public ThumbnailProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// Gets or sets the YouTube video ID for which the thumbnail operation is performed.
    /// </summary>
    public string? VideoId
    {
        get => GetParameter<string>(VideoIdKey);
        set => SetParameter(VideoIdKey, value);
    }

    /// <summary>
    /// Gets or sets the content owner on whose behalf the request is made.
    /// </summary>
    /// <remarks>
    /// This parameter is intended for YouTube content partners and is used when a CMS user acts on behalf
    /// of the specified content owner. :contentReference[oaicite:1]{index=1}
    /// </remarks>
    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(OnBehalfOfContentOwnerKey);
        set => SetParameter(OnBehalfOfContentOwnerKey, value);
    }
}
