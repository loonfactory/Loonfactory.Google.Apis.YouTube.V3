// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class YouTubeI18nLanguages(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider) : IYouTubeI18nLanguages
{

    /// <summary>
    /// Used to resolve <see cref="IYouTubeHandler"/> instances.
    /// </summary>
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public async Task<YouTubeI18nLanguageListResource> ListAsync(StringValues part, string? hl = "en_US", CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(part);

        var handler = await Handlers.GetHandlerAsync<YouTubeI18nLanguageHandler>()
            .ConfigureAwait(false) ?? throw new InvalidOperationException("YouTubeCaptionHandler could not be obtained.");

        var result = await handler.HandleI18nLanguageListAsync(new YouTubeI18nLanguageProperties
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