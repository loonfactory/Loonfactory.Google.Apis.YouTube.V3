// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Subscriptions;

public class SubscriptionHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), ISubscriptionHandler
{
    public virtual Task<YouTubeResult<SubscriptionListResponse>> HandleSubscriptionListAsync(
        SubscriptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        return ExecuteAsync<SubscriptionListResponse>(
            HttpMethod.Get,
            SubscriptionDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<SubscriptionResource>> HandleSubscriptionInsertAsync(
        SubscriptionResource resource,
        SubscriptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        var endpoint = BuildChallengeUrl(SubscriptionDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<SubscriptionResource>(request, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult> HandleSubscriptionDeleteAsync(
        SubscriptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The subscription id must be provided in the properties.");
        }

        return AuthorizationExecuteAsync(
            HttpMethod.Delete,
            SubscriptionDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        );
    }
}
