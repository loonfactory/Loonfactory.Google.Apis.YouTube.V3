// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public interface IYouTubePlaylistImages
{
    public Task<YouTubePlaylistImageListResource> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubePlaylistImageListResource> ListByPlaylistIdAsync(
        StringValues part,
        string playlistId,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubePlaylistImageResource> UpdateAsync(
        StringValues part,
        YouTubePlaylistImageResource resource,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );
    
    public Task<YouTubePlaylistImageResource> UpdateAsync(
        StringValues part,
        YouTubePlaylistImageResource resource,
        StreamContent content,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubePlaylistImageResource> InsertAsync(
        StringValues part,
        YouTubePlaylistImageResource resource,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    );

    public Task<YouTubePlaylistImageResource> InsertAsync(
        StringValues part,
        YouTubePlaylistImageResource resource,
        StreamContent content,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    );
    
    public Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    );
}
