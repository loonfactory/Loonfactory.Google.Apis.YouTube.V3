// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public class PlaylistImageListResponse
{
    public string? Kind { get; set; }
    public string? NextPageToken { get; set; }
    public string? PrevPageToken { get; set; }
    public YouTubePageInfo? PageInfo { get; set; }
    public IEnumerable<PlaylistImageResource>? Items { get; set; }
}