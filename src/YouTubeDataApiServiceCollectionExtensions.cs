// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Captions;
using Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;
using Loonfactory.Google.Apis.YouTube.V3.Channels;
using Loonfactory.Google.Apis.YouTube.V3.ChannelSections;
using Loonfactory.Google.Apis.YouTube.V3.Comments;
using Loonfactory.Google.Apis.YouTube.V3.CommentThreads;
using Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;
using Loonfactory.Google.Apis.YouTube.V3.I18nRegions;
using Loonfactory.Google.Apis.YouTube.V3.Members;
using Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;
using Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;
using Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;
using Loonfactory.Google.Apis.YouTube.V3.Playlists;
using Loonfactory.Google.Apis.YouTube.V3.Search;
using Loonfactory.Google.Apis.YouTube.V3.Subscriptions;
using Loonfactory.Google.Apis.YouTube.V3.Thumbnails;
using Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;
using Loonfactory.Google.Apis.YouTube.V3.VideoCategories;
using Loonfactory.Google.Apis.YouTube.V3.Videos;
using Loonfactory.Google.Apis.YouTube.V3.Watermarks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Loonfactory.Google.Apis.YouTube.V3;

public static class YouTubeDataApiServiceCollectionExtensions
{
    /// <summary>
    /// Adds YouTube data api services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static YouTubeDataApiBuilder AddYouTubeDataApiCore(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.TryAddScoped<IYouTubeHandlerProvider, YouTubeHandlerProvider>();
        return new YouTubeDataApiBuilder(services);
    }

    public static YouTubeDataApiBuilder AddYouTubeDataApiCore(this IServiceCollection services, Action<YouTubeOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        var builder = services.AddYouTubeDataApiCore();
        services.Configure(configureOptions);
        return builder;
    }

    public static YouTubeDataApiBuilder AddYouTubeDataApi(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        var builder = services.AddYouTubeDataApiCore();

        services.TryAddSingleton(TimeProvider.System);

        services.AddHttpContextAccessor();
        builder.AddAccessTokenProvider<HttpContextAccessTokenProvider>();

        builder.AddCaptions<CaptionsService, CaptionHandler>();
        builder.AddChannelBanners<ChannelBannersService, ChannelBannerHandler>();
        builder.AddChannels<ChannelsService, ChannelHandler>();
        builder.AddChannelSections<ChannelSectionsService, ChannelSectionHandler>();
        builder.AddComments<CommentsService, CommentHandler>();
        builder.AddCommentThreads<CommentThreadsService, CommentThreadHandler>();
        builder.AddI18nLanguges<I18nLanguagesService, I18nLanguageHandler>();
        builder.AddI18nRegions<I18nRegionsService, I18nRegionHandler>();
        builder.AddMembers<MembersService, MemberHandler>();
        builder.AddMembershipsLevels<MembershipsLevelsService, MembershipsLevelHandler>();
        builder.AddPlaylistImages<PlaylistImagesService, PlaylistImageHandler>();
        builder.AddPlaylistItems<PlaylistItemsService, PlaylistItemHandler>();
        builder.AddPlaylists<PlaylistsService, PlaylistHandler>();
        builder.AddSearch<SearchService, SearchHandler>();
        builder.AddSubscriptions<SubscriptionService, SubscriptionHandler>();
        builder.AddThumbnails<ThumbnailService, ThumbnailHandler>();
        builder.AddVideoAbuseReportReasons<VideoAbuseReportReasonsService, VideoAbuseReportReasonHandler>();
        builder.AddVideoCategories<VideoCategoryService, VideoCategoryHandler>();
        builder.AddVideos<VideosService, VideoHandler>();
        builder.AddWatermarks<WatermarkService, WatermarkHandler>();

        return builder;
    }

    public static YouTubeDataApiBuilder AddYouTubeDataApi(this IServiceCollection services, Action<YouTubeOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        var builder = services.AddYouTubeDataApi();
        services.Configure(configureOptions);

        return builder;
    }

}
