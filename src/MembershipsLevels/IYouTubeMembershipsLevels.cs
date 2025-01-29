// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public interface IYouTubeMembershipsLevels
{
    public Task<YouTubeMembershipsLevelListResource> GetListAsync(
        StringValues part,
        CancellationToken cancellationToken = default
    );
}
