// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public interface II18nRegionHandler : IYouTubeHandler
{
    public Task<YouTubeResult<I18nRegionListResponse>> HandleI18nRegionListAsync(I18nRegionProperties properties, CancellationToken cancellationToken);
}
