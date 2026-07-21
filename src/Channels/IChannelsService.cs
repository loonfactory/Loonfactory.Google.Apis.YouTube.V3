// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Channels;

public interface IChannelsService
{
    public Task<ChannelListResponse> ListByForHandleAsync(
        StringValues part,
        string forHandle,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelListResponse> ListByForUsernameAsync(
        StringValues part,
        string forUsername,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelListResponse> ListByMineAsync(
        StringValues part,
        bool mine,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelResource> UpdateAsync(
        StringValues part,
        ChannelResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );
}
