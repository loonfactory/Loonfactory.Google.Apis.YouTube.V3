// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Videos;

public class VideoStatus
{
    public string? UploadStatus { get; set; }
    public string? PrivacyStatus { get; set; }
    public string? License { get; set; }
    public bool? Embeddable { get; set; }
    public bool? PublicStatsViewable { get; set; }
    public bool? MadeForKids { get; set; }
    public bool? SelfDeclaredMadeForKids { get; set; }
}
