// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;

/// <summary>
/// @TODO
/// </summary>
public interface IChannelBanners
{
    public Task<ChannelBannerResource> InsertAsync(
        Stream stream,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelBannerResource> InsertAsync(
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelBannerResource> InsertAsync(
        StreamContent content,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelBannerResource> InsertAsync(
        string onBehalfOfContentOwner,
        Stream stream,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelBannerResource> InsertAsync(
        string onBehalfOfContentOwner,
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    );

    public Task<ChannelBannerResource> InsertAsync(
        string onBehalfOfContentOwner,
        StreamContent content,
        CancellationToken cancellationToken = default
    );
}
