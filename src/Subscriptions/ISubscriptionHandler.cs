// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Subscriptions;

public interface ISubscriptionHandler : IYouTubeHandler
{
    Task<YouTubeResult<SubscriptionListResponse>> HandleSubscriptionListAsync(
        SubscriptionProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult<SubscriptionResource>> HandleSubscriptionInsertAsync(
        SubscriptionResource resource,
        SubscriptionProperties properties,
        CancellationToken cancellationToken);

    Task<YouTubeResult> HandleSubscriptionDeleteAsync(
        SubscriptionProperties properties,
        CancellationToken cancellationToken);
}
