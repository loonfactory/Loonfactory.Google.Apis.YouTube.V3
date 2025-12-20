// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public interface IMembersService
{
    public Task<MemberListResponse> GetListAsync(
        StringValues part,
        string? mode = "all_current",
        ushort? maxResults = 5,
        string? pageToken = null,
        string? hasAccessToLevel = null,
        string? filterByMemberChannelId = null,
        CancellationToken cancellationToken = default
    );
}
