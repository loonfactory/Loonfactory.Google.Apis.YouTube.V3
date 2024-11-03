// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Provides functionality to handle YouTube caption operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of <see cref="YouTubeCaptionHandler" />.
/// </remarks>
/// <param name="options">The monitor for the options instance.</param>
/// <param name="logger">The <see cref="ILoggerFactory"/>.</param>
/// <param name="encoder">The <see cref="UrlEncoder"/>.</param>
public class YouTubeCaptionHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : YouTubeHandler(options, logger, encoder), IYouTubeCaptionHandler
{
    /// <summary>
    /// Asynchronously handles the deletion of a YouTube caption.
    /// </summary>
    /// <param name="properties">The <see cref="YouTubeCaptionProperties"/> required for caption deletion.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="properties"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when required properties are missing or invalid.</exception>
    public virtual async Task HandleCaptionDeleteAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The caption id must be provided in the properties.");
        }

        if (string.IsNullOrEmpty(properties.AccessToken))
        {
            throw new InvalidOperationException("An access token must be provided in the properties.");
        }

        var endpoint = BuildChallengeUrl(YouTubeCaptionDefaults.DeleteEndpoint, properties);

        var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        throw new NotSupportedException("Handling of unsuccessful HTTP responses is not yet implemented.");
    }

    public virtual async Task HandleCaptionListAsync(YouTubeCaptionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.VideoId))
        {
            throw new InvalidOperationException("@TODO");
        }

        if ((properties.Parts?.Length ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        var endpoint = BuildChallengeUrl(YouTubeCaptionDefaults.ListEndpoint, properties);

        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        throw new NotSupportedException("Handling of unsuccessful HTTP responses is not yet implemented.");
    }

    /// <summary>
    /// Constructs the challenge url.
    /// </summary>
    /// <param name="uri">The base URI of the challenge.</param>
    /// <param name="properties">The <see cref="YouTubeCaptionProperties"/>.</param>
    /// <returns>The challenge url.</returns>
    protected virtual string BuildChallengeUrl(string uri, YouTubeCaptionProperties properties)
    {
        var parameters = new List<KeyValuePair<string, StringValues>>
        {
            new("id", properties.Id ),
            new("part", properties.Parts),
            new("onBehalfOfContentOwner", properties.OnBehalfOfContentOwner),
            new("key", Options.Key),
        };

        return QueryHelpers.AddQueryString(uri, parameters.AsEnumerable());
    }
}