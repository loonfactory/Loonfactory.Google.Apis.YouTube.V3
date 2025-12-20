// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Channels;

public class ChannelHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), IChannelHandler
{
    public virtual Task<YouTubeResult<CaptionListResponse>> HandleChannelListAsync(ChannelProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(ChannelDefaults.ListEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        return InternalHandle<CaptionListResponse>(request, cancellationToken);
    }

    public virtual Task<YouTubeResult<ChannelResource>> HandleChannelUpdateAsync(ChannelProperties properties, ChannelResource resource, CancellationToken cancellationToken)
    {
        var endpoint = BuildChallengeUrl(ChannelDefaults.ListEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
        {
            Content = JsonContent.Create(resource),
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        return InternalHandle<ChannelResource>(request, cancellationToken);
    }

    private async Task<YouTubeResult<T>> InternalHandle<T>(
            HttpRequestMessage request,
            CancellationToken cancellationToken) where T : class
    {
        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<T>.Success(
                JsonSerializer.Deserialize<T>(body, YouTubeDefaults.JsonSerializerOptions)!
            ),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}