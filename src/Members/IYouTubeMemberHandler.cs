// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public interface IYouTubeMemberHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeMemberListResource>> HandleMemberListAsync(YouTubeMemberProperties properties, CancellationToken cancellationToken);
}
