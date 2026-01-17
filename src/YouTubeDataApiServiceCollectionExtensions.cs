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
using Loonfactory.Google.Apis.YouTube.V3.Playlists;
using Loonfactory.Google.Apis.YouTube.V3.Search;
using Loonfactory.Google.Apis.YouTube.V3.Subscriptions;
using Loonfactory.Google.Apis.YouTube.V3.Thumbnails;
using Loonfactory.Google.Apis.YouTube.V3.VideoAbuseReportReasons;
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

        builder.AddCaptions<ICaptionsService, CaptionHandler>();
        builder.AddChannelBanners<IChannelBanners, ChannelBannerHandler>();
        builder.AddChannels<IChannelsService, ChannelHandler>();
        builder.AddChannelSections<IChannelSections, ChannelSectionHandler>();
        builder.AddComments<ICommentsService, CommentHandler>();
        builder.AddCommentThreads<ICommentThreadsService, CommentThreadHandler>();
        builder.AddI18nLanguges<I18nLanguagesService, I18nLanguageHandler>();
        builder.AddI18nRegions<I18nRegionsService, I18nRegionHandler>();
        builder.AddMembers<IMembersService, MemberHandler>();
        builder.AddMembershipsLevels<IMembershipsLevelsService, MembershipsLevelHandler>();
        builder.AddPlaylists<IPlaylistsService, PlaylistHandler>();
        builder.AddSearch<SearchService, SearchHandler>();
        builder.AddSubscriptions<ISubscriptionService, SubscriptionHandler>();
        builder.AddThumbnails<ThumbnailService, ThumbnailHandler>();
        builder.AddVideoAbuseReportReasons<VideoAbuseReportReasonsService, VideoAbuseReportReasonHandler>();

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