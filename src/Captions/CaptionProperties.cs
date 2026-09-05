// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// <see cref="YouTubeProperties"/> for a YouTube caption challenge.
/// </summary>
public class CaptionProperties : YouTubeProperties
{
    /// <summary>
    /// The parameter key for the "id" argument being used for a challenge request.
    /// </summary>
    public static readonly string IdKey = "id";

    public static readonly string VideoIdKey = "videoId";

    public static readonly string PartKey = "part";

    public static readonly string TfmtKey = "tfmt";

    public static readonly string TlangKey = "tlang";

    /// <summary>
    /// The parameter key for the "onBehalfOfContentOwner" argument being used for a challenge request.
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
    /// <inheritdoc />
    public CaptionProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="CaptionProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public CaptionProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// The "id" parameter value being used for a challenge request.
    /// </summary>
    public string? Id
    {
        get => GetParameter<string>(IdKey);
        set => SetParameter(IdKey, value);
    }

    /// <summary>
    /// The "onBehalfOfContentOwner" parameter value being used for a challenge request.
    /// </summary>
    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(onBehalfOfContentOwnerKey);
        set => SetParameter(onBehalfOfContentOwnerKey, value);
    }

    public string? VideoId
    {
        get => GetParameter<string>(VideoIdKey);
        set => SetParameter(VideoIdKey, value);
    }

    public string[]? Part
    {
        get => GetParameter<string[]>(PartKey);
        set => SetParameter(PartKey, value);
    }

    public string? Tfmt
    {
        get => GetParameter<string>(TfmtKey);
        set => SetParameter(TfmtKey, value);
    }

    public string? Tlang
    {
        get => GetParameter<string>(TlangKey);
        set => SetParameter(TlangKey, value);
    }
}
