// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Subscriptions;

public class SubscriptionHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : YouTubeHandler(options, logger, encoder), ISubscriptionHandler
{
    public virtual async Task<YouTubeResult<SubscriptionListResource>> HandleSubscriptionListAsync(
        SubscriptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var response = await SendAsync(
            HttpMethod.Get,
            SubscriptionDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<SubscriptionListResource>.Success(
            (await response.Content.ReadFromJsonAsync<SubscriptionListResource>(
                YouTubeDefaults.JsonSerializerOptions,
                cancellationToken
            ).ConfigureAwait(false))!
        );
    }

    public virtual Task<YouTubeResult<SubscriptionResource>> HandleSubscriptionInsertAsync(
        SubscriptionResource resource,
        SubscriptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(SubscriptionDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandleSubscriptionUploadAsync(request, resource, properties, cancellationToken);
    }
    private Task<YouTubeResult<SubscriptionResource>> InternalHandleSubscriptionUploadAsync(
        HttpRequestMessage request,
        SubscriptionResource resource,
        SubscriptionProperties properties,
        CancellationToken cancellationToken)
    {
        return UploadAsync(
            request,
            resource,
            content: null,
            properties,
            cancellationToken
        );
    }

    public virtual async Task<YouTubeResult> HandleSubscriptionDeleteAsync(
        SubscriptionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The playlist item id must be provided in the properties.");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Delete,
            SubscriptionDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult.NoResult,
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}
