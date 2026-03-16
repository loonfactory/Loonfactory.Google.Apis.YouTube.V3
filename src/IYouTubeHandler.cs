// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Created per request to handle YouTube for a particular scheme.
/// </summary>
public interface IYouTubeHandler
{
    /// <summary>
    /// Initialize the YouTube handler. The handler should initialize anything it needs from the request and scheme as part of this method.
    /// </summary>
    Task InitializeAsync();
}
