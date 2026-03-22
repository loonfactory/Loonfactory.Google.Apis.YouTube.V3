// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideoFileDetails
{
    public string? FileName { get; set; }
    public ulong? FileSize { get; set; }
    public string? FileType { get; set; }
    public string? Container { get; set; }
    public IEnumerable<VideoFileDetailsVideoStream>? VideoStreams { get; set; }
    public IEnumerable<VideoFileDetailsAudioStream>? AudioStreams { get; set; }
    public ulong? DurationMs { get; set; }
    public ulong? BitrateBps { get; set; }
    public string? CreationTime { get; set; }
}
