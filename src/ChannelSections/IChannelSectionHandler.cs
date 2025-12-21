// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

public interface IChannelSectionHandler : IYouTubeHandler
{
    public Task<YouTubeResult<ChannelSectionListResponse>> HandleChannelSectionListAsync(ChannelSectionProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult<ChannelSectionResource>> HandleChannelSectionInsertAsync(ChannelSectionResource resource, ChannelSectionProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult<ChannelSectionResource>> HandleChannelSectionUpdateAsync(ChannelSectionResource resource, ChannelSectionProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult> HandleChannelSectionDeleteAsync(ChannelSectionProperties properties, CancellationToken cancellationToken);
}
