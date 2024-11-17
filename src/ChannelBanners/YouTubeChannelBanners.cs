// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

public class YouTubeChannelBanners(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IYouTubeChannelBanners
{
    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public Task<YouTubeChannelBannerResource> InsertAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        return InsertAsync(stream, "application/octet-stream", cancellationToken);
    }

    public Task<YouTubeChannelBannerResource> InsertAsync(Stream stream, string contentType, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentNullException.ThrowIfNull(contentType);

        var content = new StreamContent(stream);
        content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

        return InternalInsertAsync(null, content, cancellationToken);
    }

    public Task<YouTubeChannelBannerResource> InsertAsync(StreamContent content, CancellationToken cancellationToken = default)
    {
        return InternalInsertAsync(null, content, cancellationToken);
    }

    public Task<YouTubeChannelBannerResource> InsertAsync(string onBehalfOfContentOwner, Stream stream, CancellationToken cancellationToken = default)
    {
        return InsertAsync(onBehalfOfContentOwner, stream, "application/octet-stream", cancellationToken);
    }

    public Task<YouTubeChannelBannerResource> InsertAsync(string onBehalfOfContentOwner, Stream stream, string contentType, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentNullException.ThrowIfNull(contentType);

        var content = new StreamContent(stream);
        content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

        return InternalInsertAsync(onBehalfOfContentOwner, content, cancellationToken);
    }

    public Task<YouTubeChannelBannerResource> InsertAsync(string onBehalfOfContentOwner, StreamContent content, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(content);

        return InternalInsertAsync(onBehalfOfContentOwner, content, cancellationToken);
    }

    private async Task<YouTubeChannelBannerResource> InternalInsertAsync(string? onBehalfOfContentOwner, StreamContent content, CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubeChannelBannerHandler>()
                                 .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var properties = new YouTubeChannelBannerProperties
        {
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleChannelBannerInsertAsync(content, properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }
}