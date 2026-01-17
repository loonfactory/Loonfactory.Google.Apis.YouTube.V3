// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

public class ThumbnailHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), IThumbnailHandler
{
    public virtual async Task<YouTubeResult<ThumbnailSetResponse>> HandleThumbnailSetAsync(
        Stream thumbnail,
        string contentType,
        ThumbnailProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(thumbnail);
        ArgumentNullException.ThrowIfNull(properties);

        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);

        if (string.IsNullOrWhiteSpace(properties.VideoId))
        {
            throw new InvalidOperationException("The videoId must be provided in the properties.");
        }

        if (string.IsNullOrWhiteSpace(contentType))
        {
            throw new ArgumentException("contentType must be provided.", nameof(contentType));
        }

        var endpoint = BuildChallengeUrl(ThumbnailDefaults.SetEndpoint, properties);
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        
        using var content = new StreamContent(thumbnail);
        content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        request.Content = content;

        var response = await AuthorizationSendAsync(request, properties, cancellationToken).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<ThumbnailSetResponse>.Success((
                await response.Content.ReadFromJsonAsync<ThumbnailSetResponse>(
                    YouTubeDefaults.JsonSerializerOptions,
                    cancellationToken
                ).ConfigureAwait(false))!),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}
