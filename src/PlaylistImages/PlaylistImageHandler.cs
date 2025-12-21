// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public class PlaylistImageHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), IPlaylistImageHandler
{
    public virtual async Task<YouTubeResult<PlaylistImageListResponse>> HandlePlaylistImageListAsync(
        PlaylistImageProperties properties,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(properties);
        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);

        var response = await AuthorizationSendAsync(
            HttpMethod.Get,
            PlaylistImageDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<PlaylistImageListResponse>.Success(
            (await response.Content.ReadFromJsonAsync<PlaylistImageListResponse>(
                YouTubeDefaults.JsonSerializerOptions,
                cancellationToken
            ).ConfigureAwait(false))!
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
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(PlaylistImageDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandlePlaylistImageUploadAsync(request, resource, content, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<PlaylistImageResource>> HandlePlaylistImageUpdateAsync(
        PlaylistImageResource resource,
        StreamContent content,
        PlaylistImageProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("@TODO");
        }

        var endpoint = BuildChallengeUrl(PlaylistImageDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return InternalHandlePlaylistImageUploadAsync(request, resource, content, properties, cancellationToken);
    }

    private Task<YouTubeResult<PlaylistImageResource>> InternalHandlePlaylistImageUploadAsync(
        HttpRequestMessage request,
        PlaylistImageResource resource,
        StreamContent content,
        PlaylistImageProperties properties,
        CancellationToken cancellationToken)
    {
        return UploadAsync(
            request,
            resource,
            content,
            properties,
            cancellationToken
        );
    }

    public virtual async Task<YouTubeResult> HandlePlaylistImageDeleteAsync(PlaylistImageProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The PlaylistImage id must be provided in the properties.");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Delete,
            PlaylistImageDefaults.DeleteEndpoint,
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