// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Responsible for managing what YouTubeSchemes are supported.
/// </summary>
public interface IYouTubeSchemeProvider
{
    /// <summary>
    /// Returns all currently registered <see cref="YouTubeScheme"/>s.
    /// </summary>
    /// <returns>All currently registered <see cref="YouTubeScheme"/>s.</returns>
    Task<IEnumerable<YouTubeScheme>> GetAllSchemesAsync();

    /// <summary>
    /// Returns the <see cref="YouTubeScheme"/> matching the name, or null.
    /// </summary>
    /// <param name="name">The name of the YouTubeScheme.</param>
    /// <returns>The scheme or null if not found.</returns>
    Task<YouTubeScheme?> GetSchemeAsync(string name);

    /// <summary>
    /// Registers a scheme for use by <see cref="IYouTubeService"/>.
    /// </summary>
    /// <param name="scheme">The scheme.</param>
    void AddScheme(YouTubeScheme scheme);

    /// <summary>
    /// Registers a scheme for use by <see cref="IYouTubeService"/>.
    /// </summary>
    /// <param name="scheme">The scheme.</param>
    /// <returns>true if the scheme was added successfully.</returns>
    bool TryAddScheme(YouTubeScheme scheme)
    {
        try
        {
            AddScheme(scheme);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Removes a scheme, preventing it from being used by <see cref="IYouTubeService"/>.
    /// </summary>
    /// <param name="name">The name of the YouTubeScheme being removed.</param>
    void RemoveScheme(string name);

    /// <summary>
    /// Returns the schemes in priority order for request handling.
    /// </summary>
    /// <returns>The schemes in priority order for request handling</returns>
    Task<IEnumerable<YouTubeScheme>> GetRequestHandlerSchemesAsync();
}