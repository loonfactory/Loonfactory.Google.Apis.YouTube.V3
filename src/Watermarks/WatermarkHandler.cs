// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Watermarks;

/// <inheritdoc />
public class WatermarkHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IWatermarkHandler
{
    /// <inheritdoc />
    public virtual Task<YouTubeResult> HandleSetAsync(
        WatermarkResource resource,
        Stream stream,
        string contentType,
        WatermarkProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentException.ThrowIfNullOrWhiteSpace(contentType);

        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);
        if (string.IsNullOrWhiteSpace(properties.ChannelId))
        {
            throw new ArgumentException("The channelId must be provided in the properties.", nameof(properties));
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
            !WatermarkDefaults.AllowedUploadContentTypes.Contains(mediaTypeHeader.MediaType))
        {
            var allowed = string.Join(", ", WatermarkDefaults.AllowedUploadContentTypes.OrderBy(x => x, StringComparer.Ordinal));
            throw new ArgumentException($"contentType must be one of: {allowed}.", nameof(contentType));
        }

        return InternalHandleSetAsync(resource, stream, mediaTypeHeader, properties, cancellationToken);
    }

    /// <inheritdoc />
    public virtual async Task<YouTubeResult> HandleUnsetAsync(
        WatermarkProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);
        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);
        if (string.IsNullOrWhiteSpace(properties.ChannelId))
        {
            throw new ArgumentException("The channelId must be provided in the properties.", nameof(properties));
        }

        using var response = await AuthorizationSendAsync(
            HttpMethod.Post,
            WatermarkDefaults.UnsetEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Watermark unset request failed. [TODO: unify error handling]");
        }

        return YouTubeResult.NoResult;
    }

    private async Task<YouTubeResult> InternalHandleSetAsync(
        WatermarkResource resource,
        Stream stream,
        MediaTypeHeaderValue mediaTypeHeader,
        WatermarkProperties properties,
        CancellationToken cancellationToken)
    {
        var endpoint = BuildChallengeUrl(WatermarkDefaults.SetEndpoint, properties);
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        using var jsonContent = JsonContent.Create(resource);
        using var streamContent = new StreamContent(stream);
        streamContent.Headers.ContentType = mediaTypeHeader;

        using var multipart = new MultipartContent("related")
        {
            jsonContent,
            streamContent
        };

        request.Content = multipart;

        using var response = await AuthorizationSendAsync(request, properties, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Watermark set request failed. [TODO: unify error handling]");
        }

        return YouTubeResult.NoResult;
    }
}
