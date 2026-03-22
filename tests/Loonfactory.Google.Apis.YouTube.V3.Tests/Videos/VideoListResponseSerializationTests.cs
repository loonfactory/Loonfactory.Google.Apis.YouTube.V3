// Licensed under the MIT license by loonfactory.

using System.Text.Json;
using Loonfactory.Google.Apis.YouTube.V3.Videos;

namespace Loonfactory.Google.Apis.YouTube.V3;

public sealed class VideoListResponseSerializationTests
{
    [Fact]
    public void Deserialize_WithUserProvidedVideoListJson_MapsFields()
    {
        var fixturePath = Path.Combine(AppContext.BaseDirectory, "Fixtures", "video-list-user.json");
        var json = File.ReadAllText(fixturePath);

        var response = JsonSerializer.Deserialize<VideoListResponse>(json, YouTubeDefaults.JsonSerializerOptions);

        Assert.NotNull(response);
        Assert.Equal("youtube#videoListResponse", response!.Kind);
        Assert.Equal(1, response.PageInfo!.TotalResults);
        Assert.Equal(1, response.PageInfo.ResultsPerPage);

        var item = Assert.Single(response.Items!);

        Assert.Equal("0e3GPea1Tyg", item.Id);
        Assert.Equal("$456,000 Squid Game In Real Life!", item.Snippet!.Title);
        Assert.Equal("https://i.ytimg.com/vi/0e3GPea1Tyg/default.jpg", item.Snippet.Thumbnails!["default"].Url);

        Assert.NotNull(item.ContentDetails!.ContentRating);
        Assert.Equal("rectangular", item.ContentDetails.Projection);

        Assert.Equal("processed", item.Status!.UploadStatus);
        Assert.True(item.Status.Embeddable);
        Assert.False(item.Status.MadeForKids);

        Assert.Equal((ulong)914000309, item.Statistics!.ViewCount);
        Assert.Equal((ulong)19894449, item.Statistics.LikeCount);

        Assert.False(item.PaidProductPlacementDetails!.HasPaidProductPlacement);
        Assert.Equal(
            "https://en.wikipedia.org/wiki/Lifestyle_(sociology)",
            item.TopicDetails!.TopicCategories!.Single());
        Assert.NotNull(item.RecordingDetails);
        Assert.Equal("한국어 제목", item.Localizations!["ko"].Title);
    }
}
