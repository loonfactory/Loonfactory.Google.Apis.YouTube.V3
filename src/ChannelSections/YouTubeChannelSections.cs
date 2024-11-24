// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

public class YouTubeChannelSections(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IYouTubeChannelSections
{

    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public virtual Task<YouTubeChannelSectionListResource> ListByChannelIdAsync(
        StringValues part,
        string channelId,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(channelId);

        return ListAsync(
           part,
           new KeyValuePair<string, object>(nameof(channelId), channelId),
           onBehalfOfContentOwner,
           cancellationToken
       );
    }

    public virtual Task<YouTubeChannelSectionListResource> ListByIdAsync(
        StringValues part,
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(id);

        return ListAsync(
            part,
            new KeyValuePair<string, object>(nameof(id), id),
            onBehalfOfContentOwner,
            cancellationToken
        );
    }

    public virtual Task<YouTubeChannelSectionListResource> ListByMineAsync(
        StringValues part,
        bool mine,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        return ListAsync(part, new(nameof(mine), mine), onBehalfOfContentOwner, cancellationToken);
    }

    private async Task<YouTubeChannelSectionListResource> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubeChannelSectionHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeChannelSectionHandler could not be obtained.");

        var properties = new YouTubeChannelSectionProperties
        {
            Part = part,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandleChannelSectionListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<YouTubeChannelSectionResource> InsertAsync(
        StringValues part,
        YouTubeChannelSectionResource resource,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwnerChannel);

        return InternalInsertAsync(
            part,
            resource,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            cancellationToken
        );

        async Task<YouTubeChannelSectionResource> InternalInsertAsync(
            StringValues part,
            YouTubeChannelSectionResource resource,
            string? onBehalfOfContentOwner = null,
            string? onBehalfOfContentOwnerChannel = null,
            CancellationToken cancellationToken = default)
        {
            var handler = await Handlers.GetHandlerAsync<YouTubeChannelSectionHandler>()
                             .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeChannelSectionHandler could not be obtained.");

            var properties = new YouTubeChannelSectionProperties
            {
                Part = part,
                OnBehalfOfContentOwner = onBehalfOfContentOwner,
                OnBehalfOfContentOwnerChannel = onBehalfOfContentOwnerChannel,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandleChannelSectionInsertAsync(
                resource,
                properties,
                cancellationToken
            ).ConfigureAwait(false);

            return result.Succeeded switch
            {
                true => result.Resource,
                false => throw new NotImplementedException("@TODO")
            };
        }
    }

    public Task<YouTubeChannelSectionResource> UpdateAsync(
        StringValues part,
        YouTubeChannelSectionResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalUpdateAsync(part, resource, onBehalfOfContentOwner, cancellationToken);

        async Task<YouTubeChannelSectionResource> InternalUpdateAsync(
            StringValues part,
            YouTubeChannelSectionResource resource,
            string? onBehalfOfContentOwner = null,
            CancellationToken cancellationToken = default)
        {
            var handler = await Handlers.GetHandlerAsync<YouTubeChannelSectionHandler>()
                             .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeChannelSectionHandler could not be obtained.");

            var properties = new YouTubeChannelSectionProperties
            {
                Part = part,
                OnBehalfOfContentOwner = onBehalfOfContentOwner,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandleChannelSectionUpdateAsync(resource, properties, cancellationToken).ConfigureAwait(false);
            return result.Succeeded switch
            {
                true => result.Resource,
                false => throw new NotImplementedException("@TODO")
            };
        }
    }
}