// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public class YouTubePlaylistImageHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : YouTubeHandler(options, logger, encoder), IYouTubePlaylistImageHandler
{
    public virtual async Task<YouTubeResult<YouTubePlaylistImageListResource>> HandlePlaylistImageListAsync(
        YouTubePlaylistImageProperties properties,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(properties);
        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);

        var response = await AuthorizationSendAsync(
            HttpMethod.Get,
            YouTubePlaylistImageDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<YouTubePlaylistImageListResource>.Success(
            (await response.Content.ReadFromJsonAsync<YouTubePlaylistImageListResource>(
                YouTubeDefaults.JsonSerializerOptions, 
                cancellationToken
            ).ConfigureAwait(false))!
        );
    }

    public virtual Task<YouTubeResult<YouTubePlaylistImageResource>> HandlePlaylistImageInsertAsync(
        YouTubePlaylistImageResource resource,
        StreamContent content,
        YouTubePlaylistImageProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(YouTubePlaylistImageDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandlePlaylistImageUploadAsync(request, resource, content, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<YouTubePlaylistImageResource>> HandlePlaylistImageUpdateAsync(
        YouTubePlaylistImageResource resource,
        StreamContent content,
        YouTubePlaylistImageProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("@TODO");
        }

        var endpoint = BuildChallengeUrl(YouTubePlaylistImageDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return InternalHandlePlaylistImageUploadAsync(request, resource, content, properties, cancellationToken);
    }

    private Task<YouTubeResult<YouTubePlaylistImageResource>> InternalHandlePlaylistImageUploadAsync(
        HttpRequestMessage request,
        YouTubePlaylistImageResource resource,
        StreamContent content,
        YouTubePlaylistImageProperties properties,
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

    public virtual async Task<YouTubeResult> HandlePlaylistImageDeleteAsync(YouTubePlaylistImageProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The PlaylistImage id must be provided in the properties.");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Delete,
            YouTubePlaylistImageDefaults.DeleteEndpoint,
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