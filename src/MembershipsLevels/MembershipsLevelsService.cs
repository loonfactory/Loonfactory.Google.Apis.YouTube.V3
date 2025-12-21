// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public class MembershipsLevelsService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : IMembershipsLevelsService
{
    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public async Task<MembershipsLevelListResponse> GetListAsync(
        StringValues part,
        CancellationToken cancellationToken = default)
    {
        var getAccessTokenTask = AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);        

        var handler = await Handlers.GetHandlerAsync<MembershipsLevelHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeMembershipsLevelHandler could not be obtained.");

        var result = await handler.HandleMembershipsLevelListAsync(new MembershipsLevelProperties
        {
            Parts = part,
            AccessToken = await getAccessTokenTask
        }, cancellationToken).ConfigureAwait(false);

        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }
}