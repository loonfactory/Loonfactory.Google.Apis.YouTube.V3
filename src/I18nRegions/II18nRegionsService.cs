// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nRegions;

public interface II18nRegionsService
{
    public Task<I18nRegionListResponse> ListAsync(
        StringValues part,
        string? hl = "en_US",
        CancellationToken cancellationToken = default
    );
}
