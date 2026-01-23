// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoCategories;

/// <summary>
/// Defines a contract for a service that retrieves video category.
/// </summary>
public interface IVideoCategoryService
{
    /// <summary>
    /// Retrieves a list of video categories by category id.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies a comma-separated list of one or more videoCategory resource properties
    /// that the API response will include.
    /// </param>
    /// <param name="id">
    /// The <c>id</c> parameter specifies a comma-separated list of video category ids to retrieve.
    /// </param>
    /// <param name="hl">
    /// The <c>hl</c> parameter specifies the language to use for text values in the response.
    /// </param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests. The default value is None.
    /// </param>
    /// <returns>The video category list response.</returns>
    Task<VideoCategoryListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        string? hl = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of video categories for a region.
    /// </summary>
    /// <param name="part">
    /// The <c>part</c> parameter specifies a comma-separated list of one or more videoCategory resource properties
    /// that the API response will include.
    /// </param>
    /// <param name="regionCode">
    /// The <c>regionCode</c> parameter specifies a region for which to retrieve categories.
    /// </param>
    /// <param name="hl">
    /// The <c>hl</c> parameter specifies the language to use for text values in the response.
    /// </param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests. The default value is None.
    /// </param>
    /// <returns>The video category list response.</returns>
    Task<VideoCategoryListResponse> ListByRegionCodeAsync(
        StringValues part,
        string regionCode,
        string? hl = null,
        CancellationToken cancellationToken = default);
}
