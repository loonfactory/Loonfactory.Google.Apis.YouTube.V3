// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// <see cref="YouTubeProperties"/> for a YouTube caption challenge.
/// </summary>
public class YouTubeCaptionProperties : YouTubeProperties
{
    /// <summary>
    /// The parameter key for the "accessToken" argument used for authorization.
    /// </summary>
    /// 
    public static readonly string AccessTokenKey = "accessToken";

    /// <summary>
    /// The parameter key for the "id" argument being used for a challenge request.
    /// </summary>
    public static readonly string IdKey = "id";

    /// <summary>
    /// The parameter key for the "onBehalfOfContentOwner" argument being used for a challenge request.
    /// </summary>
    public static readonly string onBehalfOfContentOwnerKey = "onBehalfOfContentOwner";

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeCaptionProperties"/>.
    /// </summary>
    public YouTubeCaptionProperties()
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeCaptionProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public YouTubeCaptionProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeCaptionProperties"/>.
    /// </summary>
    /// <inheritdoc />
    public YouTubeCaptionProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    /// <summary>
    /// The access token used for authorizing the request.
    /// This token must be obtained via the Google OAuth 2.0 authentication flow.
    /// </summary>
    public string? AccessToken
    {
        get => GetParameter<string>(AccessTokenKey);
        set => SetParameter(AccessTokenKey, value);
    }

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
}