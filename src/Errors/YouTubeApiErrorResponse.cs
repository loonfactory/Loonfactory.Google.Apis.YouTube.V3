// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Represents the top-level JSON shape of a YouTube Data API error response.
/// </summary>
public sealed record YouTubeApiErrorResponse
{
    /// <summary>
    /// Gets the error reported by the API.
    /// </summary>
    public YouTubeApiRequestError? Error { get; init; }
}
