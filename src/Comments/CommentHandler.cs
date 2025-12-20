// Licensed under the MIT license by loonfactory.

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public class CommentHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : YouTubeHandler(options, logger, encoder), ICommentHandler
{
    public virtual async Task<YouTubeResult> HandleCommentDeleteAsync(CommentProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The Comment id must be provided in the properties.");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Delete,
            CommentDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult.NoResult,
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }

    public virtual async Task<YouTubeResult<CommentListResponse>> HandleCommentListAsync(CommentProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        var response = await SendAsync(
            HttpMethod.Get,
            CommentDefaults.ListEndpoint,
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

    public virtual Task<YouTubeResult<CommentResource>> HandleCommentInsertAsync(
        CommentResource resource,
        CommentProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        var endpoint = BuildChallengeUrl(CommentDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return InternalHandleCommentUploadAsync(request, resource, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<CommentResource>> HandleCommentUpdateAsync(
        CommentResource resource,
        CommentProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("@TODO");
        }

        var endpoint = BuildChallengeUrl(CommentDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return InternalHandleCommentUploadAsync(request, resource, properties, cancellationToken);
    }

    private async Task<YouTubeResult<CommentResource>> InternalHandleCommentUploadAsync(
        HttpRequestMessage request,
        CommentResource resource,
        CommentProperties properties,
        CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", properties.AccessToken);
        request.Content = JsonContent.Create(resource);

        var response = await Backchannel.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult<CommentResource>.Success(
                JsonSerializer.Deserialize<CommentResource>(body, YouTubeDefaults.JsonSerializerOptions)!
            ),
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }

    public Task<YouTubeResult> HandleSetModerationStatus(CommentProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        return InternalHandleSetModerationStatusAsync(properties, cancellationToken);

        async Task<YouTubeResult> InternalHandleSetModerationStatusAsync(
            CommentProperties properties,
            CancellationToken cancellationToken)
        {
            var response = await AuthorizationSendAsync(
                HttpMethod.Post,
                CommentDefaults.SetModerationStatusEndpoint,
                properties,
                cancellationToken
            ).ConfigureAwait(false);

            return response.IsSuccessStatusCode switch
            {
                true => YouTubeResult.NoResult,
                false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
            };

        }
    }
}