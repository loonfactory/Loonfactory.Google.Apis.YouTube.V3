// Licensed under the MIT license by loonfactory.

using System.Net;
using System.Text;
using Loonfactory.Google.Apis.YouTube.V3.Tests;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class I18nLanguagesServiceTests
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
            .AddI18nLanguges<I18nLanguagesService, I18nLanguageHandler>();

        using var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<II18nLanguagesService>();

        await service.ListAsync("snippet").ConfigureAwait(true);

        Assert.NotNull(captured);
        var query = QueryHelpers.ParseQuery(captured!.RequestUri!.Query);
        Assert.Equal("snippet", query["part"]);
        Assert.False(query.ContainsKey("parts"));
    }

    private sealed class TestAccessTokenProvider : IAccessTokenProvider
    {
        public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<string?>(null);
    }
}
