// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class MemberHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IMemberHandler
{
    public virtual Task<YouTubeResult<MemberListResponse>> HandleMemberListAsync(MemberProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Count ?? 0) == 0)
        {
            throw new InvalidOperationException("The parts parameter must be provided in the properties.");
        }

        return AuthorizationExecuteAsync<MemberListResponse>(
            HttpMethod.Get,
            MemberDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }
}