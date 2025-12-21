// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class I18nLanguagesService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : II18nLanguagesService
{

    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public async Task<I18nLanguageListResponse> ListAsync(StringValues part, string? hl = "en_US", CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        var handler = await Handlers.GetHandlerAsync<I18nLanguageHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var result = await handler.HandleI18nLanguageListAsync(new I18nLanguageProperties
        {
            Parts = part,
            Hl = hl,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        }, cancellationToken).ConfigureAwait(false);

        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }
}