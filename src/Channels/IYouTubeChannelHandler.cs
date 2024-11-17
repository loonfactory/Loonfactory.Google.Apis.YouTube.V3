// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Channels;

public interface IYouTubeChannelHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeChannelListResource>> HandleChannelListAsync(YouTubeChannelProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<YouTubeChannelResource>> HandleChannelUpdateAsync(YouTubeChannelProperties properties, YouTubeChannelResource resource, CancellationToken cancellationToken);
}
