// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

public interface IYouTubeChannelSections
{
    public Task<YouTubeChannelSectionListResource> ListByChannelIdAsync(
        StringValues part,
        string channelId,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelSectionListResource> ListByIdAsync(
        StringValues part,
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelSectionListResource> ListByMineAsync(
        StringValues part,
        bool mine,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelSectionResource> UpdateAsync(
        StringValues part,
        YouTubeChannelSectionResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelSectionResource> InsertAsync(
        StringValues part,
        YouTubeChannelSectionResource resource,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    );
}
