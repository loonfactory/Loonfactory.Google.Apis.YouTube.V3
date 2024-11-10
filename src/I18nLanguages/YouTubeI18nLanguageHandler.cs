// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class YouTubeI18nLanguageHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : YouTubeHandler(options, logger, encoder), IYouTubeI18nLanguageHandler
{
    public async Task<YouTubeResult<YouTubeI18nLanguageListResource>> HandleI18nLanguageListAsync(YouTubeI18nLanguageProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        var endpoint = BuildChallengeUrl(YouTubeI18nLanguageDefaults.ListEndpoint, properties);

        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        if (properties.AccessToken != null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);
        }

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<YouTubeI18nLanguageListResource>.Success((
                await response.Content.ReadFromJsonAsync<YouTubeI18nLanguageListResource>(cancellationToken)
                    .ConfigureAwait(false))!),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}