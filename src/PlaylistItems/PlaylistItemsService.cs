// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

public class PlaylistItemsService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IPlaylistItemsService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public Task<PlaylistItemListResponse> ListByIdAsync(
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

    public Task<PlaylistItemListResponse> ListByPlaylistIdAsync(
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

    private async Task<PlaylistItemListResponse> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        uint? maxResults,
        string? pageToken,
        string? onBehalfOfContentOwner,
        string? videoId,
        CancellationToken cancellationToken)
    {
        var handler = await Handlers.GetHandlerAsync<PlaylistItemHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

        var properties = new PlaylistItemProperties
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

    public Task<PlaylistItemResource> InsertAsync(
        StringValues part,
        PlaylistItemResource resource,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);
        if (resource.Snippet == null)
        {
            throw new InvalidOperationException("Snippet must be set.");
        }

        if (string.IsNullOrEmpty(resource.Snippet.PlaylistId))
        {
            throw new InvalidOperationException("Snippet.PlaylistId must be set.");
        }

        if (string.IsNullOrEmpty(resource.Snippet.ResourceId?.VideoId))
        {
            throw new InvalidOperationException("Snippet.ResourceId.VideoId must be set.");
        }

        return InternalInsertAsync(part, resource, cancellationToken);

        async Task<PlaylistItemResource> InternalInsertAsync(StringValues part, PlaylistItemResource resource, CancellationToken cancellationToken)
        {
            var handler = await Handlers.GetHandlerAsync<PlaylistItemHandler>()
                                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

            var properties = new PlaylistItemProperties
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

    public Task<PlaylistItemResource> UpdateAsync(
        StringValues part,
        PlaylistItemResource resource,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("Resource.Id must be set for update.");
        }

        if (resource.Snippet == null)
        {
            throw new InvalidOperationException("Snippet must be set.");
        }

        if (string.IsNullOrEmpty(resource.Snippet.PlaylistId))
        {
            throw new InvalidOperationException("Snippet.PlaylistId must be set.");
        }

        return InternalUpdateAsync(part, resource, cancellationToken);

        async Task<PlaylistItemResource> InternalUpdateAsync(StringValues part, PlaylistItemResource resource, CancellationToken cancellationToken)
        {
            var handler = await Handlers.GetHandlerAsync<PlaylistItemHandler>()
                                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

            var properties = new PlaylistItemProperties
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
        var handler = await Handlers.GetHandlerAsync<PlaylistItemHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

        var properties = new PlaylistItemProperties
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
