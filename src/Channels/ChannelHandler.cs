// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Channels;

public class ChannelHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IChannelHandler
{
    public virtual Task<YouTubeResult<CaptionListResponse>> HandleChannelListAsync(ChannelProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        return AuthorizationExecuteAsync<CaptionListResponse>(
            HttpMethod.Get,
            ChannelDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<ChannelResource>> HandleChannelUpdateAsync(ChannelProperties properties, ChannelResource resource, CancellationToken cancellationToken)
    {
        var endpoint = BuildChallengeUrl(ChannelDefaults.ListEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
        {
            Content = JsonContent.Create(resource),
        };

        return AuthorizationExecuteAsync<ChannelResource>(
            request,
            properties,
            cancellationToken
        );
    }
}