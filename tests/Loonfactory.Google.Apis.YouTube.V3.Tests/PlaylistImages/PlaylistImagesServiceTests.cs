// Licensed under the MIT license by loonfactory.

using System.Net;
using System.Text;
using Loonfactory.Google.Apis.YouTube.V3.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;

public class PlaylistImagesServiceTests
{
    [Fact]
    public async Task Operations_SendAccessTokenAsBearerToken()
    {
        var requests = new List<(HttpMethod Method, string? Scheme, string? Token)>();
        var backchannelHandler = new TestHttpMessageHandler
        {
            Sender = request =>
            {
                requests.Add((
                    request.Method,
                    request.Headers.Authorization?.Scheme,
                    request.Headers.Authorization?.Parameter));

                var body = request.Method == HttpMethod.Get
                    ? """{"items":[]}"""
                    : """{"id":"image-1","snippet":{"playlistId":"playlist-1","type":"default"}}""";

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
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
            .AddAccessTokenProvider<TestAccessTokenProvider>();
        services.AddScoped<IPlaylistImagesService, PlaylistImagesService>();
        services.AddTransient<PlaylistImageHandler>();

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IPlaylistImagesService>();
        var resource = new PlaylistImageResource
        {
            Id = "image-1",
            Snippet = new PlaylistImageSnippet
            {
                PlaylistId = "playlist-1",
                Type = "default"
            }
        };

        await service.ListByPlaylistIdAsync("snippet", "playlist-1").ConfigureAwait(true);
        await service.InsertAsync(
            "snippet",
            resource,
            new StreamContent(new MemoryStream([1, 2, 3]))).ConfigureAwait(true);
        await service.UpdateAsync(
            "snippet",
            resource,
            new StreamContent(new MemoryStream([4, 5, 6]))).ConfigureAwait(true);
        await service.DeleteAsync("image-1").ConfigureAwait(true);

        Assert.Collection(
            requests,
            request => AssertAuthorization(request, HttpMethod.Get),
            request => AssertAuthorization(request, HttpMethod.Post),
            request => AssertAuthorization(request, HttpMethod.Put),
            request => AssertAuthorization(request, HttpMethod.Delete));
    }

    private static void AssertAuthorization(
        (HttpMethod Method, string? Scheme, string? Token) request,
        HttpMethod method)
    {
        Assert.Equal(method, request.Method);
        Assert.Equal("Bearer", request.Scheme);
        Assert.Equal("test-access-token", request.Token);
    }

    private sealed class TestAccessTokenProvider : IAccessTokenProvider
    {
        public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<string?>("test-access-token");
    }
}
