// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

public class YouTubeCommentThreadHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : YouTubeHandler(options, logger, encoder), IYouTubeCommentThreadHandler
{
    public virtual async Task<YouTubeResult<YouTubeCommentListResource>> HandleCommentThreadListAsync(YouTubeCommentThreadProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var response = await SendAsync(
            HttpMethod.Get,
            YouTubecommentThreadDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<YouTubeCommentListResource>.Success(
            (await response.Content.ReadFromJsonAsync<YouTubeCommentListResource>(
                YouTubeDefaults.JsonSerializerOptions, cancellationToken
            ).ConfigureAwait(false))!
        );
    }

    public virtual Task<YouTubeResult<YouTubeCommentThreadResource>> HandleCommentThreadInsertAsync(
        YouTubeCommentThreadResource resource,
        YouTubeCommentThreadProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (string.IsNullOrEmpty(properties.AccessToken))
        {
            throw new InvalidOperationException("An access token must be provided in the properties.");
        }

        var endpoint = BuildChallengeUrl(YouTubecommentThreadDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandleCommentUploadAsync(request, resource, properties, cancellationToken);

        async Task<YouTubeResult<YouTubeCommentThreadResource>> InternalHandleCommentUploadAsync(
            HttpRequestMessage request,
            YouTubeCommentThreadResource resource,
            YouTubeCommentThreadProperties properties,
            CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);
            request.Content = JsonContent.Create(resource);

            var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            return response.IsSuccessStatusCode switch
            {
                true => YouTubeResult<YouTubeCommentThreadResource>.Success(
                    JsonSerializer.Deserialize<YouTubeCommentThreadResource>(body, YouTubeDefaults.JsonSerializerOptions)!
                ),
                false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
            };
        }
    }
}