// Licensed under the MIT license by loonfactory.

using System.Net;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Represents a failed YouTube Data API response without interpreting its error reason.
/// </summary>
public class YouTubeApiException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeApiException"/>.
    /// </summary>
    /// <remarks>
    /// This overload is retained for callers that construct an exception directly.
    /// HTTP response metadata is unavailable when it is used.
    /// </remarks>
    public YouTubeApiException(
        YouTubeApiRequestError error,
        Exception? innerException = null)
        : this(
            error?.Code is int code ? (HttpStatusCode)code : 0,
            error ?? throw new ArgumentNullException(nameof(error)),
            rawResponseBody: null,
            responseHeaders: null,
            innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeApiException"/>.
    /// </summary>
    public YouTubeApiException(
        HttpStatusCode statusCode,
        YouTubeApiRequestError error,
        string? rawResponseBody,
        IReadOnlyDictionary<string, IReadOnlyList<string>>? responseHeaders = null,
        Exception? innerException = null)
        : base(BuildMessage(error), innerException)
    {
        ArgumentNullException.ThrowIfNull(error);

        StatusCode = statusCode;
        Error = error;
        RawResponseBody = rawResponseBody;
        ResponseHeaders = responseHeaders ?? new Dictionary<string, IReadOnlyList<string>>();
    }

    /// <summary>
    /// Gets the HTTP status code returned by YouTube.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Gets the parsed YouTube error object, including its unmodified reason codes.
    /// </summary>
    public YouTubeApiRequestError Error { get; }

    /// <summary>
    /// Gets a snapshot of all HTTP response and content headers.
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>> ResponseHeaders { get; }

    /// <summary>
    /// Gets the unmodified API response body, if it could be read.
    /// </summary>
    public string? RawResponseBody { get; }

    private static string BuildMessage(YouTubeApiRequestError error)
    {
        ArgumentNullException.ThrowIfNull(error);

        if (!string.IsNullOrWhiteSpace(error.Message))
        {
            return error.Message;
        }

        return error.Errors?.FirstOrDefault()?.Message
            ?? "An unknown error occurred during the YouTube API request.";
    }
}
