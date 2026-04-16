// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

/// <summary>
/// Provides functionality to handle YouTube ChannelSection operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of <see cref="ChannelSectionHandler" />.
/// </remarks>
/// <param name="options">The monitor for the options instance.</param>
/// <param name="logger">The <see cref="ILoggerFactory"/>.</param>
public class ChannelSectionHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IChannelSectionHandler
{
    /// <summary>
    /// Asynchronously handles the deletion of a YouTube ChannelSection.
    /// </summary>
    /// <param name="properties">The <see cref="ChannelSectionProperties"/> required for ChannelSection deletion.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="properties"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when required properties are missing or invalid.</exception>
    public virtual Task<YouTubeResult> HandleChannelSectionDeleteAsync(
        ChannelSectionProperties properties,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The ChannelSection id must be provided in the properties.");
        }

        return AuthorizationExecuteAsync(
            HttpMethod.Delete,
            ChannelSectionDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<ChannelSectionListResponse>> HandleChannelSectionListAsync(
        ChannelSectionProperties properties,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(properties);

        return ExecuteAsync<ChannelSectionListResponse>(
            HttpMethod.Get,
            ChannelSectionDefaults.ListEndpoint,
            properties,
            cancellationToken
        );

    }

    public virtual Task<YouTubeResult<ChannelSectionResource>> HandleChannelSectionInsertAsync(
        ChannelSectionResource resource,
        ChannelSectionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        var endpoint = BuildChallengeUrl(ChannelSectionDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<ChannelSectionResource>(request, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<ChannelSectionResource>> HandleChannelSectionUpdateAsync(
        ChannelSectionResource resource,
        ChannelSectionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The ChannelSection id must be provided in the resource.");
        }

        var endpoint = BuildChallengeUrl(ChannelSectionDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<ChannelSectionResource>(request, properties, cancellationToken);
    }
}