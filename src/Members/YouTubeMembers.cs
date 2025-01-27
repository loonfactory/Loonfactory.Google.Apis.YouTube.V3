// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class YouTubeMembers(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IYouTubeMembers
{
    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public async Task<YouTubeMemberListResource> GetListAsync(
        StringValues part,
        string? mode = "all_current",
        ushort? maxResults = 5,
        string? pageToken = null,
        string? hasAccessToLevel = null,
        string? filterByMemberChannelId = null,
        CancellationToken cancellationToken = default)
    {
        var getAccessTokenTask = AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);

        var handler = await Handlers.GetHandlerAsync<YouTubeMemberHandler>()
                           .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeMemberHandler could not be obtained.");

        var result = await handler.HandleMemberListAsync(new YouTubeMemberProperties
        {
            Parts = part,
            Mode = mode,
            MaxResults = maxResults,
            PageToken = pageToken,
            HasAccessToLevel = hasAccessToLevel,
            FilterByMemberChannelId = filterByMemberChannelId,
            AccessToken = await getAccessTokenTask
        }, cancellationToken).ConfigureAwait(false);

        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }
}