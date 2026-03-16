// Licensed under the MIT license by loonfactory.

using System.Net;
using System.Text;
using Loonfactory.Google.Apis.YouTube.V3.Tests;
using Loonfactory.Google.Apis.YouTube.V3.Videos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3;

public sealed class VideosServiceTests(VideosServiceFixture fixture) : IClassFixture<VideosServiceFixture>
{
    [Fact]
    public async Task ListByIdAsync_SendsExpectedRequest_AndReturnsResponseBody()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(VideosServiceFixture.ValidVideosListJson, Encoding.UTF8, "application/json")
            };
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        var response = await service.ListByIdAsync(
            part: "snippet",
            id: "abc123",
            maxResults: 5,
            pageToken: "PAGE_1",
            cancellationToken: default);

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Get, captured!.Method);
        Assert.Equal("https://www.googleapis.com/youtube/v3/videos", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("snippet", query["part"]);
        Assert.Equal("abc123", query["id"]);
        Assert.Equal("5", query["maxResults"]);
        Assert.Equal("PAGE_1", query["pageToken"]);
        Assert.Equal("test-api-key", query["key"]);

        Assert.Equal("youtube#videoListResponse", response.Kind);
        Assert.Single(response.Items!);
    }

    [Fact]
    public async Task ListByChartAsync_SendsExpectedQuery()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(VideosServiceFixture.ValidVideosListJson, Encoding.UTF8, "application/json")
            };
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        await service.ListByChartAsync(
            part: "snippet",
            chart: "mostPopular",
            regionCode: "KR",
            videoCategoryId: "10",
            maxHeight: 720,
            maxWidth: 1280,
            cancellationToken: default);

        Assert.NotNull(captured);

        var query = QueryHelpers.ParseQuery(captured!.RequestUri!.Query);
        Assert.Equal("snippet", query["part"]);
        Assert.Equal("mostPopular", query["chart"]);
        Assert.Equal("KR", query["regionCode"]);
        Assert.Equal("10", query["videoCategoryId"]);
        Assert.Equal("720", query["maxHeight"]);
        Assert.Equal("1280", query["maxWidth"]);
    }

    [Fact]
    public async Task InsertAsync_SendsExpectedRequest_WithAuthorizationHeader()
    {
        HttpRequestMessage? captured = null;
        string? capturedBody = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            if (request.Content is not null)
            {
                using var stream = request.Content.ReadAsStream();
                using var reader = new StreamReader(stream);
                capturedBody = reader.ReadToEnd();
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(VideosServiceFixture.ValidVideoResourceJson, Encoding.UTF8, "application/json")
            };
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        await service.InsertAsync(
            part: "snippet",
            resource: new VideoResource
            {
                Snippet = new VideoSnippet
                {
                    Title = "Test video",
                    CategoryId = "22"
                }
            },
            notifySubscribers: true,
            cancellationToken: default);

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Post, captured!.Method);
        Assert.Equal("https://www.googleapis.com/upload/youtube/v3/videos", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("snippet", query["part"]);
        Assert.Equal("True", query["notifySubscribers"]);
        Assert.Equal("test-api-key", query["key"]);

        Assert.NotNull(captured.Headers.Authorization);
        Assert.Equal("Bearer", captured.Headers.Authorization!.Scheme);
        Assert.Equal("test-access-token", captured.Headers.Authorization.Parameter);

        Assert.Contains("\"title\":\"Test video\"", capturedBody);
        Assert.Contains("\"categoryId\":\"22\"", capturedBody);
    }

    [Fact]
    public async Task DeleteAsync_SendsExpectedRequest()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        await service.DeleteAsync("abc123", cancellationToken: default);

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Delete, captured!.Method);
        Assert.Equal("https://www.googleapis.com/youtube/v3/videos", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("abc123", query["id"]);

        Assert.NotNull(captured.Headers.Authorization);
        Assert.Equal("Bearer", captured.Headers.Authorization!.Scheme);
    }

    [Fact]
    public async Task RateAsync_SendsExpectedRequest()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        await service.RateAsync(id: "abc123", rating: "like", cancellationToken: default);

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Post, captured!.Method);
        Assert.Equal("https://www.googleapis.com/youtube/v3/videos/rate", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("abc123", query["id"]);
        Assert.Equal("like", query["rating"]);
    }

    [Fact]
    public async Task GetRatingAsync_SendsExpectedRequest_AndReturnsResponseBody()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(VideosServiceFixture.ValidGetRatingJson, Encoding.UTF8, "application/json")
            };
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        var response = await service.GetRatingAsync(id: "abc123", cancellationToken: default);

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Get, captured!.Method);
        Assert.Equal("https://www.googleapis.com/youtube/v3/videos/getRating", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("abc123", query["id"]);

        Assert.Equal("youtube#videoGetRatingResponse", response.Kind);
        Assert.Equal("like", response.Items!.Single().Rating);
    }

    [Fact]
    public async Task ReportAbuseAsync_SendsExpectedRequestBody()
    {
        HttpRequestMessage? captured = null;
        string? capturedBody = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            if (request.Content is not null)
            {
                using var stream = request.Content.ReadAsStream();
                using var reader = new StreamReader(stream);
                capturedBody = reader.ReadToEnd();
            }

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        await service.ReportAbuseAsync(
            new VideoReportAbuseRequest
            {
                VideoId = "abc123",
                ReasonId = "32",
                SecondaryReasonId = "89"
            },
            cancellationToken: default);

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Post, captured!.Method);
        Assert.Equal("https://www.googleapis.com/youtube/v3/videos/reportAbuse", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        Assert.Contains("\"videoId\":\"abc123\"", capturedBody);
        Assert.Contains("\"reasonId\":\"32\"", capturedBody);
        Assert.Contains("\"secondaryReasonId\":\"89\"", capturedBody);
    }

    [Fact]
    public async Task ListByIdAsync_ThrowsWhenPartIsMissing()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.ListByIdAsync(part: StringValues.Empty, id: "abc123"));
    }

    [Fact]
    public async Task RateAsync_ThrowsWhenRatingIsWhitespace()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideosService>();

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.RateAsync(id: "abc123", rating: " "));
    }
}

public sealed class VideosServiceFixture : IAsyncLifetime
{
    public const string ValidVideosListJson = """
    {
      "kind": "youtube#videoListResponse",
      "etag": "test-etag",
      "items": [
        {
          "kind": "youtube#video",
          "etag": "video-etag",
          "id": "abc123",
          "snippet": {
            "title": "Test video",
            "categoryId": "22"
          }
        }
      ]
    }
    """;

    public const string ValidVideoResourceJson = """
    {
      "kind": "youtube#video",
      "etag": "video-etag",
      "id": "abc123",
      "snippet": {
        "title": "Test video",
        "categoryId": "22"
      }
    }
    """;

    public const string ValidGetRatingJson = """
    {
      "kind": "youtube#videoGetRatingResponse",
      "etag": "rating-etag",
      "items": [
        {
          "videoId": "abc123",
          "rating": "like"
        }
      ]
    }
    """;

    public TestHttpMessageHandler BackchannelHandler { get; } = new();

    public IServiceProvider Services => _host?.Services ?? throw new InvalidOperationException("The fixture host is not initialized.");

    private IHost? _host;

    public async Task InitializeAsync()
    {
        var backchannel = new HttpClient(BackchannelHandler);

        _host = new HostBuilder()
            .ConfigureWebHost(builder =>
                builder.UseTestServer()
                    .Configure(_ => { })
                    .ConfigureServices(services =>
                    {
                        services.AddOptions<YouTubeOptions>()
                            .Configure(options =>
                            {
                                options.Key = "test-api-key";
                                options.Backchannel = backchannel;
                            });

                        services.AddYouTubeDataApiCore()
                                .AddAccessTokenProvider<TestAccessTokenProvider>()
                                .AddVideos();
                    }))
            .Build();

        await _host.StartAsync();
    }

    public async Task DisposeAsync()
    {
        if (_host is null)
        {
            return;
        }

        await _host.StopAsync();
        _host.Dispose();
    }
}

public sealed class TestAccessTokenProvider : IAccessTokenProvider
{
    public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => Task.FromResult<string?>("test-access-token");
}
