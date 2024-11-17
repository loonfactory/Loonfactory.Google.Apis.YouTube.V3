// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

public interface IYouTubeChannelBannerHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeChannelBannerResource>> HandleChannelBannerInsertAsync(StreamContent? content, YouTubeChannelBannerProperties properties, CancellationToken cancellationToken);
}
