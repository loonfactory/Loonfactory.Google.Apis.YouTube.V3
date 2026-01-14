// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Search;

public class SearchListOptions
{
    public SearchListOptions() { }

    public SearchListOptions(SearchListOptions other)
    {
        ArgumentNullException.ThrowIfNull(other);

        ChannelId = other.ChannelId;
        ForContentOwner = other.ForContentOwner;
        ForDeveloper = other.ForDeveloper;
        ForMine = other.ForMine;
        ChannelType = other.ChannelType;
        EventType = other.EventType;
        Location = other.Location;
        LocationRadius = other.LocationRadius;
        MaxResults = other.MaxResults;
        OnBehalfOfContentOwner = other.OnBehalfOfContentOwner;
        Order = other.Order;
        PageToken = other.PageToken;
        PublishedAfter = other.PublishedAfter;
        PublishedBefore = other.PublishedBefore;
        Q = other.Q;
        RegionCode = other.RegionCode;
        RelevanceLanguage = other.RelevanceLanguage;
        SafeSearch = other.SafeSearch;
        TopicId = other.TopicId;
        Type = other.Type;
        VideoCaption = other.VideoCaption;
        VideoCategoryId = other.VideoCategoryId;
        VideoDefinition = other.VideoDefinition;
        VideoDimension = other.VideoDimension;
        VideoDuration = other.VideoDuration;
        VideoEmbeddable = other.VideoEmbeddable;
        VideoLicense = other.VideoLicense;
    }

    public StringValues? ChannelId { get; set; }
    public string? ForContentOwner { get; set; }
    public string? ForDeveloper { get; set; }
    public bool? ForMine { get; set; }
    public string? ChannelType { get; set; }
    public string? EventType { get; set; }
    public string? Location { get; set; }
    public string? LocationRadius { get; set; }
    public uint? MaxResults { get; set; }
    public string? OnBehalfOfContentOwner { get; set; }
    public string? Order { get; set; }
    public string? PageToken { get; set; }
    public DateTimeOffset? PublishedAfter { get; set; }
    public DateTimeOffset? PublishedBefore { get; set; }
    public string? Q { get; set; }
    public string? RegionCode { get; set; }
    public string? RelevanceLanguage { get; set; }
    public string? SafeSearch { get; set; }
    public StringValues? TopicId { get; set; }
    public string? Type { get; set; }
    public string? VideoCaption { get; set; }
    public string? VideoCategoryId { get; set; }
    public string? VideoDefinition { get; set; }
    public string? VideoDimension { get; set; }
    public string? VideoDuration { get; set; }
    public string? VideoEmbeddable { get; set; }
    public string? VideoLicense { get; set; }
}
