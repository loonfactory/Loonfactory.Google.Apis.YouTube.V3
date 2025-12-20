// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class I18nLanguageHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), II18nLanguageHandler
{
    public async Task<YouTubeResult<I18nLanguageListResponse>> HandleI18nLanguageListAsync(I18nLanguageProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        var response = await SendAsync(
            HttpMethod.Get,
            I18nLanguageDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<I18nLanguageListResponse>.Success((
                await response.Content.ReadFromJsonAsync<I18nLanguageListResponse>(cancellationToken)
                    .ConfigureAwait(false))!),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}