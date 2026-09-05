// Licensed under the MIT license by loonfactory.

using System.Net;
using System.Text;
using Loonfactory.Google.Apis.YouTube.V3.Tests;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

public class CaptionsServiceTests
{
    [Fact]
    public async Task ListAsync_SendsPartQueryParameter()
    {
        HttpRequestMessage? captured = null;
        var backchannelHandler = new TestHttpMessageHandler
        {
            Sender = request =>
            {
                captured = request;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                };
            }
        };
        using var backchannel = new HttpClient(backchannelHandler);
        var services = new ServiceCollection();

        services.AddLogging();
        services.AddOptions<YouTubeOptions>()
            .Configure(options =>
            {
                options.Key = "test-api-key";
                options.Backchannel = backchannel;
            });
        services.AddYouTubeDataApiCore()
            .AddAccessTokenProvider<TestAccessTokenProvider>()
            .AddCaptions<CaptionsService, CaptionHandler>();

        using var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<ICaptionsService>();

        await service.ListAsync("snippet", "video-1").ConfigureAwait(true);

        Assert.NotNull(captured);
        var query = QueryHelpers.ParseQuery(captured!.RequestUri!.Query);
        Assert.Equal("snippet", query["part"]);
        Assert.False(query.ContainsKey("parts"));
    }

    [Fact]
    public async Task DownloadAsync_SendsFormatAndTranslationOptions_AndReturnsCaptionStream()
    {
        HttpRequestMessage? captured = null;
        var backchannelHandler = new TestHttpMessageHandler
        {
            Sender = request =>
            {
                captured = request;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("WEBVTT\n\n00:00.000 --> 00:01.000\nHello", Encoding.UTF8, "text/vtt")
                };
            }
        };
        using var backchannel = new HttpClient(backchannelHandler);
        var services = new ServiceCollection();

        services.AddLogging();
        services.AddOptions<YouTubeOptions>()
            .Configure(options =>
            {
                options.Key = "test-api-key";
                options.Backchannel = backchannel;
            });
        services.AddYouTubeDataApiCore()
            .AddAccessTokenProvider<TestAccessTokenProvider>()
            .AddCaptions<CaptionsService, CaptionHandler>();

        using var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<ICaptionsService>();

        using var stream = await service.DownloadAsync(
            id: "caption-1",
            onBehalfOfContentOwner: "owner-1",
            tfmt: "vtt",
            tlang: "ko").ConfigureAwait(true);
        using var reader = new StreamReader(stream);

        var caption = await reader.ReadToEndAsync().ConfigureAwait(true);

        Assert.Equal("WEBVTT\n\n00:00.000 --> 00:01.000\nHello", caption);
        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Get, captured!.Method);
        Assert.Equal("https://www.googleapis.com/youtube/v3/captions/caption-1", captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("owner-1", query["onBehalfOfContentOwner"]);
        Assert.Equal("vtt", query["tfmt"]);
        Assert.Equal("ko", query["tlang"]);
        Assert.Equal("test-api-key", query["key"]);
        Assert.Equal("Bearer", captured.Headers.Authorization?.Scheme);
        Assert.Equal("test-access-token", captured.Headers.Authorization?.Parameter);
    }

    private sealed class TestAccessTokenProvider : IAccessTokenProvider
    {
        public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<string?>("test-access-token");
    }
}
