// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class I18nLanguageHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), II18nLanguageHandler
{
    public Task<YouTubeResult<I18nLanguageListResponse>> HandleI18nLanguageListAsync(I18nLanguageProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Part?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("The part parameter must be provided in the properties.");
        }

        return ExecuteAsync<I18nLanguageListResponse>(
            HttpMethod.Get,
            I18nLanguageDefaults.ListEndpoint,
            properties,
            cancellationToken
        );
    }
}
