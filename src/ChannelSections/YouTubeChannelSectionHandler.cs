// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

/// <summary>
/// Provides functionality to handle YouTube ChannelSection operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of <see cref="YouTubeChannelSectionHandler" />.
/// </remarks>
/// <param name="options">The monitor for the options instance.</param>
/// <param name="logger">The <see cref="ILoggerFactory"/>.</param>
/// <param name="encoder">The <see cref="UrlEncoder"/>.</param>
public class YouTubeChannelSectionHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : YouTubeHandler(options, logger, encoder), IYouTubeChannelSectionHandler
{
    /// <summary>
    /// Asynchronously handles the deletion of a YouTube ChannelSection.
    /// </summary>
    /// <param name="properties">The <see cref="YouTubeChannelSectionProperties"/> required for ChannelSection deletion.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="properties"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when required properties are missing or invalid.</exception>
    public virtual async Task<YouTubeResult> HandleChannelSectionDeleteAsync(YouTubeChannelSectionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The ChannelSection id must be provided in the properties.");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Delete,
            YouTubeChannelSectionDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult.NoResult,
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }

    public virtual async Task<YouTubeResult<YouTubeChannelSectionListResource>> HandleChannelSectionListAsync(YouTubeChannelSectionProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var response = await SendAsync(
            HttpMethod.Get,
            YouTubeChannelSectionDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<YouTubeChannelSectionListResource>.Success(
            (await response.Content.ReadFromJsonAsync<YouTubeChannelSectionListResource>(YouTubeDefaults.JsonSerializerOptions, cancellationToken).ConfigureAwait(false))!
        );
    }

    public virtual Task<YouTubeResult<YouTubeChannelSectionResource>> HandleChannelSectionInsertAsync(
        YouTubeChannelSectionResource resource,
        YouTubeChannelSectionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(YouTubeChannelSectionDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandleChannelSectionUploadAsync(request, resource, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<YouTubeChannelSectionResource>> HandleChannelSectionUpdateAsync(
        YouTubeChannelSectionResource resource,
        YouTubeChannelSectionProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("@TODO");
        }

        var endpoint = BuildChallengeUrl(YouTubeChannelSectionDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return InternalHandleChannelSectionUploadAsync(request, resource, properties, cancellationToken);
    }

    private async Task<YouTubeResult<YouTubeChannelSectionResource>> InternalHandleChannelSectionUploadAsync(
        HttpRequestMessage request,
        YouTubeChannelSectionResource resource,
        YouTubeChannelSectionProperties properties,
        CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);
        request.Content = JsonContent.Create(resource);

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<YouTubeChannelSectionResource>.Success(
                JsonSerializer.Deserialize<YouTubeChannelSectionResource>(body, YouTubeDefaults.JsonSerializerOptions)!
            ),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }
}