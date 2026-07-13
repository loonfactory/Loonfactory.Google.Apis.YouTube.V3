// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public class CommentHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger)
    : YouTubeHandler(options, logger), ICommentHandler
{
    public virtual Task<YouTubeResult> HandleCommentDeleteAsync(CommentProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The Comment id must be provided in the properties.");
        }

        return AuthorizationExecuteAsync(
            HttpMethod.Delete,
            CommentDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<CommentListResponse>> HandleCommentListAsync(CommentProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        return ExecuteAsync<CommentListResponse>(
            HttpMethod.Get,
            CommentDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<CommentResource>> HandleCommentInsertAsync(
        CommentResource resource,
        CommentProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        var endpoint = BuildChallengeUrl(CommentDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<CommentResource>(request, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<CommentResource>> HandleCommentUpdateAsync(
        CommentResource resource,
        CommentProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The Comment id must be provided in the resource.");
        }

        var endpoint = BuildChallengeUrl(CommentDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<CommentResource>(request, properties, cancellationToken);
    }

    public Task<YouTubeResult> HandleSetModerationStatus(CommentProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        return AuthorizationExecuteAsync(
            HttpMethod.Post,
            CommentDefaults.SetModerationStatusEndpoint,
            properties,
            cancellationToken
        );
    }
}
