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
    public virtual Task<YouTubeResult> HandleSetUploadAsync(
        WatermarkResource resource,
        WatermarkProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);
        if (string.IsNullOrWhiteSpace(properties.ChannelId))
        {
            throw new ArgumentException("The channelId must be provided in the properties.", nameof(properties));
        }

        if (resource.ImageBytes is null || resource.ImageBytes.Length == 0)
        {
            throw new ArgumentException("resource.ImageBytes must be provided for metadata upload.", nameof(resource));
        }

        return InternalHandleSetUploadAsync(resource, properties, cancellationToken);
    }

    /// <inheritdoc />
    public virtual Task<YouTubeResult> HandleSetStreamUploadAsync(
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

        return InternalHandleSetStreamUploadAsync(resource, stream, mediaTypeHeader, properties, cancellationToken);
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

        using var request = CreateHttpRequestMessage(
            HttpMethod.Post,
            WatermarkDefaults.UnsetEndpoint,
            properties
        );

        using var response = await AuthorizationSendAsync(
            request,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Watermark unset request failed. [TODO: unify error handling]");
        }

        return YouTubeResult.NoResult;
    }

    private async Task<YouTubeResult> InternalHandleSetUploadAsync(
        WatermarkResource resource,
        WatermarkProperties properties,
        CancellationToken cancellationToken)
    {
        var endpoint = BuildChallengeUrl(WatermarkDefaults.SetEndpoint, properties);
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        request.Content = JsonContent.Create(resource, options: YouTubeDefaults.JsonSerializerOptions);

        using var response = await AuthorizationSendAsync(request, properties, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Watermark set request failed. [TODO: unify error handling]");
        }

        return YouTubeResult.NoResult;
    }

    private async Task<YouTubeResult> InternalHandleSetStreamUploadAsync(
        WatermarkResource resource,
        Stream stream,
        MediaTypeHeaderValue mediaTypeHeader,
        WatermarkProperties properties,
        CancellationToken cancellationToken)
    {
        var endpoint = BuildChallengeUrl(WatermarkDefaults.SetUploadEndpoint, properties);
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        var metadataResource = new WatermarkResource
        {
            Timing = resource.Timing,
            Position = resource.Position,
            ImageUrl = resource.ImageUrl,
            ImageBytes = null,
            TargetChannelId = resource.TargetChannelId,
        };

        var jsonContent = JsonContent.Create(metadataResource, options: YouTubeDefaults.JsonSerializerOptions);
        var streamContent = new StreamContent(stream);
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
