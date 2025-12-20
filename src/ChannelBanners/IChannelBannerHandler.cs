// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

public interface IChannelBannerHandler : IYouTubeHandler
{
    public Task<YouTubeResult<ChannelBannerResource>> HandleChannelBannerInsertAsync(
        StreamContent? content,
        ChannelBannerProperties properties,
        CancellationToken cancellationToken
    );
}
