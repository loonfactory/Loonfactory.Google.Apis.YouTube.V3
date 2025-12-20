// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Playlists;

public class PlaylistHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : YouTubeHandler(options, logger, encoder), IPlaylistHandler
{
    public virtual async Task<YouTubeResult<PlaylistListResponse>> HandlePlaylistListAsync(
        PlaylistProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var response = await SendAsync(
            HttpMethod.Get,
            YouTubePlaylistDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<PlaylistListResponse>.Success(
            (await response.Content.ReadFromJsonAsync<PlaylistListResponse>(
                YouTubeDefaults.JsonSerializerOptions,
                cancellationToken
            ).ConfigureAwait(false))!
        );
    }

    public virtual Task<YouTubeResult<PlaylistResource>> HandlePlaylistInsertAsync(
        PlaylistResource resource,
        PlaylistProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(YouTubePlaylistDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandlePlaylistUploadAsync(request, resource, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<PlaylistResource>> HandlePlaylistUpdateAsync(
        PlaylistResource resource,
        PlaylistProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The playlist item id must be set on the resource.");
        }

        var endpoint = BuildChallengeUrl(YouTubePlaylistDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return InternalHandlePlaylistUploadAsync(request, resource, properties, cancellationToken);
    }

    private Task<YouTubeResult<PlaylistResource>> InternalHandlePlaylistUploadAsync(
        HttpRequestMessage request,
        PlaylistResource resource,
        PlaylistProperties properties,
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

    public virtual async Task<YouTubeResult> HandlePlaylistDeleteAsync(
        PlaylistProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The playlist item id must be provided in the properties.");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Delete,
            YouTubePlaylistDefaults.DeleteEndpoint,
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
