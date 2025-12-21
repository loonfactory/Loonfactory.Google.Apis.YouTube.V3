// Licensed under the MIT license by loonfactory.
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public class PlaylistsService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : IPlaylistsService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public Task<PlaylistListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(id);

        return ListAsync(
            part,
            new(nameof(id), id),
            maxResults,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            pageToken,
            cancellationToken);
    }

    public Task<PlaylistListResponse> ListByChannelIdAsync(
        StringValues part,
        string channelId,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(channelId);

        return ListAsync(
            part,
            new(nameof(channelId), channelId),
            maxResults,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            pageToken,
            cancellationToken);
    }

    public Task<PlaylistListResponse> ListByMineAsync(
        StringValues part,
        bool mine,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        return ListAsync(
            part,
            new(nameof(mine), mine),
            maxResults,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            pageToken,
            cancellationToken);
    }

    private async Task<PlaylistListResponse> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        uint? maxResults,
        string? onBehalfOfContentOwner,
        string? onBehalfOfContentOwnerChannel,
        string? pageToken,
        CancellationToken cancellationToken)
    {
        var handler = await Handlers.GetHandlerAsync<PlaylistHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

        var properties = new PlaylistProperties
        {
            Part = part,
            MaxResults = maxResults,
            PageToken = pageToken,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            OnBehalfOfContentOwnerChannel = onBehalfOfContentOwnerChannel,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandlePlaylistListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<PlaylistResource> InsertAsync(
        StringValues part,
        PlaylistResource resource,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);
        if (resource.Snippet == null)
        {
            throw new InvalidOperationException("Snippet must be set.");
        }

        if (string.IsNullOrEmpty(resource.Snippet.Title))
        {
            throw new InvalidOperationException("Snippet.Title must be set.");
        }

        return InternalInsertAsync(
            part,
            resource,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            cancellationToken
        );

        async Task<PlaylistResource> InternalInsertAsync(
            StringValues part,
            PlaylistResource resource,
            string? onBehalfOfContentOwner,
            string? onBehalfOfContentOwnerChannel,
            CancellationToken cancellationToken)
        {
            var handler = await Handlers.GetHandlerAsync<PlaylistHandler>()
                                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

            var properties = new PlaylistProperties
            {
                Part = part,
                OnBehalfOfContentOwner = onBehalfOfContentOwner,
                OnBehalfOfContentOwnerChannel = onBehalfOfContentOwnerChannel,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandlePlaylistInsertAsync(resource, properties, cancellationToken).ConfigureAwait(false);
            return result.Succeeded switch
            {
                true => result.Resource,
                false => throw new NotImplementedException("@TODO")
            };
        }
    }

    public Task<PlaylistResource> UpdateAsync(
        StringValues part,
        PlaylistResource resource,
        string? onBehalfOfContentOwner = null,
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

        if (string.IsNullOrEmpty(resource.Snippet.Title))
        {
            throw new InvalidOperationException("Snippet.PlaylistId must be set.");
        }

        return InternalUpdateAsync(
            part,
            resource,
            onBehalfOfContentOwner,
            cancellationToken);

        async Task<PlaylistResource> InternalUpdateAsync(
            StringValues part,
            PlaylistResource resource,
            string? onBehalfOfContentOwner,
            CancellationToken cancellationToken)
        {
            var handler = await Handlers.GetHandlerAsync<PlaylistHandler>()
                                        .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

            var properties = new PlaylistProperties
            {
                Part = part,
                OnBehalfOfContentOwner = onBehalfOfContentOwner,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandlePlaylistUpdateAsync(resource, properties, cancellationToken).ConfigureAwait(false);
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
        var handler = await Handlers.GetHandlerAsync<PlaylistHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistItemHandler could not be obtained.");

        var properties = new PlaylistProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandlePlaylistDeleteAsync(properties, cancellationToken).ConfigureAwait(false);
        if (result.Succeeded)
        {
            return;
        }

        throw new NotImplementedException("@TODO");
    }
}
