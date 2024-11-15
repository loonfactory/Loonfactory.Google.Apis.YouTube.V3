// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public interface IYouTubeI18nRegionHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeI18nRegionListResource>> HandleI18nRegionListAsync(YouTubeI18nRegionProperties properties, CancellationToken cancellationToken);
}
