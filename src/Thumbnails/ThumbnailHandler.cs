// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

/// <inheritdoc />
public class ThumbnailHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), IThumbnailHandler
{
    /// <inheritdoc />
    public virtual Task<YouTubeResult<ThumbnailSetResponse>> HandleSetAsync(
        Stream stream,
        string contentType,
        ThumbnailProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentException.ThrowIfNullOrWhiteSpace(contentType);

        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);
        if (string.IsNullOrWhiteSpace(properties.VideoId))
        {
            throw new ArgumentException("The videoId must be provided in the properties.", nameof(properties));
        }

        if (!stream.CanRead)
        {
            throw new ArgumentException("stream must be readable.", nameof(stream));
        }

        if (!MediaTypeHeaderValue.TryParse(contentType, out var mediaTypeHeader))
        {
            throw new ArgumentException("Invalid contentType.", nameof(contentType));
        }

        if (mediaTypeHeader.MediaType is null ||
            !ThumbnailDefaults.AllowedUploadContentTypes.Contains(mediaTypeHeader.MediaType))
        {
            var allowed = string.Join(", ", ThumbnailDefaults.AllowedUploadContentTypes.OrderBy(x => x, StringComparer.Ordinal));
            throw new ArgumentException($"contentType must be one of: {allowed}.", nameof(contentType));
        }

        return InternalHandleSetAsync(stream, mediaTypeHeader, properties, cancellationToken);
    }

    private async Task<YouTubeResult<ThumbnailSetResponse>> InternalHandleSetAsync(
        Stream stream,
        MediaTypeHeaderValue mediaTypeHeader,
        ThumbnailProperties properties,
        CancellationToken cancellationToken)
    {
        var endpoint = BuildChallengeUrl(ThumbnailDefaults.SetEndpoint, properties);
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        using var streamContent = new StreamContent(stream);
        streamContent.Headers.ContentType = mediaTypeHeader;
        request.Content = streamContent;

        using var response = await AuthorizationSendAsync(request, properties, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            //@TODO: Implement error handling
            throw new InvalidOperationException("Thumbnail upload failed. [TODO: unify error handling]");
        }

        var result = await response.Content.ReadFromJsonAsync<ThumbnailSetResponse>(
            YouTubeDefaults.JsonSerializerOptions,
            cancellationToken
        ).ConfigureAwait(false) ?? throw new InvalidOperationException("Thumbnail upload failed. [TODO: unify error handling]");

        return YouTubeResult<ThumbnailSetResponse>.Success(result);
    }

}
