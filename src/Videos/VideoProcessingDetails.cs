// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideoProcessingDetails
{
    public string? ProcessingStatus { get; set; }
    public VideoProcessingProgress? ProcessingProgress { get; set; }
    public string? ProcessingFailureReason { get; set; }
    public string? FileDetailsAvailability { get; set; }
    public string? ProcessingIssuesAvailability { get; set; }
    public string? TagSuggestionsAvailability { get; set; }
    public string? EditorSuggestionsAvailability { get; set; }
    public string? ThumbnailsAvailability { get; set; }
}
