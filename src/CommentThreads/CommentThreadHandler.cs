// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

public class CommentThreadHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder
) : YouTubeHandler(options, logger, encoder), ICommentThreadHandler
{
    public virtual async Task<YouTubeResult<CommentListResponse>> HandleCommentThreadListAsync(CommentThreadProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var response = await SendAsync(
            HttpMethod.Get,
            CommentThreadDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<CommentListResponse>.Success(
            (await response.Content.ReadFromJsonAsync<CommentListResponse>(
                YouTubeDefaults.JsonSerializerOptions, cancellationToken
            ).ConfigureAwait(false))!
        );
    }

    public virtual Task<YouTubeResult<CommentThreadResource>> HandleCommentThreadInsertAsync(
        CommentThreadResource resource,
        CommentThreadProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (string.IsNullOrEmpty(properties.AccessToken))
        {
            throw new InvalidOperationException("An access token must be provided in the properties.");
        }

        var endpoint = BuildChallengeUrl(CommentThreadDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandleCommentUploadAsync(request, resource, properties, cancellationToken);

        async Task<YouTubeResult<CommentThreadResource>> InternalHandleCommentUploadAsync(
            HttpRequestMessage request,
            CommentThreadResource resource,
            CommentThreadProperties properties,
            CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);
            request.Content = JsonContent.Create(resource);

            var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            return response.IsSuccessStatusCode switch
            {
                true => YouTubeResult<CommentThreadResource>.Success(
                    JsonSerializer.Deserialize<CommentThreadResource>(body, YouTubeDefaults.JsonSerializerOptions)!
                ),
                false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
            };
        }
    }
}