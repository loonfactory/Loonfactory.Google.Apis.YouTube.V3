// Licensed under the MIT license by loonfactory.

using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideoHandler(
    IOptionsMonitor<YouTubeOptions> options,
    ILoggerFactory logger
) : YouTubeHandler(options, logger), IVideoHandler
{
    public virtual async Task<YouTubeResult<VideoListResponse>> HandleVideoListAsync(
        VideoProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (StringValues.IsNullOrEmpty(properties.Part))
        {
            throw new InvalidOperationException("The part parameter must be provided in the properties.");
        }

        var filterCount = 0;
        if (!StringValues.IsNullOrEmpty(properties.Id))
        {
            filterCount++;
        }

        if (!string.IsNullOrWhiteSpace(properties.Chart))
        {
            filterCount++;
        }

        if (!string.IsNullOrWhiteSpace(properties.MyRating))
        {
            filterCount++;
        }

        if (filterCount != 1)
        {
            throw new InvalidOperationException("Filters (specify exactly one of the following parameters): id, chart, myRating.");
        }

        using var response = await SendAsync(
            HttpMethod.Get,
            VideoDefaults.ListEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<VideoListResponse>.Success(
            (await response.Content.ReadFromJsonAsync<VideoListResponse>(
                YouTubeDefaults.JsonSerializerOptions,
                cancellationToken
            ).ConfigureAwait(false))!
        );
    }

    public virtual Task<YouTubeResult<VideoResource>> HandleVideoInsertAsync(
        VideoResource resource,
        StreamContent? content,
        VideoProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (StringValues.IsNullOrEmpty(properties.Part))
        {
            throw new InvalidOperationException("The part parameter must be provided in the properties.");
        }

        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);

        var endpoint = BuildChallengeUrl(VideoDefaults.InsertEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        return UploadAsync(request, resource, content, properties, cancellationToken);
    }

    public virtual Task<YouTubeResult<VideoResource>> HandleVideoUpdateAsync(
        VideoResource resource,
        StreamContent? content,
        VideoProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);
        ArgumentNullException.ThrowIfNull(cancellationToken);

        if (StringValues.IsNullOrEmpty(properties.Part))
        {
            throw new InvalidOperationException("The part parameter must be provided in the properties.");
        }

        if (string.IsNullOrEmpty(resource.Id))
        {
            throw new InvalidOperationException("The video id must be set on the resource.");
        }

        ThrowIfAccessTokenNullOrEmpty(properties.AccessToken);

        var endpoint = BuildChallengeUrl(VideoDefaults.UpdateEndpoint, properties);
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint);
        return UploadAsync(request, resource, content, properties, cancellationToken);
    }

    public virtual async Task<YouTubeResult> HandleVideoDeleteAsync(
        VideoProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (StringValues.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The video id must be provided in the properties.");
        }

        using var response = await AuthorizationSendAsync(
            HttpMethod.Delete,
            VideoDefaults.DeleteEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult.NoResult,
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }

    public virtual async Task<YouTubeResult> HandleVideoRateAsync(
        VideoProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (StringValues.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The video id must be provided in the properties.");
        }

        if (string.IsNullOrWhiteSpace(properties.Rating))
        {
            throw new InvalidOperationException("The rating parameter must be provided in the properties.");
        }

        using var response = await AuthorizationSendAsync(
            HttpMethod.Post,
            VideoDefaults.RateEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        return response.IsSuccessStatusCode switch
        {
            true => YouTubeResult.NoResult,
            false => throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.")
        };
    }

    public virtual async Task<YouTubeResult<VideoGetRatingResponse>> HandleVideoGetRatingAsync(
        VideoProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if (StringValues.IsNullOrEmpty(properties.Id))
        {
            throw new InvalidOperationException("The video id must be provided in the properties.");
        }

        using var response = await AuthorizationSendAsync(
            HttpMethod.Get,
            VideoDefaults.GetRatingEndpoint,
            properties,
            cancellationToken
        ).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        return YouTubeResult<VideoGetRatingResponse>.Success(
            (await response.Content.ReadFromJsonAsync<VideoGetRatingResponse>(
                YouTubeDefaults.JsonSerializerOptions,
                cancellationToken
            ).ConfigureAwait(false))!
        );
    }

    public virtual async Task<YouTubeResult> HandleVideoReportAbuseAsync(
        VideoReportAbuseRequest resource,
        VideoProperties properties,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(properties);

        if (string.IsNullOrWhiteSpace(resource.VideoId))
        {
            throw new InvalidOperationException("The resource.VideoId must be provided.");
        }

        if (string.IsNullOrWhiteSpace(resource.ReasonId))
        {
            throw new InvalidOperationException("The resource.ReasonId must be provided.");
        }

        var endpoint = BuildChallengeUrl(VideoDefaults.ReportAbuseEndpoint, properties);
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = JsonContent.Create(resource)
        };

        using var response = await AuthorizationSendAsync(
            request,
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
