// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

/// <summary>
/// @TODO
/// </summary>
public interface IYouTubeChannelBanners
{
    public Task<YouTubeChannelBannerResource> InsertAsync(
        Stream stream,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelBannerResource> InsertAsync(
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelBannerResource> InsertAsync(
        StreamContent content,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelBannerResource> InsertAsync(
        string onBehalfOfContentOwner,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelBannerResource> InsertAsync(
        string onBehalfOfContentOwner,
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubeChannelBannerResource> InsertAsync(
        string onBehalfOfContentOwner,
        StreamContent content,
        CancellationToken cancellationToken = default
    );
}
