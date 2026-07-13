// Licensed under the MIT license by loonfactory.

using System.Collections.Concurrent;
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

    // Each lazy value owns the asynchronous creation and initialization of one handler type.
    // The provider is scoped, so successful and failed initialization tasks are shared only
    // within the current request scope.
    private readonly ConcurrentDictionary<Type, Lazy<Task<IYouTubeHandler>>> _handlerMap = [];

    /// <summary>
    /// Returns the handler instance that will be used.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="schemeName">The name of the YouTube scheme being handled.</param>
    /// <returns>The handler instance.</returns>
    public async Task<T?> GetHandlerAsync<T>() where T : class, IYouTubeHandler
    {
        var handlerType = typeof(T);
        var lazyHandler = _handlerMap.GetOrAdd(
            handlerType,
            type => new Lazy<Task<IYouTubeHandler>>(
                () => CreateAndInitializeHandlerAsync(type),
                LazyThreadSafetyMode.ExecutionAndPublication));

        return await lazyHandler.Value.ConfigureAwait(false) as T;
    }

    private async Task<IYouTubeHandler> CreateAndInitializeHandlerAsync(Type handlerType)
    {
        var handler = ActivatorUtilities.CreateInstance(ServiceProvider, handlerType)
            as IYouTubeHandler
            ?? throw new InvalidOperationException($"Unable to create a YouTube handler for type '{handlerType}'.");

        await handler.InitializeAsync().ConfigureAwait(false);
        return handler;
    }
}
