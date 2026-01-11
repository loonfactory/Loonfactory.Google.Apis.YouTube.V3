// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;

public interface IVideoAbuseReportReasonsService
{
    Task<VideoAbuseReportReasonListResponse> ListAsync(
        StringValues part,
        string? hl = null,
        StringValues? id = null,
        CancellationToken cancellationToken = default);
}
