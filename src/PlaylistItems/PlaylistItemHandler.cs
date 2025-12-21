// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;

public class PlaylistItemHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), IPlaylistItemHandler
{
    public virtual async Task<YouTubeResult<PlaylistItemListResponse>> HandlePlaylistItemListAsync(
        PlaylistItemProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var response = await SendAsync(
            HttpMethod.Get,
            PlaylistItemDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<PlaylistItemListResponse>.Success(
            (await response.Content.ReadFromJsonAsync<PlaylistItemListResponse>(
                YouTubeDefaults.JsonSerializerOptions,
                cancellationToken
            ).ConfigureAwait(false))!
        );
    }

    public virtual Task<YouTubeResult<PlaylistItemResource>> HandlePlaylistItemInsertAsync(
        PlaylistItemResource resource,
        PlaylistItemProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(PlaylistItemDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandlePlaylistItemUploadAsync(request, resource, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<PlaylistItemResource>> HandlePlaylistItemUpdateAsync(
        PlaylistItemResource resource,
        PlaylistItemProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The playlist item id must be set on the resource.");
        }

        var endpoint = BuildChallengeUrl(PlaylistItemDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return InternalHandlePlaylistItemUploadAsync(request, resource, properties, cancellationToken);
    }

    private Task<YouTubeResult<PlaylistItemResource>> InternalHandlePlaylistItemUploadAsync(
        HttpRequestMessage request,
        PlaylistItemResource resource,
        PlaylistItemProperties properties,
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

    public virtual async Task<YouTubeResult> HandlePlaylistItemDeleteAsync(
        PlaylistItemProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The playlist item id must be provided in the properties.");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Delete,
            PlaylistItemDefaults.DeleteEndpoint,
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
