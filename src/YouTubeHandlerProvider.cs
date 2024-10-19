// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// 
/// </summary>
public class YouTubeHandlerProvider : IYouTubeHandlerProvider
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="schemes">The <see cref="IYouTubeSchemeProvider"/>.</param>
    public YouTubeHandlerProvider(IYouTubeSchemeProvider schemes)
    {
        Schemes = schemes;
    }

    /// <summary>
    /// The <see cref="IYouTubeSchemeProvider"/>.
    /// </summary>
    public IYouTubeSchemeProvider Schemes { get; }

    // handler instance cache, need to initialize once per request
    private readonly Dictionary<string, IYouTubeHandler> _handlerMap = new(StringComparer.Ordinal);

    /// <summary>
    /// Returns the handler instance that will be used.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="schemeName">The name of the YouTube scheme being handled.</param>
    /// <returns>The handler instance.</returns>
    public async Task<IYouTubeHandler?> GetHandlerAsync(HttpContext context, string schemeName)
    {
        if (_handlerMap.TryGetValue(schemeName, out var value))
        {
            return value;
        }

        var scheme = await Schemes.GetSchemeAsync(schemeName).ConfigureAwait(false);
        if (scheme == null)
        {
            return null;
        }

        var handler = (context.RequestServices.GetService(scheme.HandlerType) ??
            ActivatorUtilities.CreateInstance(context.RequestServices, scheme.HandlerType))
            as IYouTubeHandler;
        if (handler != null)
        {
            await handler.InitializeAsync(scheme, context).ConfigureAwait(false);
            _handlerMap[schemeName] = handler;
        }
        return handler;
    }

      /// <summary>
    /// Initialize the handler, resolve the options and validate them.
    /// </summary>
    /// <param name="scheme"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InitializeAsync(YouTubeScheme scheme, HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(scheme);
        ArgumentNullException.ThrowIfNull(context);

        Scheme = scheme;
        Context = context;

        Options = OptionsMonitor.Get(Scheme.Name);

        TimeProvider = Options.TimeProvider ?? TimeProvider.System;
#pragma warning disable CS0618 // Type or member is obsolete
        Clock = TimeProvider == TimeProvider.System ? SystemClock.Default : new SystemClock(TimeProvider);
#pragma warning restore CS0618 // Type or member is obsolete

        await InitializeEventsAsync();
        await InitializeHandlerAsync();
    }

}