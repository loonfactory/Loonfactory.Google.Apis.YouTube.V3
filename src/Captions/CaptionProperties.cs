// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Stores parameters for caption requests.
/// </summary>
public class CaptionProperties : YouTubeProperties
{
    /// <summary>
    /// The query key for <c>id</c>.
    /// </summary>
    public static readonly string IdKey = "id";

    /// <summary>
    /// The query key for <c>videoId</c>.
    /// </summary>
    public static readonly string VideoIdKey = "videoId";

    /// <summary>
    /// The query key for <c>part</c>.
    /// </summary>
    public static readonly string PartKey = "part";

    /// <summary>
    /// The query key for <c>tfmt</c>.
    /// </summary>
    public static readonly string TfmtKey = "tfmt";

    /// <summary>
    /// The query key for <c>tlang</c>.
    /// </summary>
    public static readonly string TlangKey = "tlang";

    /// <summary>
    /// The query key for <c>onBehalfOfContentOwner</c>.
    /// </summary>
    public static readonly string onBehalfOfContentOwnerKey = "onBehalfOfContentOwner";

    /// <summary>
    /// Initializes a new instance of <see cref="CaptionProperties"/>.
    /// </summary>
    public CaptionProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="CaptionProperties"/>.
    /// </summary>
    /// <param name="items">The stored property values.</param>
    public CaptionProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="CaptionProperties"/>.
    /// </summary>
    /// <param name="items">The stored property values.</param>
    /// <param name="parameters">The request parameter values.</param>
    public CaptionProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// Gets or sets caption identifiers; list accepts comma-separated values.
    /// </summary>
    public string? Id
    {
        get => GetParameter<string>(IdKey);
        set => SetParameter(IdKey, value);
    }

    /// <summary>
    /// Gets or sets the optional content partner owner identifier.
    /// </summary>
    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(onBehalfOfContentOwnerKey);
        set => SetParameter(onBehalfOfContentOwnerKey, value);
    }

    /// <summary>
    /// Gets or sets the video identifier required for listing.
    /// </summary>
    public string? VideoId
    {
        get => GetParameter<string>(VideoIdKey);
        set => SetParameter(VideoIdKey, value);
    }

    /// <summary>
    /// Gets or sets the requested resource parts.
    /// </summary>
    public string[]? Part
    {
        get => GetParameter<string[]>(PartKey);
        set => SetParameter(PartKey, value);
    }

    /// <summary>
    /// Gets or sets the download format, or null for the original format.
    /// </summary>
    public string? Tfmt
    {
        get => GetParameter<string>(TfmtKey);
        set => SetParameter(TfmtKey, value);
    }

    /// <summary>
    /// Gets or sets the translation language, or null for the original language.
    /// </summary>
    public string? Tlang
    {
        get => GetParameter<string>(TlangKey);
        set => SetParameter(TlangKey, value);
    }
}
