// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <summary>
/// Provides methods for retrieving YouTube video categories.
/// </summary>
/// <remarks>
/// This service builds request properties and delegates execution to a <see cref="VideoCategoryHandler"/>.
/// </remarks>
public class VideoCategoryService(
    IYouTubeHandlerProvider handlers
) : IVideoCategoryService
{
    /// <summary>
    /// Gets the handler provider used to resolve YouTube handlers.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } =
        handlers ?? throw new ArgumentNullException(nameof(handlers));

    /// <summary>
    /// Lists video categories filtered by category id.
    /// </summary>
    /// <param name="part">The <c>part</c> parameter identifies the properties that the API response will include.</param>
    /// <param name="id">The <c>id</c> parameter identifies video category ids.</param>
    /// <param name="hl">The <c>hl</c> parameter specifies the language for text values in the response.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The video category list response.</returns>
    public Task<VideoCategoryListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        string? hl = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        if (StringValues.IsNullOrEmpty(id))
        {
            throw new ArgumentException("id must be provided.", nameof(id));
        }

        return ListAsync(
            part,
            new(nameof(id), id),
            hl,
            cancellationToken);
    }

    /// <summary>
    /// Lists video categories filtered by region code.
    /// </summary>
    /// <param name="part">The <c>part</c> parameter identifies the properties that the API response will include.</param>
    /// <param name="regionCode">The <c>regionCode</c> parameter specifies the region for which categories are returned.</param>
    /// <param name="hl">The <c>hl</c> parameter specifies the language for text values in the response.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The video category list response.</returns>
    public Task<VideoCategoryListResponse> ListByRegionCodeAsync(
        StringValues part,
        string regionCode,
        string? hl = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(regionCode);

        return ListAsync(
            part,
            new(nameof(regionCode), regionCode),
            hl,
            cancellationToken);
    }

    /// <summary>
    /// Lists video categories using the provided filter.
    /// </summary>
    /// <param name="part">The <c>part</c> parameter identifies the properties that the API response will include.</param>
    /// <param name="filter">The query filter applied to the request.</param>
    /// <param name="hl">The <c>hl</c> parameter specifies the language for text values in the response.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The video category list response.</returns>
    private async Task<VideoCategoryListResponse> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        string? hl = null,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<VideoCategoryHandler>()
                                    .ConfigureAwait(false)
                     ?? throw new InvalidOperationException("VideoCategoryHandler could not be obtained.");

        var properties = new VideoCategoryProperties
        {
            Part = part,
            Hl = hl,
        };

        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandleVideoCategoryListAsync(properties, cancellationToken)
                                  .ConfigureAwait(false);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Video category list request failed. [TODO: unify error handling]");
        }

        return result.Resource;
    }
}
