// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

public class YouTubeCaptions(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IYouTubeCaptions
{

    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public async Task DeleteAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id);

        var handler = await Handlers.GetHandlerAsync<YouTubeCaptionHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        // Implement the deletion logic using the handler
        await handler.HandleCaptionDeleteAsync(new YouTubeCaptionProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        }, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Stream> DownloadAsync(string id, string? onBehalfOfContentOwner = null, string? tfmt = null, string? tlang = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id);

        var handler = await Handlers.GetHandlerAsync<YouTubeCaptionHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        // Implement the deletion logic using the handler
        var result = await handler.HandleCaptionDownloadAsync(new YouTubeCaptionProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        }, cancellationToken).ConfigureAwait(false);

        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<YouTubeCaptionResource> InsertAsync(StringValues part, YouTubeCaptionResource resource, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalInsertAsync(part, null, resource, null, null, cancellationToken);
    }

    public Task<YouTubeCaptionResource> InsertAsync(StringValues part, string onBehalfOfContentOwner, YouTubeCaptionResource resource, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalInsertAsync(part, onBehalfOfContentOwner, resource, null, null, cancellationToken);
    }

    public Task<YouTubeCaptionResource> InsertAsync(StringValues part, YouTubeCaptionResource resource, Stream stream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalInsertAsync(part, null, resource, stream, "application/octet-stream", cancellationToken);
    }

    public Task<YouTubeCaptionResource> InsertAsync(StringValues part, string onBehalfOfContentOwner, YouTubeCaptionResource resource, Stream stream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalInsertAsync(part, null, resource, stream, "application/octet-stream", cancellationToken);
    }

    public Task<YouTubeCaptionResource> InsertAsync(StringValues part, string onBehalfOfContentOwner, YouTubeCaptionResource resource, Stream stream, string contentType, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalInsertAsync(part, onBehalfOfContentOwner, resource, stream, contentType, cancellationToken);
    }

    public async Task<YouTubeCaptionListResource> ListAsync(StringValues part, string videoId, string? id = null, string? onBehalfOfContentOwner = null, CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubeCaptionHandler>()
                   .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var result = await handler.HandleCaptionListAsync(new YouTubeCaptionProperties
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
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<YouTubeCaptionResource> UpdateAsync(StringValues part, YouTubeCaptionResource resource, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalUpdateAsync(part, null, resource, null, null, cancellationToken);
    }

    public Task<YouTubeCaptionResource> UpdateAsync(StringValues part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalUpdateAsync(part, onBehalfOfContentOwner, resource, null, null, cancellationToken);
    }

    public Task<YouTubeCaptionResource> UpdateAsync(StringValues part, YouTubeCaptionResource resource, Stream stream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalUpdateAsync(part, null, resource, stream, "application/octet-stream", cancellationToken);
    }

    public Task<YouTubeCaptionResource> UpdateAsync(StringValues part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, Stream stream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalUpdateAsync(part, onBehalfOfContentOwner, resource, stream, null, cancellationToken);
    }

    public Task<YouTubeCaptionResource> UpdateAsync(StringValues part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, Stream stream, string contentType, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(onBehalfOfContentOwner);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(stream);

        return InternalUpdateAsync(part, onBehalfOfContentOwner, resource, stream, contentType, cancellationToken);
    }

    private async Task<YouTubeCaptionResource> InternalInsertAsync(
        StringValues part,
        string? onBehalfOfContentOwner,
        YouTubeCaptionResource resource,
        Stream? stream,
        string? contentType,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubeCaptionHandler>()
                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var properties = new YouTubeCaptionProperties
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
            false => throw new NotImplementedException("@TODO")
        };
    }

    private async Task<YouTubeCaptionResource> InternalUpdateAsync(
      StringValues part,
      string? onBehalfOfContentOwner,
      YouTubeCaptionResource resource,
      Stream? stream,
      string? contentType,
      CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubeCaptionHandler>()
                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var properties = new YouTubeCaptionProperties
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
            false => throw new NotImplementedException("@TODO")
        };
    }
}