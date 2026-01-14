// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Search;

/// <summary>
/// Extension methods for <see cref="SearchProperties"/>.
/// </summary>
public static class SearchListOptionsExtensions
{
    public static SearchProperties ToSearchProperties(this SearchListOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return new SearchProperties
        {
            ChannelId = options.ChannelId,
            ForContentOwner = options.ForContentOwner,
            ForDeveloper = options.ForDeveloper,
            ForMine = options.ForMine,
            ChannelType = options.ChannelType,
            EventType = options.EventType,
            Location = options.Location,
            LocationRadius = options.LocationRadius,
            MaxResults = options.MaxResults,
            OnBehalfOfContentOwner = options.OnBehalfOfContentOwner,
            Order = options.Order,
            PageToken = options.PageToken,
            PublishedAfter = options.PublishedAfter,
            PublishedBefore = options.PublishedBefore,
            Q = options.Q,
            RegionCode = options.RegionCode,
            RelevanceLanguage = options.RelevanceLanguage,
            SafeSearch = options.SafeSearch,
            TopicId = options.TopicId,
            Type = options.Type,
            VideoCaption = options.VideoCaption,
            VideoCategoryId = options.VideoCategoryId,
            VideoDefinition = options.VideoDefinition,
            VideoDimension = options.VideoDimension,
            VideoDuration = options.VideoDuration,
            VideoEmbeddable = options.VideoEmbeddable,
            VideoLicense = options.VideoLicense,
        };
    }
}
