// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.DependencyInjection;

namespace Loonfactory.Google.Apis.YouTube.V3;

public class YouTubeCoreErrorModuleTests
{
    [Fact]
    public void AddYouTubeDataApiCore_RegistersHandlerProvider()
    {
        var services = new ServiceCollection();

        services.AddYouTubeDataApiCore();

        using var provider = services.BuildServiceProvider();
        var handlerProvider = provider.GetService<IYouTubeHandlerProvider>();

        Assert.NotNull(handlerProvider);
    }

    [Fact]
    public void YouTubeResultFailString_UsesYouTubeApiException()
    {
        var result = YouTubeResult<object>.Fail("test-failure");

        Assert.NotNull(result.Failure);
        Assert.IsType<YouTubeApiException>(result.Failure);
    }
}
