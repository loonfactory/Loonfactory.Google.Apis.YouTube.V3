// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Subscriptions;

public interface ISubscriptionService
{
    Task<SubscriptionListResponse> ListByChannelIdAsync(
        StringValues part,
        string channelId,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<SubscriptionListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<SubscriptionListResponse> ListByMineAsync(
        StringValues part,
        bool mine,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<SubscriptionListResponse> ListByMyRecentSubscribersAsync(
        StringValues part,
        bool myRecentSubscribers,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<SubscriptionListResponse> ListByMySubscribersAsync(
        StringValues part,
        bool mySubscribers,
        uint? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        string? order = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default);

    Task<SubscriptionResource> InsertAsync(
        StringValues part,
        SubscriptionResource resource,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default);
}
