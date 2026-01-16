// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

public class ThumbnailService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : IThumbnailService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public async Task<ThumbnailSetResponse> SetAsync(
        string videoId,
        Stream thumbnail,
        string contentType = "image/jpeg",
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(videoId);
        ArgumentNullException.ThrowIfNull(thumbnail);

        var handler = await Handlers.GetHandlerAsync<ThumbnailHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("ThumbnailHandler could not be obtained.");

        var properties = new ThumbnailProperties
        {
            VideoId = videoId,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleThumbnailSetAsync(thumbnail, contentType, properties, cancellationToken)
            .ConfigureAwait(false);

        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }
}
