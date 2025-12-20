// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public interface II18nLanguageHandler : IYouTubeHandler
{
    public Task<YouTubeResult<I18nLanguageListResponse>> HandleI18nLanguageListAsync(I18nLanguageProperties properties, CancellationToken cancellationToken);
}
