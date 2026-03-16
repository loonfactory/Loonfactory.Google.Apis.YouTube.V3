// Licensed under the MIT license by loonfactory.

using System.Net;
using System.Text;
using Loonfactory.Google.Apis.YouTube.V3.Tests;
using Loonfactory.Google.Apis.YouTube.V3.VideoCategories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3;

public sealed class VideoCategoryServiceTests(VideoCategoryServiceFixture fixture) : IClassFixture<VideoCategoryServiceFixture>
{
    [Fact]
    public async Task ListByRegionCodeAsync_SendsExpectedRequest_AndReturnsResponseBody()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(VideoCategoryServiceFixture.ValidVideoCategoriesJson, Encoding.UTF8, "application/json")
            };
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideoCategoryService>();

        var response = await service.ListByRegionCodeAsync(
            part: "snippet",
            regionCode: "KR",
            hl: null,
            cancellationToken: default);

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Get, captured!.Method);
        Assert.Equal("https://www.googleapis.com/youtube/v3/videoCategories", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("snippet", query["part"]);
        Assert.Equal("KR", query["regionCode"]);
        Assert.Equal("test-api-key", query["key"]);

        Assert.Equal("youtube#videoCategoryListResponse", response.Kind);
        Assert.Equal(3, response.Items!.Count());
    }

    [Fact]
    public async Task ListByIdAsync_SendsExpectedQuery_WithMultiValueId()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""
                {
                  "kind": "youtube#videoCategoryListResponse",
                  "etag": "etag-value",
                  "items": []
                }
                """, Encoding.UTF8, "application/json")
            };
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideoCategoryService>();

        await service.ListByIdAsync(
            part: "snippet",
            id: new StringValues(["1", "2"]),
            hl: "ko",
            cancellationToken: default);

        Assert.NotNull(captured);
        var query = QueryHelpers.ParseQuery(captured!.RequestUri!.Query);

        Assert.Equal("snippet", query["part"]);
        Assert.Equal("ko", query["hl"]);
        Assert.Equal(new[] { "1", "2" }, query["id"].ToArray());
    }

    [Fact]
    public async Task ListByRegionCodeAsync_ThrowsWhenUpstreamRequestFails()
    {
        fixture.BackchannelHandler.Sender = _ => new HttpResponseMessage(HttpStatusCode.BadRequest);

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideoCategoryService>();

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.ListByRegionCodeAsync(part: "snippet", regionCode: "KR"));
    }

    [Fact]
    public async Task ListByIdAsync_ThrowsWhenIdIsMissing()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideoCategoryService>();

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.ListByIdAsync(part: "snippet", id: StringValues.Empty));
    }

    [Fact]
    public async Task ListByIdAsync_ThrowsWhenPartIsMissing()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideoCategoryService>();

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.ListByIdAsync(part: StringValues.Empty, id: "1"));
    }

    [Fact]
    public async Task ListByRegionCodeAsync_ThrowsWhenPartIsMissing()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideoCategoryService>();

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.ListByRegionCodeAsync(part: StringValues.Empty, regionCode: "KR"));
    }

    [Fact]
    public async Task ListByRegionCodeAsync_ThrowsWhenRegionCodeIsWhitespace()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IVideoCategoryService>();

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.ListByRegionCodeAsync(part: "snippet", regionCode: " "));
    }
}

public sealed class VideoCategoryServiceFixture : IAsyncLifetime
{
    public const string ValidVideoCategoriesJson = """
    {
      "kind": "youtube#videoCategoryListResponse",
      "etag": "QteLrrS_X7rM7rlcU_e7qa0embQ",
      "items": [
        {
          "kind": "youtube#videoCategory",
          "etag": "grPOPYEUUZN3ltuDUGEWlrTR90U",
          "id": "1",
          "snippet": {
            "title": "Film & Animation",
            "assignable": true,
            "channelId": "UCBR8-60-B28hp2BmDPdntcQ"
          }
        },
        {
          "kind": "youtube#videoCategory",
          "etag": "Q0xgUf8BFM8rW3W0R9wNq809xyA",
          "id": "2",
          "snippet": {
            "title": "Autos & Vehicles",
            "assignable": true,
            "channelId": "UCBR8-60-B28hp2BmDPdntcQ"
          }
        },
        {
          "kind": "youtube#videoCategory",
          "etag": "qnpwjh5QlWM5hrnZCvHisquztC4",
          "id": "10",
          "snippet": {
            "title": "Music",
            "assignable": true,
            "channelId": "UCBR8-60-B28hp2BmDPdntcQ"
          }
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
                                .AddVideoCategories();
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
