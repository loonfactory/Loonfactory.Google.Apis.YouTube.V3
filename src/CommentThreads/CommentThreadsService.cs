// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

public class CommentThreadsService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : ICommentThreadsService
{
    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public Task<CommentListResponse> GetByAllThreadsRelatedToChannelIdAsync(
        StringValues part,
        string allThreadsRelatedToChannelId,
        uint? maxResults = null,
        CommentThreadModerationStatus? moderationStatus = null,
        CommentThreadOrder? order = null,
        string? pageToken = null,
        string? searchTerms = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(part);
        ArgumentException.ThrowIfNullOrWhiteSpace(allThreadsRelatedToChannelId);

        return GetAsync(
            part,
            new KeyValuePair<string, object>(
                nameof(allThreadsRelatedToChannelId), allThreadsRelatedToChannelId
            ),
            maxResults,
            moderationStatus,
            order,
            pageToken,
            searchTerms,
            textFormat,
            cancellationToken
        );
    }

    public Task<CommentListResponse> GetByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? searchTerms = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(part);
        ArgumentException.ThrowIfNullOrWhiteSpace(id);

        return GetAsync(
            part,
            new KeyValuePair<string, object>(
                nameof(id), id
            ),
            maxResults,
            moderationStatus: null,
            order: null,
            pageToken,
            searchTerms,
            textFormat,
            cancellationToken
        );
    }

    public Task<CommentListResponse> GetByVideoIdAsync(
        StringValues part,
        string videoId,
        uint? maxResults = null,
        CommentThreadModerationStatus? moderationStatus = null,
        CommentThreadOrder? order = null,
        string? pageToken = null,
        string? searchTerms = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(part);
        ArgumentException.ThrowIfNullOrWhiteSpace(videoId);

        return GetAsync(
            part,
            new KeyValuePair<string, object>(
                nameof(videoId), videoId
            ),
            maxResults,
            moderationStatus,
            order,
            pageToken,
            searchTerms,
            textFormat,
            cancellationToken
        );
    }

    private async Task<CommentListResponse> GetAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        uint? maxResults = null,
        CommentThreadModerationStatus? moderationStatus = null,
        CommentThreadOrder? order = null,
        string? pageToken = null,
        string? searchTerms = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<CommentThreadHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCommentHandler could not be obtained.");

        var properties = new CommentThreadProperties
        {
            Part = part,
            MaxResults = maxResults,
            ModerationStatus = moderationStatus,
            Order = order,
            PageToken = pageToken,
            SearchTerms = searchTerms,
            TextFormat = textFormat,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandleCommentThreadListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<CommentThreadResource> InsertAsync(
        StringValues part,
        CommentThreadResource resource,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalInsertAsync(
            part,
            resource,
            cancellationToken
        );

        async Task<CommentThreadResource> InternalInsertAsync(
            StringValues part,
            CommentThreadResource resource,
            CancellationToken cancellationToken = default)
        {
            var handler = await Handlers.GetHandlerAsync<CommentThreadHandler>()
                             .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCommentHandler could not be obtained.");

            var accessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
                ?? throw new InvalidOperationException("An access token must be provided in the properties.");

            var properties = new CommentThreadProperties
            {
                Part = part,
                AccessToken = accessToken,
            };

            var result = await handler.HandleCommentThreadInsertAsync(
                resource,
                properties,
                cancellationToken
            ).ConfigureAwait(false);

            return result.Succeeded switch
            {
                true => result.Resource,
                false => throw new NotImplementedException("@TODO")
            };
        }
    }
}