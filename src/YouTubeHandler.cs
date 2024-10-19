// Licensed under the MIT license by loonfactory.

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3;

public abstract class YouTubeCaptionHandler : IYouTubeHandler
{
    /// <summary>
    /// Gets or sets the <see cref="YouTubeScheme"/> associated with this YouTube handler.
    /// </summary>
    public YouTubeScheme Scheme { get; private set; } = default!;

    /// <summary>
    /// Gets or sets the options associated with this YouTube handler.
    /// </summary>
    public YouTubeOptions Options { get; private set; } = default!;

    /// <summary>
    /// Gets or sets the <see cref="HttpContext"/>.
    /// </summary>
    protected HttpContext Context { get; private set; } = default!;

    /// <summary>
    /// Gets the <see cref="HttpRequest"/> associated with the current request.
    /// </summary>
    protected HttpRequest Request
    {
        get => Context.Request;
    }

    /// <summary>
    /// Gets the <see cref="HttpResponse" /> associated with the current request.
    /// </summary>
    protected HttpResponse Response
    {
        get => Context.Response;
    }

    /// <summary>
    /// Gets the <see cref="ILogger"/>.
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// Gets the <see cref="UrlEncoder"/>.
    /// </summary>
    protected UrlEncoder UrlEncoder { get; }

    /// <summary>
    /// Gets the current time, primarily for unit testing.
    /// </summary>
    protected TimeProvider TimeProvider { get; private set; } = TimeProvider.System;

    /// <summary>
    /// Gets the <see cref="IOptionsMonitor{TOptions}"/> to detect changes to options.
    /// </summary>
    protected IOptionsMonitor<YouTubeOptions> OptionsMonitor { get; }

    /// <summary>
    /// The handler calls methods on the events which give the application control at certain points where processing is occurring.
    /// If it is not provided a default instance is supplied which does nothing when the methods are called.
    /// </summary>
    protected virtual object? Events { get; set; }

    /// <summary>
    /// Gets the absolute current url.
    /// </summary>
    protected string CurrentUri
    {
        get => Request.Scheme + Uri.SchemeDelimiter + Request.Host + Request.PathBase + Request.Path + Request.QueryString;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeCaptionHandler" />.
    /// </summary>
    /// <param name="options">The monitor for the options instance.</param>
    /// <param name="logger">The <see cref="ILoggerFactory"/>.</param>
    /// <param name="encoder">The <see cref="UrlEncoder"/>.</param>
    protected YouTubeHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    {
        Logger = logger.CreateLogger(this.GetType().FullName!);
        UrlEncoder = encoder;
        OptionsMonitor = options;
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

        await InitializeEventsAsync().ConfigureAwait(false);
        await InitializeHandlerAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Initializes the events object, called once per request by <see cref="InitializeAsync(YouTubeScheme, HttpContext context)"/>.
    /// </summary>
    protected virtual Task InitializeEventsAsync() => Task.CompletedTask;

    /// <summary>
    /// Called after options/events have been initialized for the handler to finish initializing itself.
    /// </summary>
    /// <returns>A task</returns>
    protected virtual Task InitializeHandlerAsync() => Task.CompletedTask;
}