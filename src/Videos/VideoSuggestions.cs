// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideoSuggestions
{
    public IEnumerable<string>? ProcessingErrors { get; set; }
    public IEnumerable<string>? ProcessingWarnings { get; set; }
    public IEnumerable<string>? ProcessingHints { get; set; }
    public IEnumerable<VideoSuggestionsTagSuggestion>? TagSuggestions { get; set; }
    public IEnumerable<string>? EditorSuggestions { get; set; }
}
