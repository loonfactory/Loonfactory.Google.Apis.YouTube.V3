// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public class YouTubeComments(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IYouTubeComments
{
    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public virtual Task<YouTubeCommentListResource> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(id);

        return ListAsync(
            part,
            new KeyValuePair<string, object>(nameof(id), id),
            maxResults,
            pageToken,
            textFormat,
            cancellationToken
        );
    }

    public virtual Task<YouTubeCommentListResource> ListByParentIdAsync(
        StringValues part,
        string parentId,
        uint? maxResults = null,
        string? pageToken = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        return ListAsync(
            part,
            new(nameof(parentId), parentId),
            maxResults,
            pageToken,
            textFormat,
            cancellationToken
        );
    }

    private async Task<YouTubeCommentListResource> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        uint? maxResults = null,
        string? pageToken = null,
        string? textFormat = null,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubeCommentHandler>()
                                     .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCommentHandler could not be obtained.");

        var properties = new YouTubeCommentProperties
        {
            Part = part,
            MaxResults = maxResults,
            PageToken = pageToken,
            TextFormat = textFormat,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandleCommentListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<YouTubeCommentResource> InsertAsync(
        StringValues part,
        YouTubeCommentResource resource,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalInsertAsync(
            part,
            resource,
            cancellationToken
        );

        async Task<YouTubeCommentResource> InternalInsertAsync(
            StringValues part,
            YouTubeCommentResource resource,
            CancellationToken cancellationToken = default)
        {
            var handler = await Handlers.GetHandlerAsync<YouTubeCommentHandler>()
                             .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCommentHandler could not be obtained.");

            var properties = new YouTubeCommentProperties
            {
                Part = part,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandleCommentInsertAsync(
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

    public Task<YouTubeCommentResource> UpdateAsync(
        StringValues part,
        YouTubeCommentResource resource,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalUpdateAsync(part, resource, cancellationToken);

        async Task<YouTubeCommentResource> InternalUpdateAsync(
            StringValues part,
            YouTubeCommentResource resource,
            CancellationToken cancellationToken = default)
        {
            var handler = await Handlers.GetHandlerAsync<YouTubeCommentHandler>()
                             .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCommentHandler could not be obtained.");

            var properties = new YouTubeCommentProperties
            {
                Part = part,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandleCommentUpdateAsync(resource, properties, cancellationToken).ConfigureAwait(false);
            return result.Succeeded switch
            {
                true => result.Resource,
                false => throw new NotImplementedException("@TODO")
            };
        }
    }

    public async Task DeleteAsync(StringValues id, CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubeCommentHandler>()
                         .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCommentHandler could not be obtained.");

        var properties = new YouTubeCommentProperties
        {
            Id = id,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleCommentDeleteAsync(properties, cancellationToken).ConfigureAwait(false);
        if (result.Succeeded)
        {
            return;
        }

        throw new NotImplementedException("@TODO");
    }

    public async Task SetModerationStatusAsync(StringValues id, YouTubeCommentModerationStatus moderationStatus, bool? banAuthor = null, CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<YouTubeCommentHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCommentHandler could not be obtained.");

        var properties = new YouTubeCommentProperties
        {
            Id = id,
            ModerationStatus = moderationStatus,
            BanAuthor = banAuthor,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleCommentDeleteAsync(properties, cancellationToken).ConfigureAwait(false);
        if (result.Succeeded)
        {
            return;
        }

        throw new NotImplementedException("@TODO");
    }
}