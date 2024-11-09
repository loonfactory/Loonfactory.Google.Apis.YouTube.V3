// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Used to setup defaults for the OAuthOptions.
/// </summary>
public class YouTubePostConfigureOptions<TOptions, THandler> : IPostConfigureOptions<TOptions>
    where THandler : IYouTubeHandler
    where TOptions : YouTubeOptions
{
    /// <summary>
    /// Initializes the <see cref="YouTubePostConfigureOptions{TOptions, THandler}"/>.
    /// </summary>
    public YouTubePostConfigureOptions()
    {
    }

    /// <inheritdoc />
    public void PostConfigure(string? name, TOptions options)
    {
        ArgumentNullException.ThrowIfNull(name);

        if (options.Backchannel == null)
        {
            options.Backchannel = new HttpClient(options.BackchannelHttpHandler ?? new HttpClientHandler());
            options.Backchannel.DefaultRequestHeaders.UserAgent.ParseAdd("YouTubeDataApiHandler/0.0.1 (Loonfactory) HttpClient");
            options.Backchannel.Timeout = options.BackchannelTimeout;
            options.Backchannel.MaxResponseContentBufferSize = 1024 * 1024 * 10; // 10 MB
        }
    }
}