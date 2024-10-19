// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

public class YouTubeCaptions(IHttpContextAccessor httpContextAccessor, IYouTubeHandlerProvider handlers, IOptions<YouTubeOptions> options) : IYouTubeCaptions
{
    public IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;

    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    /// <summary>
    /// The <see cref="YouTubeOptions"/>.
    /// </summary>
    public YouTubeOptions Options { get; } = options.Value;

    public async Task DeleteAsync(
        string id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        var context = HttpContextAccessor.HttpContext ?? throw new InvalidOperationException("The HTTP context is not available. Ensure that 'IHttpContextAccessor' is properly configured and that the current request context is accessible. This typically occurs when trying to access the context outside of an active HTTP request pipeline.");
        var handler = await Handlers.GetHandlerAsync(context).ConfigureAwait(false) ?? throw new InvalidOperationException("No YouTube handler is registered.");      
    }

    public async Task<Stream> DownloadAsync(string id, string? onBehalfOfContentOwner = null, string? tfmt = null, string? tlang = null, CancellationToken cancellationToken = default)
    {
        var context = HttpContextAccessor.HttpContext ?? throw await CreateMissingHandlerException(scheme);

        var handler = await Handlers.GetHandlerAsync(HttpContextAccessor.HttpContext).ConfigureAwait(false) ?? throw await CreateMissingHandlerException(scheme);
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