// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public interface IYouTubeMembershipsLevelHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeMembershipsLevelListResource>> HandleMembershipsLevelListAsync(YouTubeMembershipsLevelProperties properties, CancellationToken cancellationToken);
}
