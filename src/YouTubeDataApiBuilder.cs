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
using Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;
using Loonfactory.Google.Apis.YouTube.V3.Playlists;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Initializes a new instance of <see cref="YouTubeDataApiBuilder"/>.
/// </summary>
/// <param name="services">The services being configured.</param>
public class YouTubeDataApiBuilder(IServiceCollection services)
{
    /// <summary>
    /// The services being configured.
    /// </summary>
    public virtual IServiceCollection Services { get; } = services;

    public virtual YouTubeDataApiBuilder AddAccessTokenProvider<T>() where T : class, IAccessTokenProvider
    {
        Services.TryAddScoped<IAccessTokenProvider, T>();
        return this;
    }

    public virtual YouTubeDataApiBuilder AddCaptions<TYouTubeCaptions, THandler>()
        where TYouTubeCaptions : class, ICaptionsService
        where THandler : class, ICaptionHandler
    {
        Services.TryAddScoped<ICaptionsService, TYouTubeCaptions>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddChannelBanners<TYouTubeChannelBanners, THandler>()
        where TYouTubeChannelBanners : class, IChannelBanners
        where THandler : class, IChannelBannerHandler
    {
        Services.TryAddScoped<IChannelBanners, TYouTubeChannelBanners>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddChannels<TYouTubeChannels, THandler>()
       where TYouTubeChannels : class, IChannelsService
       where THandler : class, IChannelHandler
    {
        Services.TryAddScoped<IChannelsService, TYouTubeChannels>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddI18nLanguges<TYouTubeI18nLanguages, THandler>()
        where TYouTubeI18nLanguages : class, II18nLanguagesService
        where THandler : class, II18nLanguageHandler
    {
        Services.TryAddScoped<II18nLanguagesService, TYouTubeI18nLanguages>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddI18nRegions<TYouTubeI18nRegions, THandler>()
        where TYouTubeI18nRegions : class, II18nRegionsService
        where THandler : class, II18nRegionHandler
    {
        Services.TryAddScoped<II18nRegionsService, TYouTubeI18nRegions>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddChannelSections<TYouTubeChannelSections, THandler>()
        where TYouTubeChannelSections : class, IChannelSections
        where THandler : class, IChannelSectionHandler
    {
        Services.TryAddScoped<IChannelSections, TYouTubeChannelSections>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddComments<TYouTubeComments, THandler>()
        where TYouTubeComments : class, ICommentsService
        where THandler : class, ICommentHandler
    {
        Services.TryAddScoped<ICommentsService, TYouTubeComments>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddCommentThreads<TYouTubeCommentThreads, THandler>()
        where TYouTubeCommentThreads : class, ICommentThreadsService
        where THandler : class, ICommentThreadHandler
    {
        Services.TryAddScoped<ICommentThreadsService, TYouTubeCommentThreads>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddMembers<TYouTubeMembers, THandler>()
        where TYouTubeMembers : class, IMembersService
        where THandler : class, IMemberHandler
    {
        Services.TryAddScoped<IMembersService, TYouTubeMembers>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddMembershipsLevels<TYouTubeMembershipsLevels, THandler>()
        where TYouTubeMembershipsLevels : class, IMembershipsLevelsService
        where THandler : class, IMembershipsLevelHandler
    {
        Services.TryAddScoped<IMembershipsLevelsService, TYouTubeMembershipsLevels>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddPlaylistItems<TYouTubePlaylistItems, THandler>()
        where TYouTubePlaylistItems : class, IPlaylistItemsService
        where THandler : class, IPlaylistItemHandler
    {
        Services.TryAddScoped<IPlaylistItemsService, TYouTubePlaylistItems>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddPlaylists<TYouTubePlaylists, THandler>()
        where TYouTubePlaylists : class, IPlaylistsService
        where THandler : class, IPlaylistHandler
    {
        Services.TryAddScoped<IPlaylistsService, TYouTubePlaylists>();
        AddHandler<THandler>();

        return this;
    }

    protected void AddHandler<THandler>() where THandler : class, IYouTubeHandler
    {
        Services.AddTransient<THandler>();

        Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<YouTubeOptions>, YouTubePostConfigureOptions<YouTubeOptions, THandler>>());

    }
}