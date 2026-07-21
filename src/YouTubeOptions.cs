// Licensed under the MIT license by loonfactory.

using System.Diagnostics;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Contains the options used by the <see cref="YouTubeHandler{T}"/>.
/// </summary>
public class YouTubeOptions
{
    /// <summary>
    /// The API key identifies your project and provides you with API access, quota, and reports.
    /// Required unless you provide an OAuth 2.0 token.
    /// </summary>
    public string? Key { get; set; }

    /// <summary>
    /// Gets or sets timeout value in milliseconds for back channel communications with the remote identity provider.
    /// </summary>
    /// <value>
    /// The back channel timeout.
    /// </value>
    public TimeSpan BackchannelTimeout { get; set; } = TimeSpan.FromSeconds(60);

    /// <summary>
    /// The HttpMessageHandler used to communicate with remote identity provider.
    /// This cannot be set at the same time as BackchannelCertificateValidator unless the value
    /// can be downcast to a WebRequestHandler.
    /// </summary>
    public HttpMessageHandler? BackchannelHttpHandler { get; set; }

    /// <summary>
    /// Used to communicate with the remote identity provider.
    /// </summary>
    public HttpClient Backchannel { get; set; } = default!;

    /// <summary>
    /// Check that the options are valid.  Should throw an exception if things are not ok.
    /// </summary>
    public virtual void Validate()
    {
        if (Key is not null && string.IsNullOrWhiteSpace(Key))
        {
            throw new InvalidOperationException(
                $"{nameof(Key)} cannot be empty or whitespace when specified."
            );
        }

        if (BackchannelTimeout <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(
                nameof(BackchannelTimeout),
                BackchannelTimeout,
                "The backchannel timeout must be graeter than zero."
            );
        }

        if (Backchannel is null)
        {
            throw new InvalidOperationException(
                $"{nameof(Backchannel)} must be configured."
            );
        }
    }

    /// <summary>
    /// Used for testing.
    /// </summary>
    public TimeProvider? TimeProvider { get; set; }
}
