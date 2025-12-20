// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public interface IMemberHandler : IYouTubeHandler
{
    public Task<YouTubeResult<MemberListResponse>> HandleMemberListAsync(MemberProperties properties, CancellationToken cancellationToken);
}
