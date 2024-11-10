// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public interface IYouTubeI18nLanguageHandler : IYouTubeHandler
{
    public Task<YouTubeResult<YouTubeI18nLanguageListResource>> HandleI18nLanguageListAsync(YouTubeI18nLanguageProperties properties, CancellationToken cancellationToken);
}
