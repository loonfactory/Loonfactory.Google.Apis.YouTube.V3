// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Channels;

public interface IChannelHandler : IYouTubeHandler
{
    public Task<YouTubeResult<CaptionListResponse>> HandleChannelListAsync(ChannelProperties properties, CancellationToken cancellationToken);
    public Task<YouTubeResult<ChannelResource>> HandleChannelUpdateAsync(ChannelProperties properties, ChannelResource resource, CancellationToken cancellationToken);
}
