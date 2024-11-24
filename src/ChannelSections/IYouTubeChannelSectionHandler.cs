// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

public interface IYouTubeChannelSectionHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeChannelSectionListResource>> HandleChannelSectionListAsync(YouTubeChannelSectionProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult<YouTubeChannelSectionResource>> HandleChannelSectionInsertAsync(YouTubeChannelSectionResource resource, YouTubeChannelSectionProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult<YouTubeChannelSectionResource>> HandleChannelSectionUpdateAsync(YouTubeChannelSectionResource resource, YouTubeChannelSectionProperties properties, CancellationToken cancellationToken);

    public Task<YouTubeResult> HandleChannelSectionDeleteAsync(YouTubeChannelSectionProperties properties, CancellationToken cancellationToken);
}
