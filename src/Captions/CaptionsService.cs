// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Implements <see cref="ICaptionsService"/> using caption handlers.
/// </summary>
/// <param name="handlers">The handler provider.</param>
/// <param name="accessTokenProvider">The OAuth access token provider.</param>
public class CaptionsService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : ICaptionsService
{

    /// <summary>
    /// Gets the provider used to resolve caption handlers.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    /// <summary>
    /// Gets the OAuth access token provider.
    /// </summary>
    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    /// <inheritdoc />
    public async Task DeleteAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id);

        var handler = await Handlers.GetHandlerAsync<CaptionHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");
        var result = await handler.HandleCaptionDeleteAsync(new CaptionProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        }, cancellationToken).ConfigureAwait(false);

        if (!result.Succeeded)
        {
            throw result.FailureOrDefault;
        }
    }

    /// <inheritdoc />
    public async Task<Stream> DownloadAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        string? tfmt = null,
        string? tlang = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(id);

        var handler = await Handlers.GetHandlerAsync<CaptionHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");
        var result = await handler.HandleCaptionDownloadAsync(new CaptionProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            Tfmt = tfmt,
            Tlang = tlang,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        }, cancellationToken).ConfigureAwait(false);

        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw result.FailureOrDefault
        };
    }

    /// <inheritdoc />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        CaptionResource resource,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalInsertAsync(part, null, resource, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalInsertAsync(part, onBehalfOfContentOwner, resource, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        CaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalInsertAsync(part, null, resource, stream, "application/octet-stream", cancellationToken);
    }

    /// <inheritdoc />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalInsertAsync(part, onBehalfOfContentOwner, resource, stream, "application/octet-stream", cancellationToken);
    }

    /// <inheritdoc />
    public Task<CaptionResource> InsertAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalInsertAsync(part, onBehalfOfContentOwner, resource, stream, contentType, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CaptionListResponse> ListAsync(
        StringValues part,
        string videoId,
        string? id = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default
    )
    {
        var handler = await Handlers.GetHandlerAsync<CaptionHandler>()
                   .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var result = await handler.HandleCaptionListAsync(new CaptionProperties
        {
            VideoId = videoId,
            Part = part,
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        }, cancellationToken).ConfigureAwait(false);

        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw result.FailureOrDefault
        };
    }

    /// <inheritdoc />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        CaptionResource resource,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalUpdateAsync(part, null, resource, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalUpdateAsync(part, onBehalfOfContentOwner, resource, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        CaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalUpdateAsync(part, null, resource, stream, "application/octet-stream", cancellationToken);
    }

    /// <inheritdoc />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        Stream stream,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalUpdateAsync(part, onBehalfOfContentOwner, resource, stream, null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<CaptionResource> UpdateAsync(
        StringValues part,
        string onBehalfOfContentOwner,
        CaptionResource resource,
        Stream stream,
        string contentType,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalUpdateAsync(part, onBehalfOfContentOwner, resource, stream, contentType, cancellationToken);
    }

    private async Task<CaptionResource> InternalInsertAsync(
        StringValues part,
        string? onBehalfOfContentOwner,
        CaptionResource resource,
        Stream? stream,
        string? contentType,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<CaptionHandler>()
                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var properties = new CaptionProperties
        {
            Part = part,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        StreamContent? content = null;
        if (stream != null)
        {
            content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType ?? "application/octet-stream");
        }

        var result = await handler.HandleCaptionInsertAsync(resource, content, properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw result.FailureOrDefault
        };
    }

    private async Task<CaptionResource> InternalUpdateAsync(
      StringValues part,
      string? onBehalfOfContentOwner,
      CaptionResource resource,
      Stream? stream,
      string? contentType,
      CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<CaptionHandler>()
                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var properties = new CaptionProperties
        {
            Part = part,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        StreamContent? content = null;
        if (stream != null)
        {
            content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType ?? "application/octet-stream");
        }

        var result = await handler.HandleCaptionUpdateAsync(resource, content, properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw result.FailureOrDefault
        };
    }
}
