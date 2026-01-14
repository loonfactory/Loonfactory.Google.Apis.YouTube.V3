// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Searchs;

public interface ISearchHandler : IYouTubeHandler
{
    Task<YouTubeResult<SearchListResponse>> HandleSearchListAsync(
        SearchProperties properties,
        CancellationToken cancellationToken);
}
