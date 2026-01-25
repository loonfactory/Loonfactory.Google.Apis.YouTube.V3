// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <inheritdoc />
public class VideoCategoryHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), IVideoCategoryHandler
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

        return InternalHandleVideoCategoryListAsync(properties, cancellationToken);
    }

    private async Task<YouTubeResult<VideoCategoryListResponse>> InternalHandleVideoCategoryListAsync(
        VideoCategoryProperties properties,
        CancellationToken cancellationToken
    )
    {
        using var response = await SendAsync(
            HttpMethod.Get,
            VideoCategoryDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            return YouTubeResult<VideoCategoryListResponse>.Fail(new InvalidOperationException("Video categories list request failed. [@TODO: unify error handling]"));
        }

        var result = await response.Content.ReadFromJsonAsync<VideoCategoryListResponse>(
            YouTubeDefaults.JsonSerializerOptions,
            cancellationToken
        ).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize video category list response.");

        return YouTubeResult<VideoCategoryListResponse>.Success(result);
    }

}
