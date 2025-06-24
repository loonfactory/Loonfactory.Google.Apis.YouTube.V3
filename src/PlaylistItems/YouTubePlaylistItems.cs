// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

public class YouTubePlaylistItems(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IYouTubePlaylistItems
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public Task<YouTubePlaylistItemListResource> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? onBehalfOfContentOwner = null,
        string? videoId = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(id);

        return ListAsync(
            part,
            new(nameof(id), id),
            maxResults,
            pageToken,
            onBehalfOfContentOwner,
            videoId,
            cancellationToken);
    }

    public Task<YouTubePlaylistItemListResource> ListByPlaylistIdAsync(
        StringValues part,
        string playlistId,
        uint? maxResults = null,
        string? pageToken = null,
        string? onBehalfOfContentOwner = null,
        string? videoId = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(playlistId);

        return ListAsync(
            part,
            new(nameof(playlistId), playlistId),
            maxResults,
            pageToken,
            onBehalfOfContentOwner,
            videoId,
            cancellationToken);
    }

    private async Task<YouTubePlaylistItemListResource> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        uint? maxResults,
        string? pageToken,
        string? onBehalfOfContentOwner,
        string? videoId,
        CancellationToken cancellationToken)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubePlaylistItemHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

        var properties = new YouTubePlaylistItemProperties
        {
            Part = part,
            MaxResults = maxResults,
            PageToken = pageToken,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            VideoId = videoId,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandlePlaylistItemListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<YouTubePlaylistItemResource> InsertAsync(
        StringValues part,
        YouTubePlaylistItemResource resource,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalInsertAsync(part, resource, cancellationToken);

        async Task<YouTubePlaylistItemResource> InternalInsertAsync(StringValues part, YouTubePlaylistItemResource resource, CancellationToken cancellationToken)
        {
            var handler = await Handlers.GetHandlerAsync<YouTubePlaylistItemHandler>()
                                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

            var properties = new YouTubePlaylistItemProperties
            {
                Part = part,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandlePlaylistItemInsertAsync(resource, properties, cancellationToken).ConfigureAwait(false);
            return result.Succeeded switch
            {
                true => result.Resource,
                false => throw new NotImplementedException("@TODO")
            };
        }
    }

    public Task<YouTubePlaylistItemResource> UpdateAsync(
        StringValues part,
        YouTubePlaylistItemResource resource,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalUpdateAsync(part, resource, cancellationToken);

        async Task<YouTubePlaylistItemResource> InternalUpdateAsync(StringValues part, YouTubePlaylistItemResource resource, CancellationToken cancellationToken)
        {
            var handler = await Handlers.GetHandlerAsync<YouTubePlaylistItemHandler>()
                                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

            var properties = new YouTubePlaylistItemProperties
            {
                Part = part,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandlePlaylistItemUpdateAsync(resource, properties, cancellationToken).ConfigureAwait(false);
            return result.Succeeded switch
            {
                true => result.Resource,
                false => throw new NotImplementedException("@TODO")
            };
        }
    }

    public async Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubePlaylistItemHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

        var properties = new YouTubePlaylistItemProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandlePlaylistItemDeleteAsync(properties, cancellationToken).ConfigureAwait(false);
        if (result.Succeeded)
        {
            return;
        }

        throw new NotImplementedException("@TODO");
    }
}
