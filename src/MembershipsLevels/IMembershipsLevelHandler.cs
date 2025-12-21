// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public interface IMembershipsLevelHandler : IYouTubeHandler
{
    public Task<YouTubeResult<MembershipsLevelListResponse>> HandleMembershipsLevelListAsync(MembershipsLevelProperties properties, CancellationToken cancellationToken);
}
