// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;

public class VideoAbuseReportReasonsService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : IVideoAbuseReportReasonsService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public async Task<VideoAbuseReportReasonListResponse> ListAsync(
        StringValues part,
        string? hl = "en_US",
        StringValues? id = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        var handler = await Handlers.GetHandlerAsync<VideoAbuseReportReasonHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("VideoAbuseReportReasonHandler could not be obtained.");

        var properties = new VideoAbuseReportReasonProperties
        {
            Part = part,
            Hl = hl,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleVideoAbuseReportReasonListAsync(properties, cancellationToken).ConfigureAwait(false);

        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }
}
