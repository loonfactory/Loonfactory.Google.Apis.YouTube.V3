// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

public class YouTubeCaptions(
    IAuthenticationSchemeProvider schemeProvider,
    IYouTubeHandlerProvider handlers,
    IOptions<YouTubeOptions> options,
    IAccessTokenProvider accessTokenProvider,
    IHttpContextAccessor? httpContextAccessor = null) : IYouTubeCaptions
{
    public IAuthenticationSchemeProvider SchemeProvider { get; } = schemeProvider;

    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    /// <summary>
    /// The <see cref="YouTubeOptions"/>.
    /// </summary>
    public YouTubeOptions Options { get; } = options?.Value ?? throw new ArgumentNullException(nameof(options));

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;
  
    /// <summary>
    /// Gets the <see cref="IHttpContextAccessor"/>.
    /// </summary>
    public IHttpContextAccessor? HttpContextAccessor { get; } = httpContextAccessor;

    public async Task DeleteAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
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

    public Task<Stream> DownloadAsync(string id, string? onBehalfOfContentOwner = null, string? tfmt = null, string? tlang = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> InsertAsync(IEnumerable<string> part, YouTubeCaptionResource resource, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> InsertAsync(IEnumerable<string> part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> InsertAsync(IEnumerable<string> part, YouTubeCaptionResource resource, Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> InsertAsync(IEnumerable<string> part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> InsertAsync(IEnumerable<string> part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, Stream stream, string contentType, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionListResource> ListAsync(IEnumerable<string> part, string videoId, string? id = null, string? onBehalfOfContentOwner = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> UpdateAsync(IEnumerable<string> part, YouTubeCaptionResource resource, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> UpdateAsync(IEnumerable<string> part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> UpdateAsync(IEnumerable<string> part, YouTubeCaptionResource resource, Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> UpdateAsync(IEnumerable<string> part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<YouTubeCaptionResource> UpdateAsync(IEnumerable<string> part, string? onBehalfOfContentOwner, YouTubeCaptionResource resource, Stream stream, string contentType, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}