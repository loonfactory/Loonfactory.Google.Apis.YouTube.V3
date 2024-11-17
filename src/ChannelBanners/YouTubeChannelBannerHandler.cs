// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

public class YouTubeChannelBannerHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : YouTubeHandler(options, logger, encoder), IYouTubeChannelBannerHandler
{
    public virtual Task<YouTubeResult<YouTubeChannelBannerResource>> HandleChannelBannerInsertAsync(
        StreamContent? content,
        YouTubeChannelBannerProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(YouTubeChannelBannerDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = content,
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        return InternalHandleUploadAsync(request, cancellationToken);

        async Task<YouTubeResult<YouTubeChannelBannerResource>> InternalHandleUploadAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            return response.IsSuccessStatusCode switch
            {
                true => YouTubeResult<YouTubeChannelBannerResource>.Success(
                    JsonSerializer.Deserialize<YouTubeChannelBannerResource>(body, YouTubeDefaults.JsonSerializerOptions)!
                ),
                false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
            };
        }
    }

}