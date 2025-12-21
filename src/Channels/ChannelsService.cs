// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Channels;

public class ChannelsService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IChannelsService
{
    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public virtual Task<CaptionListResponse> ListByForHandleAsync(
        StringValues part,
        string forHandle,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(forHandle);

        return ListAsync(
           part,
           new KeyValuePair<string, object>(nameof(forHandle), forHandle),
           hl,
           maxResults,
           onBehalfOfContentOwner,
           pageToken,
           cancellationToken
       );
    }

    public virtual Task<CaptionListResponse> ListByForUsernameAsync(
        StringValues part,
        string forUsername,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(forUsername);

        return ListAsync(
           part,
           new KeyValuePair<string, object>(nameof(forUsername), forUsername),
           hl,
           maxResults,
           onBehalfOfContentOwner,
           pageToken,
           cancellationToken
       );
    }

    public virtual Task<CaptionListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(id);

        return ListAsync(
            part,
            new KeyValuePair<string, object>(nameof(id), id),
            hl,
            maxResults,
            onBehalfOfContentOwner,
            pageToken,
            cancellationToken
        );
    }

    public virtual Task<CaptionListResponse> ListByMineAsync(
        StringValues part,
        bool mine,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        return ListAsync(part, new(nameof(mine), mine), hl, maxResults, onBehalfOfContentOwner, pageToken, cancellationToken);
    }

    private async Task<CaptionListResponse> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        string? hl = null,
        int? maxResults = null,
        string? onBehalfOfContentOwner = null,
        string? pageToken = null,
        CancellationToken cancellationToken = default)
    {
        var handler = await Handlers.GetHandlerAsync<ChannelHandler>()
                                .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var properties = new ChannelProperties
        {
            Part = part,
            Hl = hl,
            MaxResults = maxResults,
            PageToken = pageToken,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };
        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandleChannelListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<ChannelResource> UpdateAsync(
        StringValues part,
        ChannelResource resource,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);
        ArgumentNullException.ThrowIfNull(resource);

        return InternalUpdateAsync(part, resource, onBehalfOfContentOwner, cancellationToken);

        async Task<ChannelResource> InternalUpdateAsync(
            StringValues part,
            ChannelResource resource,
            string? onBehalfOfContentOwner,
            CancellationToken cancellationToken)
        {
            var handler = await Handlers.GetHandlerAsync<ChannelHandler>()
                                          .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

            var properties = new ChannelProperties
            {
                Part = part,
                OnBehalfOfContentOwner = onBehalfOfContentOwner,
                AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
            };

            var result = await handler.HandleChannelUpdateAsync(properties, resource, cancellationToken).ConfigureAwait(false);
            return result.Succeeded switch
            {
                true => result.Resource,
                false => throw new NotImplementedException("@TODO")
            };
        }
    }
}