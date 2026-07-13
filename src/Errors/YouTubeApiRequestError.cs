// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Represents the <c>error</c> object in a YouTube Data API error response.
/// </summary>
public class YouTubeApiRequestError
{
    /// <summary>
    /// The HTTP status code reported by the API.
    /// </summary>
    public int? Code { get; set; }

    /// <summary>
    /// The API's top-level error message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// The individual error details reported by the API.
    /// </summary>
    public IEnumerable<YouTubeApiError>? Errors { get; set; }
}
