// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

public class ChannelBannerHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IChannelBannerHandler
{
    public virtual Task<YouTubeResult<ChannelBannerResource>> HandleChannelBannerInsertAsync(
        StreamContent? content,
        ChannelBannerProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var endpoint = BuildChallengeUrl(ChannelBannerDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = content,
        };

        return AuthorizationExecuteAsync<ChannelBannerResource>(
            request,
            properties,
            cancellationToken
        );
    }
}