// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

public class CommentThreadHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), ICommentThreadHandler
{
    public virtual Task<YouTubeResult<CommentListResponse>> HandleCommentThreadListAsync(CommentThreadProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        return ExecuteAsync<CommentListResponse>(
            HttpMethod.Get,
            CommentThreadDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }

    public virtual Task<YouTubeResult<CommentThreadResource>> HandleCommentThreadInsertAsync(
        CommentThreadResource resource,
        CommentThreadProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        var endpoint = BuildChallengeUrl(CommentThreadDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = JsonContent.Create(resource)
        };
        return AuthorizationExecuteAsync<CommentThreadResource>(request, properties, cancellationToken);
    }
}
