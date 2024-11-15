// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public interface IYouTubeI18nRegions
{
    public Task<YouTubeI18nRegionListResource> ListAsync(
        StringValues part,
        string? hl = "en_US",
        CancellationToken cancellationToken = default
    );
}
