// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

public interface IChannelSections
{
    public Task<ChannelSectionListResponse> ListByChannelIdAsync(
        StringValues part,
        string channelId,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelSectionListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelSectionListResponse> ListByMineAsync(
        StringValues part,
        bool mine,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelSectionResource> UpdateAsync(
        StringValues part,
        ChannelSectionResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelSectionResource> InsertAsync(
        StringValues part,
        ChannelSectionResource resource,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    );
}
