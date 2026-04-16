// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public class I18nRegionHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), II18nRegionHandler
{
    public Task<YouTubeResult<I18nRegionListResponse>> HandleI18nRegionListAsync(I18nRegionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("The parts parameter must be provided in the properties.");
        }

        return ExecuteAsync<I18nRegionListResponse>(
            HttpMethod.Get,
            I18nRegionsDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }
}