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
        throw new NotImplementedException();
    }

    public async Task<Stream> DownloadAsync(string id, string? onBehalfOfContentOwner = null, string? tfmt = null, string? tlang = null, CancellationToken cancellationToken = default)
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