// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Thumbnails;

public class ThumbnailProperties : YouTubeProperties
{
    public static readonly string VideoIdKey = "videoId";
    public static readonly string OnBehalfOfContentOwnerKey = "onBehalfOfContentOwner";

    public ThumbnailProperties()
    { }

    public ThumbnailProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public ThumbnailProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public string? VideoId
    {
        get => GetParameter<string>(VideoIdKey);
        set => SetParameter(VideoIdKey, value);
    }

    public string? OnBehalfOfContentOwner
    {
        get => GetParameter<string>(OnBehalfOfContentOwnerKey);
        set => SetParameter(OnBehalfOfContentOwnerKey, value);
    }
}
