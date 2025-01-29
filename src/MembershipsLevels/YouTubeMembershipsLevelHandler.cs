// Licensed under the MIT license by loonfactory.

using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public class YouTubeMembershipsLevelHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : YouTubeHandler(options, logger, encoder), IYouTubeMembershipsLevelHandler
{
    public virtual async Task<YouTubeResult<YouTubeMembershipsLevelListResource>> HandleMembershipsLevelListAsync(YouTubeMembershipsLevelProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Count ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Get,
            YouTubeMembershipsLevelDefaults.ListEndpoint,
            properties,
            cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return YouTubeResult<YouTubeMembershipsLevelListResource>.Success(
            JsonSerializer.Deserialize<YouTubeMembershipsLevelListResource>(body, YouTubeDefaults.JsonSerializerOptions)!
        );
    }
}