// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public interface IVideosService
{
    Task<VideoListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? hl = null,
        string? regionCode = null,
        string? videoCategoryId = null,
        uint? maxHeight = null,
        uint? maxWidth = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    Task<VideoListResponse> ListByChartAsync(
        StringValues part,
        string chart,
        uint? maxResults = null,
        string? pageToken = null,
        string? hl = null,
        string? regionCode = null,
        string? videoCategoryId = null,
        uint? maxHeight = null,
        uint? maxWidth = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    Task<VideoListResponse> ListByMyRatingAsync(
        StringValues part,
        string myRating,
        uint? maxResults = null,
        string? pageToken = null,
        string? hl = null,
        uint? maxHeight = null,
        uint? maxWidth = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    Task<VideoResource> InsertAsync(
        StringValues part,
        VideoResource resource,
        StreamContent? content = null,
        bool? autoLevels = null,
        bool? notifySubscribers = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default);

    Task<VideoResource> UpdateAsync(
        StringValues part,
        VideoResource resource,
        StreamContent? content = null,
        bool? notifySubscribers = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    Task RateAsync(
        StringValues id,
        string rating,
        CancellationToken cancellationToken = default);

    Task<VideoGetRatingResponse> GetRatingAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);

    Task ReportAbuseAsync(
        VideoReportAbuseRequest resource,
        CancellationToken cancellationToken = default);
}
