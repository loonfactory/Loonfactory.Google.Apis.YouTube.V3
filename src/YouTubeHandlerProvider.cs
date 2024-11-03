// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// @TODO
/// </summary>
public class YouTubeHandlerProvider(IServiceProvider serviceProvider) : IYouTubeHandlerProvider
{
    /// <summary>
    /// The <see cref="IServiceProvider"/>.
    /// </summary>
    public IServiceProvider ServiceProvider { get; } = serviceProvider;

    // handler instance cache, need to initialize once per request
    private readonly Dictionary<Type, IYouTubeHandler> _handlerMap = [];

    /// <summary>
    /// Returns the handler instance that will be used.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="schemeName">The name of the YouTube scheme being handled.</param>
    /// <returns>The handler instance.</returns>
    public async Task<T?> GetHandlerAsync<T>(HttpContext? context = null) where T : class, IYouTubeHandler
    {
        if (_handlerMap.TryGetValue(typeof(T), out var value))
        {
            return value as T;
        }

        var handlerType = typeof(T);
        var handler = (context?.RequestServices.GetService(handlerType) ??
            ActivatorUtilities.CreateInstance(context?.RequestServices ?? ServiceProvider, handlerType))
            as T;

        if (handler != null)
        {
            await handler.InitializeAsync(context).ConfigureAwait(false);
            _handlerMap[handlerType] = handler;
        }
        return handler;
    }
}