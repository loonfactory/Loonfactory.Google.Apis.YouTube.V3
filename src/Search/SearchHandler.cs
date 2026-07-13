// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Search;

public class SearchHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), ISearchHandler
{
    public virtual Task<YouTubeResult<SearchListResponse>> HandleSearchListAsync(
        SearchProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        return ExecuteAsync<SearchListResponse>(
            HttpMethod.Get,
            SearchDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

}
