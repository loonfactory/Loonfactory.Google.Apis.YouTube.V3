// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Captions;
using Loonfactory.Google.Apis.YouTube.V3.ChannelBanners;
using Loonfactory.Google.Apis.YouTube.V3.Channels;
using Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;
using Loonfactory.Google.Apis.YouTube.V3.I18nRegions;
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

    public virtual YouTubeDataApiBuilder AddYouTubeCaptions<TYouTubeCaptions, THandler>()
        where TYouTubeCaptions : class, IYouTubeCaptions
        where THandler : class, IYouTubeCaptionHandler
    {
        Services.TryAddScoped<IYouTubeCaptions, TYouTubeCaptions>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddYouTubeChannelBanners<TYouTubeChannelBanners, THandler>()
        where TYouTubeChannelBanners : class, IYouTubeChannelBanners
        where THandler : class, IYouTubeChannelBannerHandler
    {
        Services.TryAddScoped<IYouTubeChannelBanners, TYouTubeChannelBanners>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddYouTubeChannels<TYouTubeChannels, THandler>()
       where TYouTubeChannels : class, IYouTubeChannels
       where THandler : class, IYouTubeChannelHandler
    {
        Services.TryAddScoped<IYouTubeChannels, TYouTubeChannels>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddYouTubeI18nLanguges<TYouTubeI18nLanguages, THandler>()
        where TYouTubeI18nLanguages : class, IYouTubeI18nLanguages
        where THandler : class, IYouTubeI18nLanguageHandler
    {
        Services.TryAddScoped<IYouTubeI18nLanguages, TYouTubeI18nLanguages>();
        AddHandler<THandler>();

        return this;
    }

    public virtual YouTubeDataApiBuilder AddYouTubeI18nRegions<TYouTubeI18nRegions, THandler>()
        where TYouTubeI18nRegions : class, IYouTubeI18nRegions
        where THandler : class, IYouTubeI18nRegionHandler
    {
        Services.TryAddScoped<IYouTubeI18nRegions, TYouTubeI18nRegions>();
        AddHandler<THandler>();

        return this;
    }

    protected void AddHandler<THandler>() where THandler : class, IYouTubeHandler
    {
        Services.AddTransient<THandler>();

        Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<YouTubeOptions>, YouTubePostConfigureOptions<YouTubeOptions, THandler>>());

    }
}