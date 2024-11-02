// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Captions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        Services.AddTransient<THandler>();
        return this;
    }
}