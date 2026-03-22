// Licensed under the MIT license by loonfactory.

using System.Net;
using Loonfactory.Google.Apis.YouTube.V3.Tests;
using Loonfactory.Google.Apis.YouTube.V3.Watermarks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Loonfactory.Google.Apis.YouTube.V3;

public sealed class WatermarkServiceTests(WatermarkServiceFixture fixture) : IClassFixture<WatermarkServiceFixture>
{
    [Fact]
    public async Task SetAsync_SendsExpectedRequest()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IWatermarkService>();

        using var stream = new MemoryStream([0x01, 0x02, 0x03]);

        await service.SetAsync(
            channelId: "UC123",
            resource: new WatermarkResource
            {
                TargetChannelId = "UC_TARGET",
                Position = new WatermarkPosition
                {
                    Type = "corner",
                    CornerPosition = "topRight"
                },
                Timing = new WatermarkTiming
                {
                    Type = "offsetFromStart",
                    OffsetMs = 0,
                    DurationMs = 5000
                }
            },
            stream: stream,
            contentType: "image/png",
            onBehalfOfContentOwner: "owner-id",
            cancellationToken: default);

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Post, captured!.Method);
        Assert.Equal("https://www.googleapis.com/upload/youtube/v3/watermarks/set", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("UC123", query["channelId"]);
        Assert.Equal("owner-id", query["onBehalfOfContentOwner"]);
        Assert.Equal("test-api-key", query["key"]);

        Assert.Equal("Bearer", captured.Headers.Authorization?.Scheme);
        Assert.Equal("test-access-token", captured.Headers.Authorization?.Parameter);
        Assert.Equal("multipart/related", captured.Content?.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task SetAsync_ThrowsWhenUpstreamRequestFails()
    {
        fixture.BackchannelHandler.Sender = _ => new HttpResponseMessage(HttpStatusCode.BadRequest);

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IWatermarkService>();
        using var stream = new MemoryStream([0x01]);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.SetAsync(
                channelId: "UC123",
                resource: new WatermarkResource(),
                stream: stream,
                contentType: "image/png"));
    }

    [Fact]
    public async Task SetAsync_ThrowsWhenChannelIdIsMissing()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IWatermarkService>();
        using var stream = new MemoryStream([0x01]);

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.SetAsync(
                channelId: " ",
                resource: new WatermarkResource(),
                stream: stream,
                contentType: "image/png"));
    }

    [Fact]
    public async Task SetAsync_ThrowsWhenContentTypeIsNotAllowed()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IWatermarkService>();
        using var stream = new MemoryStream([0x01]);

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.SetAsync(
                channelId: "UC123",
                resource: new WatermarkResource(),
                stream: stream,
                contentType: "text/plain"));
    }

    [Fact]
    public async Task UnsetAsync_SendsExpectedRequest()
    {
        HttpRequestMessage? captured = null;

        fixture.BackchannelHandler.Sender = request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        };

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IWatermarkService>();

        await service.UnsetAsync("UC123", onBehalfOfContentOwner: "owner-id");

        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Post, captured!.Method);
        Assert.Equal("https://www.googleapis.com/youtube/v3/watermarks/unset", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("UC123", query["channelId"]);
        Assert.Equal("owner-id", query["onBehalfOfContentOwner"]);
        Assert.Equal("test-api-key", query["key"]);

        Assert.Equal("Bearer", captured.Headers.Authorization?.Scheme);
        Assert.Equal("test-access-token", captured.Headers.Authorization?.Parameter);
    }

    [Fact]
    public async Task UnsetAsync_ThrowsWhenUpstreamRequestFails()
    {
        fixture.BackchannelHandler.Sender = _ => new HttpResponseMessage(HttpStatusCode.BadRequest);

        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IWatermarkService>();

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.UnsetAsync("UC123"));
    }

    [Fact]
    public async Task UnsetAsync_ThrowsWhenChannelIdIsMissing()
    {
        using var scope = fixture.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IWatermarkService>();

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.UnsetAsync(" "));
    }
}

public sealed class WatermarkServiceFixture : IAsyncLifetime
{
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
                                .AddWatermarks();
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
    {
        return Task.FromResult<string?>("test-access-token");
    }
}
