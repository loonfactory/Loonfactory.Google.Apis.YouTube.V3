// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public class PlaylistHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IPlaylistHandler
{
    public virtual Task<YouTubeResult<PlaylistListResponse>> HandlePlaylistListAsync(
        PlaylistProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        return ExecuteAsync<PlaylistListResponse>(
            HttpMethod.Get,
            YouTubePlaylistDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<PlaylistResource>> HandlePlaylistInsertAsync(
        PlaylistResource resource,
        PlaylistProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        var endpoint = BuildChallengeUrl(YouTubePlaylistDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<PlaylistResource>(request, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<PlaylistResource>> HandlePlaylistUpdateAsync(
        PlaylistResource resource,
        PlaylistProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The playlist item id must be set on the resource.");
        }

        var endpoint = BuildChallengeUrl(YouTubePlaylistDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<PlaylistResource>(request, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult> HandlePlaylistDeleteAsync(
        PlaylistProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The playlist item id must be provided in the properties.");
        }

        return AuthorizationExecuteAsync(
            HttpMethod.Delete,
            YouTubePlaylistDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        );
    }
}
