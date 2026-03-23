// Licensed under the MIT license by loonfactory.

using System.Net.Mime;

namespace Loonfactory.Google.Apis.YouTube.V3.Watermarks;

/// <summary>
/// Provides methods for setting and unsetting YouTube channel watermarks.
/// </summary>
public class WatermarkService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : IWatermarkService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers ?? throw new ArgumentNullException(nameof(handlers));
    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider ?? throw new ArgumentNullException(nameof(accessTokenProvider));

    /// <inheritdoc />
    public Task SetAsync(
        string channelId,
        WatermarkResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(channelId);
        ArgumentNullException.ThrowIfNull(resource);

        if (resource.ImageBytes is null || !resource.ImageBytes.Any())
        {
            throw new ArgumentException("resource.ImageBytes must be provided for metadata upload.", nameof(resource));
        }

        return InternalSetUploadAsync(
            channelId,
            resource,
            onBehalfOfContentOwner,
            cancellationToken);
    }

    /// <inheritdoc />
    public Task SetAsync(
        string channelId,
        WatermarkResource resource,
        Stream stream,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(channelId);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return SetAsync(
            channelId,
            resource,
            stream,
            MediaTypeNames.Application.Octet,
            onBehalfOfContentOwner,
            cancellationToken);
    }

    /// <inheritdoc />
    public Task SetAsync(
        string channelId,
        WatermarkResource resource,
        Stream stream,
        string contentType,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(channelId);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentException.ThrowIfNullOrWhiteSpace(contentType);

        var mediaType = contentType.Split(';', 2)[0].Trim();
        if (!WatermarkDefaults.AllowedUploadContentTypes.Contains(mediaType))
        {
            var allowed = string.Join(", ", WatermarkDefaults.AllowedUploadContentTypes.OrderBy(x => x, StringComparer.Ordinal));
            throw new ArgumentException($"contentType must be one of: {allowed}.", nameof(contentType));
        }

        return InternalSetStreamUploadAsync(
            channelId,
            resource,
            stream,
            contentType,
            onBehalfOfContentOwner,
            cancellationToken
        );
    }

    /// <inheritdoc />
    public Task UnsetAsync(
        string channelId,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(channelId);

        return InternalUnsetAsync(channelId, onBehalfOfContentOwner, cancellationToken);
    }

    private async Task InternalSetUploadAsync(
       string channelId,
       WatermarkResource resource,
       string? onBehalfOfContentOwner,
       CancellationToken cancellationToken
    )
    {
        var handler = await Handlers.GetHandlerAsync<WatermarkHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("WatermarkHandler could not be obtained.");

        var token = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("Access token could not be obtained.");
        }

        var properties = new WatermarkProperties
        {
            ChannelId = channelId,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = token,
        };

        var result = await handler.HandleSetUploadAsync(resource, properties, cancellationToken)
            .ConfigureAwait(false);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Watermark set request failed. [TODO: unify error handling]");
        }
    }

    private async Task InternalSetStreamUploadAsync(
       string channelId,
       WatermarkResource resource,
       Stream stream,
       string contentType,
       string? onBehalfOfContentOwner,
       CancellationToken cancellationToken
    )
    {
        var handler = await Handlers.GetHandlerAsync<WatermarkHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("WatermarkHandler could not be obtained.");

        var token = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("Access token could not be obtained.");
        }

        var properties = new WatermarkProperties
        {
            ChannelId = channelId,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = token,
        };

        var result = await handler.HandleSetStreamUploadAsync(resource, stream, contentType, properties, cancellationToken)
            .ConfigureAwait(false);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Watermark set request failed. [TODO: unify error handling]");
        }
    }

    private async Task InternalUnsetAsync(
        string channelId,
        string? onBehalfOfContentOwner,
        CancellationToken cancellationToken
    )
    {
        var handler = await Handlers.GetHandlerAsync<WatermarkHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("WatermarkHandler could not be obtained.");

        var token = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("Access token could not be obtained.");
        }

        var properties = new WatermarkProperties
        {
            ChannelId = channelId,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = token,
        };

        var result = await handler.HandleUnsetAsync(properties, cancellationToken)
            .ConfigureAwait(false);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Watermark unset request failed. [TODO: unify error handling]");
        }
    }
}
