// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideosService(
    IYouTubeHandlerProvider handlers,
    IAccessTokenProvider accessTokenProvider
) : IVideosService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

    public Task<VideoListResponse> ListByIdAsync(
        StringValues part,
        StringValues id,
        uint? maxResults = null,
        string? pageToken = null,
        string? hl = null,
        string? regionCode = null,
        string? videoCategoryId = null,
        uint? maxHeight = null,
        uint? maxWidth = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        if (StringValues.IsNullOrEmpty(id))
        {
            throw new ArgumentException("id must be provided.", nameof(id));
        }

        return ListAsync(
            part,
            new(nameof(id), id),
            maxResults,
            pageToken,
            hl,
            regionCode,
            videoCategoryId,
            maxHeight,
            maxWidth,
            onBehalfOfContentOwner,
            cancellationToken);
    }

    public Task<VideoListResponse> ListByChartAsync(
        StringValues part,
        string chart,
        uint? maxResults = null,
        string? pageToken = null,
        string? hl = null,
        string? regionCode = null,
        string? videoCategoryId = null,
        uint? maxHeight = null,
        uint? maxWidth = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(chart);

        return ListAsync(
            part,
            new(nameof(chart), chart),
            maxResults,
            pageToken,
            hl,
            regionCode,
            videoCategoryId,
            maxHeight,
            maxWidth,
            onBehalfOfContentOwner,
            cancellationToken);
    }

    public Task<VideoListResponse> ListByMyRatingAsync(
        StringValues part,
        string myRating,
        uint? maxResults = null,
        string? pageToken = null,
        string? hl = null,
        uint? maxHeight = null,
        uint? maxWidth = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(myRating);

        return ListAsync(
            part,
            new(nameof(myRating), myRating),
            maxResults,
            pageToken,
            hl,
            regionCode: null,
            videoCategoryId: null,
            maxHeight,
            maxWidth,
            onBehalfOfContentOwner,
            cancellationToken);
    }

    private async Task<VideoListResponse> ListAsync(
        StringValues part,
        KeyValuePair<string, object> filter,
        uint? maxResults,
        string? pageToken,
        string? hl,
        string? regionCode,
        string? videoCategoryId,
        uint? maxHeight,
        uint? maxWidth,
        string? onBehalfOfContentOwner,
        CancellationToken cancellationToken)
    {
        var handler = await Handlers.GetHandlerAsync<VideoHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("VideoHandler could not be obtained.");

        var properties = new VideoProperties
        {
            Part = part,
            MaxResults = maxResults,
            PageToken = pageToken,
            Hl = hl,
            RegionCode = regionCode,
            VideoCategoryId = videoCategoryId,
            MaxHeight = maxHeight,
            MaxWidth = maxWidth,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        properties.Parameters.Add(filter.Key, filter.Value);

        var result = await handler.HandleVideoListAsync(properties, cancellationToken)
                                  .ConfigureAwait(false);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Video list request failed. [TODO: unify error handling]");
        }

        return result.Resource;
    }

    public Task<VideoResource> InsertAsync(
        StringValues part,
        VideoResource resource,
        StreamContent? content = null,
        bool? autoLevels = null,
        bool? notifySubscribers = null,
        string? onBehalfOfContentOwner = null,
        string? onBehalfOfContentOwnerChannel = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        ArgumentNullException.ThrowIfNull(resource);

        if (resource.Snippet == null)
        {
            throw new InvalidOperationException("Snippet must be set.");
        }

        if (string.IsNullOrWhiteSpace(resource.Snippet.Title))
        {
            throw new InvalidOperationException("Snippet.Title must be set.");
        }

        if (string.IsNullOrWhiteSpace(resource.Snippet.CategoryId))
        {
            throw new InvalidOperationException("Snippet.CategoryId must be set.");
        }

        return InternalInsertAsync(
            part,
            resource,
            content,
            autoLevels,
            notifySubscribers,
            onBehalfOfContentOwner,
            onBehalfOfContentOwnerChannel,
            cancellationToken
        );
    }

    private async Task<VideoResource> InternalInsertAsync(
        StringValues part,
        VideoResource resource,
        StreamContent? content,
        bool? autoLevels,
        bool? notifySubscribers,
        string? onBehalfOfContentOwner,
        string? onBehalfOfContentOwnerChannel,
        CancellationToken cancellationToken)
    {
        var handler = await Handlers.GetHandlerAsync<VideoHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("VideoHandler could not be obtained.");

        var properties = new VideoProperties
        {
            Part = part,
            AutoLevels = autoLevels,
            NotifySubscribers = notifySubscribers,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            OnBehalfOfContentOwnerChannel = onBehalfOfContentOwnerChannel,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleVideoInsertAsync(resource, content, properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public Task<VideoResource> UpdateAsync(
        StringValues part,
        VideoResource resource,
        StreamContent? content = null,
        bool? notifySubscribers = null,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        ArgumentNullException.ThrowIfNull(resource);

        if (string.IsNullOrWhiteSpace(resource.Id))
        {
            throw new InvalidOperationException("Resource.Id must be set for update.");
        }

        return InternalUpdateAsync(
            part,
            resource,
            content,
            notifySubscribers,
            onBehalfOfContentOwner,
            cancellationToken);
    }

    private async Task<VideoResource> InternalUpdateAsync(
        StringValues part,
        VideoResource resource,
        StreamContent? content,
        bool? notifySubscribers,
        string? onBehalfOfContentOwner,
        CancellationToken cancellationToken)
    {
        var handler = await Handlers.GetHandlerAsync<VideoHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("VideoHandler could not be obtained.");

        var properties = new VideoProperties
        {
            Part = part,
            NotifySubscribers = notifySubscribers,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleVideoUpdateAsync(resource, content, properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public async Task DeleteAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(id))
        {
            throw new ArgumentException("id must be provided.", nameof(id));
        }

        var handler = await Handlers.GetHandlerAsync<VideoHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("VideoHandler could not be obtained.");

        var properties = new VideoProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleVideoDeleteAsync(properties, cancellationToken).ConfigureAwait(false);
        if (result.Succeeded)
        {
            return;
        }

        throw new NotImplementedException("@TODO");
    }

    public async Task RateAsync(
        StringValues id,
        string rating,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(id))
        {
            throw new ArgumentException("id must be provided.", nameof(id));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(rating);

        var handler = await Handlers.GetHandlerAsync<VideoHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("VideoHandler could not be obtained.");

        var properties = new VideoProperties
        {
            Id = id,
            Rating = rating,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleVideoRateAsync(properties, cancellationToken).ConfigureAwait(false);
        if (result.Succeeded)
        {
            return;
        }

        throw new NotImplementedException("@TODO");
    }

    public async Task<VideoGetRatingResponse> GetRatingAsync(
        StringValues id,
        string? onBehalfOfContentOwner = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(id))
        {
            throw new ArgumentException("id must be provided.", nameof(id));
        }

        var handler = await Handlers.GetHandlerAsync<VideoHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("VideoHandler could not be obtained.");

        var properties = new VideoProperties
        {
            Id = id,
            OnBehalfOfContentOwner = onBehalfOfContentOwner,
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleVideoGetRatingAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }

    public async Task ReportAbuseAsync(
        VideoReportAbuseRequest resource,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(resource);

        var handler = await Handlers.GetHandlerAsync<VideoHandler>()
                                    .ConfigureAwait(false) ?? throw new InvalidOperationException("VideoHandler could not be obtained.");

        var properties = new VideoProperties
        {
            AccessToken = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false)
        };

        var result = await handler.HandleVideoReportAbuseAsync(resource, properties, cancellationToken).ConfigureAwait(false);
        if (result.Succeeded)
        {
            return;
        }

        throw new NotImplementedException("@TODO");
    }
}
