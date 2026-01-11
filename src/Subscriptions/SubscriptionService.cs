// Licensed under the MIT license by loonfactory.
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Subscriptions;

public class SubscriptionService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : ISubscriptionService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public Task<SubscriptionListResponse> ListByChannelIdAsync(
        StringValues part,
        string channelId,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
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
            order,
            pageToken,
            cancellationToken);
    }

    public Task<SubscriptionListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
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
            order,
            pageToken,
            cancellationToken);
    }

    public Task<SubscriptionListResponse> ListByMineAsync(
        StringValues part,
        bool mine,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
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
            order,
            pageToken,
            cancellationToken);
    }

    public Task<SubscriptionListResponse> ListByMyRecentSubscribersAsync(
        StringValues part,
        bool myRecentSubscribers,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        return ListAsync(
            part,
            new(nameof(myRecentSubscribers), myRecentSubscribers),
            maxResults,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            order,
            pageToken,
            cancellationToken);
    }

    public Task<SubscriptionListResponse> ListByMySubscribersAsync(
        StringValues part,
        bool mySubscribers,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        return ListAsync(
            part,
            new(nameof(mySubscribers), mySubscribers),
            maxResults,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            order,
            pageToken,
            cancellationToken);
    }

    private async Task<SubscriptionListResponse> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        uint? maxResults,
        string? onBehalfOfContentOwner,
        string? onBehalfOfContentOwnerChannel,
        string? order,
        string? pageToken,
        CancellationToken cancellationToken)
    {
        var handler = await Handlers.GetHandlerAsync<SubscriptionHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("SubscriptionHandler could not be obtained.");

        var properties = new SubscriptionProperties
        {
            Part = part,
            MaxResults = maxResults,
            PageToken = pageToken,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            OnBehalfOfContentOwnerChannel = onBehalfOfContentOwnerChannel,
            Order = order,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };
        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandleSubscriptionListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<SubscriptionResource> InsertAsync(
        StringValues part,
        SubscriptionResource resource,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        if (resource.Snippet == null)
        {
            throw new ArgumentNullException(nameof(resource), "resource.Snippet must be set.");
        }

        if (resource.Snippet.ResourceId == null)
        {
            throw new ArgumentNullException(nameof(resource), "resource.Snippet.ResourceId must be set.");
        }

        return InternalInsertAsync(
            part,
            resource,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            cancellationToken
        );

        async Task<SubscriptionResource> InternalInsertAsync(
            StringValues part,
            SubscriptionResource resource,
            string? onBehalfOfContentOwner,
            string? onBehalfOfContentOwnerChannel,
            CancellationToken cancellationToken)
        {
            var handler = await Handlers.GetHandlerAsync<SubscriptionHandler>()
                                        .ConfigureAwait(false) ?? throw new InvalidOperationException("SubscriptionHandler could not be obtained.");

            var properties = new SubscriptionProperties
            {
                Part = part,
                OnBehalfOfContentOwner = onBehalfOfContentOwner,
                OnBehalfOfContentOwnerChannel = onBehalfOfContentOwnerChannel,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandleSubscriptionInsertAsync(resource, properties, cancellationToken).ConfigureAwait(false);
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
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var handler = await Handlers.GetHandlerAsync<SubscriptionHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("SubscriptionHandler could not be obtained.");

        var properties = new SubscriptionProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleSubscriptionDeleteAsync(properties, cancellationToken).ConfigureAwait(false);
        if (result.Succeeded)
        {
            return;
        }

        throw new NotImplementedException("@TODO");
    }
}
