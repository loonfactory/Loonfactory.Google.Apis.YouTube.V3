// Licensed under the MIT license by loonfactory.

using System.Text;
using System.Globalization;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Represents a YouTube API failure with mapped metadata and parsed response details.
/// </summary>
public class YouTubeApiException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeApiException"/>.
    /// </summary>
    public YouTubeApiException(
        YouTubeApiRequestError error,
        Exception? innerException = null)
        : base(BuildMessage(error), innerException)
    {
        Error = error;
    }
    public YouTubeApiRequestError? Error { get; }

    /// <summary>
    /// Gets the raw API response body, if available.
    /// </summary>
    public string? RawResponseBody { get; }

    private static string BuildMessage(YouTubeApiRequestError error)
    {
        var sb = new StringBuilder();
        sb.AppendLine(typeof(YouTubeApiException).FullName ?? nameof(YouTubeApiException))
          .Append(error.Message)
          .AppendFormat(CultureInfo.InvariantCulture, " [{0}]", error.Code)
          .AppendLine();

        if (error.Errors == null || error.Errors?.Count() == 0)
        {
            sb.AppendLine("No individual errors");
        }
        else
        {
            sb.AppendLine("Errors [");
            foreach (var err in error.Errors!)
            {
                sb.Append('\t').AppendLine(err.ToString());
            }
            sb.AppendLine("]");
        }

        if (!string.IsNullOrWhiteSpace(error.Message))
        {
            return error.Message;
        }

        return error.Errors?.FirstOrDefault()?.Message ?? "An unknown error occurred during the YouTube API request.";
    }
}
