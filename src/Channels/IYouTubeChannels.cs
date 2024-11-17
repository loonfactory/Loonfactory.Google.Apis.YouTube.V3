// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Channels;

public interface IYouTubeChannels
{
    public Task<YouTubeChannelListResource> ListByForHandleAsync(
        StringValues part,
        string forHandle,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelListResource> ListByForUsernameAsync(
        StringValues part,
        string forUsername,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelListResource> ListByIdAsync(
        StringValues part,
        StringValues id,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelListResource> ListByMineAsync(
        StringValues part,
        bool mine,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelResource> UpdateAsync(
        StringValues part,
        YouTubeChannelResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );
}
