// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

public class PlaylistItemHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IPlaylistItemHandler
{
    public virtual Task<YouTubeResult<PlaylistItemListResponse>> HandlePlaylistItemListAsync(
        PlaylistItemProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        return ExecuteAsync<PlaylistItemListResponse>(
            HttpMethod.Get,
            PlaylistItemDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<PlaylistItemResource>> HandlePlaylistItemInsertAsync(
        PlaylistItemResource resource,
        PlaylistItemProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        var endpoint = BuildChallengeUrl(PlaylistItemDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<PlaylistItemResource>(request, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<PlaylistItemResource>> HandlePlaylistItemUpdateAsync(
        PlaylistItemResource resource,
        PlaylistItemProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The playlist item id must be set on the resource.");
        }

        var endpoint = BuildChallengeUrl(PlaylistItemDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<PlaylistItemResource>(request, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult> HandlePlaylistItemDeleteAsync(
        PlaylistItemProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The playlist item id must be provided in the properties.");
        }

        return AuthorizationExecuteAsync(
            HttpMethod.Delete,
            PlaylistItemDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        );
    }
}

