// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <inheritdoc />
public class VideoCategoryHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IVideoCategoryHandler
{
    /// <inheritdoc />
    public virtual Task<YouTubeResult<VideoCategoryListResponse>> HandleVideoCategoryListAsync(
        VideoCategoryProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);
        if (properties.Part is null || properties.Part?.Count == 0)
        {
            throw new ArgumentException("The properties.Part parameter must be provided in the properties.");
        }

        return ExecuteAsync<VideoCategoryListResponse>(
            HttpMethod.Get,
            VideoCategoryDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }
}
