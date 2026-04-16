// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Represents a detail entry from a YouTube API v1 error payload.
/// </summary>
public sealed record YouTubeApiError
{
    /// <summary>
    /// The error domain (for example, <c>global</c> or <c>youtube.parameter</c>).
    /// </summary>
    public string? Domain { get; init; }

    /// <summary>
    /// The reason code for this detail.
    /// </summary>
    public string? Reason { get; init; }

    /// <summary>
    /// A human-readable message for this detail.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// The location type for the field that caused the error.
    /// </summary>
    public string? LocationType { get; init; }

    /// <summary>
    /// The specific location that caused the error.
    /// </summary>
    public string? Location { get; init; }
}
