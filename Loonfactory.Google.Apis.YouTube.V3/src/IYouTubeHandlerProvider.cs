// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Http;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Provides the appropriate IYouTubeHandler instance for the request.
/// </summary>
public interface IYouTubeHandlerProvider
{
    /// <summary>
    /// Returns the handler instance that will be used.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/>.</param>
    /// <param name="scheme">The name of the YouTube scheme being handled.</param>
    /// <returns>The handler instance.</returns>
    Task<IYouTubeHandler?> GetHandlerAsync(HttpContext context, string scheme);
}