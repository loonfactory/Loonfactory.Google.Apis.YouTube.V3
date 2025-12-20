// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public class PlaylistImagesService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : IPlaylistImagesService
{
    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public Task<PlaylistImageListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    )
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
            cancellationToken
        );
    }

    public Task<PlaylistImageListResponse> ListByPlaylistIdAsync(
        StringValues part,
        string playlistId,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(playlistId);
        return ListAsync(
            part,
            new(nameof(playlistId), playlistId),
            maxResults,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            pageToken,
            cancellationToken
        );
    }

    private async Task<PlaylistImageListResponse> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<PlaylistImageHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistImageHandler could not be obtained.");

        var properties = new PlaylistImageProperties
        {
            Part = part,
            MaxResults = maxResults,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            OnBehalfOfContentOwnerChannel = onBehalfOfContentOwnerChannel,
            PageToken = pageToken,
        };

        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandlePlaylistImageListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<PlaylistImageResource> InsertAsync(
        StringValues part,
        PlaylistImageResource resource,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentNullException.ThrowIfNull(contentType);

        return InsertAsync(
            part,
            resource,
            new StreamContent(stream),
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            cancellationToken
        );
    }

    public Task<PlaylistImageResource> InsertAsync(
        StringValues part,
        PlaylistImageResource resource,
        StreamContent content,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(content);
        ArgumentNullException.ThrowIfNull(resource);

        if (resource.Snippet == null)
        {
            throw new InvalidOperationException("Snippet must be set.");
        }

        if (resource.Snippet.PlaylistId == null)
        {
            throw new InvalidOperationException("PlaylistId must be set.");
        }

        if (resource.Snippet.Type == null)
        {
            throw new InvalidOperationException("Type must be set.");
        }

        return InternalInsertAsync(
            part,
            resource,
            content,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            cancellationToken
        );
    }

    private async Task<PlaylistImageResource> InternalInsertAsync(
        StringValues part,
        PlaylistImageResource resource,
        StreamContent content,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default
    )
    {
        var handler = await Handlers.GetHandlerAsync<PlaylistImageHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistImageHandler could not be obtained.");

        var properties = new PlaylistImageProperties
        {
            Part = part,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            OnBehalfOfContentOwnerChannel = onBehalfOfContentOwnerChannel,
        };

        return await handler.HandlePlaylistImageInsertAsync(
            resource,
            content,
            properties,
            cancellationToken
        ).ConfigureAwait(false) switch
        {
            { Succeeded: true, Resource: var result } => result,
            { Succeeded: false } => throw new NotImplementedException("@TODO"),
            _ => throw new InvalidOperationException("Unexpected result.")
        };
    }

    public Task<PlaylistImageResource> UpdateAsync(
        StringValues part,
        PlaylistImageResource resource,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentNullException.ThrowIfNull(contentType);

        return UpdateAsync(
            part,
            resource,
            new StreamContent(stream),
            onBehalfOfContentOwner,
            cancellationToken
        );
    }

    public Task<PlaylistImageResource> UpdateAsync(
        StringValues part,
        PlaylistImageResource resource,
        StreamContent content,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(content);
        ArgumentNullException.ThrowIfNull(resource);

        if (resource.Snippet == null)
        {
            throw new InvalidOperationException("Snippet must be set.");
        }

        if (resource.Snippet.PlaylistId == null)
        {
            throw new InvalidOperationException("PlaylistId must be set.");
        }

        if (resource.Snippet.Type == null)
        {
            throw new InvalidOperationException("Type must be set.");
        }

        return InternalUpdateAsync(
            part,
            resource,
            content,
            onBehalfOfContentOwner,
            cancellationToken
        );
    }

    private async Task<PlaylistImageResource> InternalUpdateAsync(
        StringValues part,
        PlaylistImageResource resource,
        StreamContent content,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    )
    {
        var handler = await Handlers.GetHandlerAsync<PlaylistImageHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistImageHandler could not be obtained.");

        var properties = new PlaylistImageProperties
        {
            Part = part,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
        };

        return await handler.HandlePlaylistImageUpdateAsync(
            resource,
            content,
            properties,
            cancellationToken
        ).ConfigureAwait(false) switch
        {
            { Succeeded: true, Resource: var result } => result,
            { Succeeded: false } => throw new NotImplementedException("@TODO"),
            _ => throw new InvalidOperationException("Unexpected result.")
        };
    }

    public async Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id);

        var handler = await Handlers.GetHandlerAsync<PlaylistImageHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubePlaylistImageHandler could not be obtained.");

        var properties = new PlaylistImageProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
        };

        await handler.HandlePlaylistImageDeleteAsync(
            properties,
            cancellationToken
        ).ConfigureAwait(false);
    }
}