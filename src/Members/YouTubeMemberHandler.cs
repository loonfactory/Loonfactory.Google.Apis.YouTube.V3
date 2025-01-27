// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class YouTubeMemberHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : YouTubeHandler(options, logger, encoder), IYouTubeMemberHandler
{
    public virtual async Task<YouTubeResult<YouTubeMemberListResource>> HandleMemberListAsync(YouTubeMemberProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Count ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        if (string.IsNullOrEmpty(properties.AccessToken))
        {
            throw new InvalidOperationException("An access token must be provided in the properties.");
        }

        var endpoint = BuildChallengeUrl(YouTubeMemberDefaults.ListEndpoint, properties);

        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return YouTubeResult<YouTubeMemberListResource>.Success(
            JsonSerializer.Deserialize<YouTubeMemberListResource>(body, YouTubeDefaults.JsonSerializerOptions)!
        );
    }
}