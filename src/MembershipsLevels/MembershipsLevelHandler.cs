// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public class MembershipsLevelHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IMembershipsLevelHandler
{
    public virtual Task<YouTubeResult<MembershipsLevelListResponse>> HandleMembershipsLevelListAsync(MembershipsLevelProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Count ?? 0) == 0)
        {
            throw new InvalidOperationException("The parts parameter must be provided in the properties.");
        }

        return AuthorizationExecuteAsync<MembershipsLevelListResponse>(
            HttpMethod.Get,
            MembershipsLevelDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }
}