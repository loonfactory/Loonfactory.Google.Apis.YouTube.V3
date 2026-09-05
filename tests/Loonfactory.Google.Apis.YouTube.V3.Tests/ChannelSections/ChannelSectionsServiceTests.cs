// Licensed under the MIT license by loonfactory.

using System.Net;
using System.Text;
using Loonfactory.Google.Apis.YouTube.V3.Tests;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

public class ChannelSectionsServiceTests
{
    [Fact]
    public async Task DeleteAsync_SendsIdOwnerAndBearerToken()
    {
        HttpRequestMessage? captured = null;
        using var provider = CreateServiceProvider(request =>
        {
            captured = request;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    """{"id":"section-1"}""",
                    Encoding.UTF8,
                    "application/json")
            };
        });
        using var scope = provider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IChannelSections>();

        var deleted = await service.DeleteAsync("section-1", "owner-1").ConfigureAwait(true);

        Assert.Equal("section-1", deleted.Id);
        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Delete, captured!.Method);
        Assert.Equal(
            "https://www.googleapis.com/youtube/v3/channelSections",
            captured.RequestUri!.GetLeftPart(UriPartial.Path));

        var query = QueryHelpers.ParseQuery(captured.RequestUri.Query);
        Assert.Equal("section-1", query["id"]);
        Assert.Equal("owner-1", query["onBehalfOfContentOwner"]);
        Assert.Equal("test-api-key", query["key"]);
        Assert.Equal("Bearer", captured.Headers.Authorization?.Scheme);
        Assert.Equal("test-access-token", captured.Headers.Authorization?.Parameter);
    }

    [Fact]
    public async Task InsertAndUpdateAsync_AllowOmittedOwnerParameters()
    {
        var methods = new List<HttpMethod>();
        using var provider = CreateServiceProvider(request =>
        {
            methods.Add(request.Method);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    """{"id":"section-1"}""",
                    Encoding.UTF8,
                    "application/json")
            };
        });
        using var scope = provider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IChannelSections>();
        var resource = new ChannelSectionResource { Id = "section-1" };

        await service.InsertAsync("snippet", resource).ConfigureAwait(true);
        await service.UpdateAsync("snippet", resource).ConfigureAwait(true);

        Assert.Equal([HttpMethod.Post, HttpMethod.Put], methods);
    }

    private static ServiceProvider CreateServiceProvider(
        Func<HttpRequestMessage, HttpResponseMessage?> sender)
    {
        var backchannelHandler = new TestHttpMessageHandler { Sender = sender };
        var backchannel = new HttpClient(backchannelHandler);
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
            .AddChannelSections<ChannelSectionsService, ChannelSectionHandler>();

        return services.BuildServiceProvider();
    }

    private sealed class TestAccessTokenProvider : IAccessTokenProvider
    {
        public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<string?>("test-access-token");
    }
}
