// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public class YouTubeI18nRegionHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : YouTubeHandler(options, logger, encoder), IYouTubeI18nRegionHandler
{
    public async Task<YouTubeResult<YouTubeI18nRegionListResource>> HandleI18nRegionListAsync(YouTubeI18nRegionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        var response = await SendAsync(
            HttpMethod.Get,
            YouTubeI18nRegionsDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<YouTubeI18nRegionListResource>.Success((
                await response.Content.ReadFromJsonAsync<YouTubeI18nRegionListResource>(cancellationToken)
                    .ConfigureAwait(false))!),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}