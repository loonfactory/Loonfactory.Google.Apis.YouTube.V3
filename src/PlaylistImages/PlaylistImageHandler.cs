// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public class PlaylistImageHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IPlaylistImageHandler
{
    public virtual Task<YouTubeResult<PlaylistImageListResponse>> HandlePlaylistImageListAsync(
        PlaylistImageProperties properties,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(properties);

        return AuthorizationExecuteAsync<PlaylistImageListResponse>(
            HttpMethod.Get,
            PlaylistImageDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<PlaylistImageResource>> HandlePlaylistImageInsertAsync(
        PlaylistImageResource resource,
        StreamContent content,
        PlaylistImageProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        var endpoint = BuildChallengeUrl(PlaylistImageDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return UploadAsync(request, resource, content, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<PlaylistImageResource>> HandlePlaylistImageUpdateAsync(
        PlaylistImageResource resource,
        StreamContent content,
        PlaylistImageProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The PlaylistImage id must be provided in the resource.");
        }

        var endpoint = BuildChallengeUrl(PlaylistImageDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return UploadAsync(request, resource, content, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult> HandlePlaylistImageDeleteAsync(PlaylistImageProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The PlaylistImage id must be provided in the properties.");
        }

        return AuthorizationExecuteAsync(
            HttpMethod.Delete,
            PlaylistImageDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        );
    }
}
