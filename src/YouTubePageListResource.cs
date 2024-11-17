// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

public abstract class YouTubePageListResource<T> : YouTubeListResource<T>
{
    public virtual string? NextPageToken { get; set; }
    public virtual string? PrevPageToken { get; set; }
    public virtual YouTubePageInfo? PageInfo { get; set; }
    public override IEnumerable<T>? Items { get; set; }
}