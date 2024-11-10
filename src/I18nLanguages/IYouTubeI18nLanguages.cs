// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public interface IYouTubeI18nLanguages
{
    public Task<YouTubeI18nLanguageListResource> ListAsync(
        StringValues part,
        string? hl = "en_US",
        CancellationToken cancellationToken = default
    );
}
