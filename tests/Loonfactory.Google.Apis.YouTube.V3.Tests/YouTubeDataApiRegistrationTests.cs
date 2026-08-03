// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.ChannelSections;
using Loonfactory.Google.Apis.YouTube.V3.PlaylistImages;
using Loonfactory.Google.Apis.YouTube.V3.PlaylistItems;
using Microsoft.Extensions.DependencyInjection;

namespace Loonfactory.Google.Apis.YouTube.V3;

public class YouTubeDataApiRegistrationTests
{
    [Fact]
    public void AddYouTubeDataApi_RegistersPlaylistItemsAndPlaylistImages()
    {
        var services = new ServiceCollection();

        services.AddLogging();
        services.AddAuthentication();
        services.AddYouTubeDataApi();

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        Assert.IsType<PlaylistItemsService>(
            scope.ServiceProvider.GetRequiredService<IPlaylistItemsService>());
        Assert.IsType<PlaylistImagesService>(
            scope.ServiceProvider.GetRequiredService<IPlaylistImagesService>());
        Assert.IsType<ChannelSectionsService>(
            scope.ServiceProvider.GetRequiredService<IChannelSections>());
        Assert.IsType<PlaylistItemHandler>(
            scope.ServiceProvider.GetRequiredService<PlaylistItemHandler>());
        Assert.IsType<PlaylistImageHandler>(
            scope.ServiceProvider.GetRequiredService<PlaylistImageHandler>());
    }

    [Fact]
    public void AddPlaylistImages_RegistersServiceAndHandler()
    {
        var services = new ServiceCollection();

        services.AddLogging();
        services.AddYouTubeDataApiCore()
            .AddAccessTokenProvider<TestAccessTokenProvider>()
            .AddPlaylistImages<PlaylistImagesService, PlaylistImageHandler>();

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        Assert.IsType<PlaylistImagesService>(
            scope.ServiceProvider.GetRequiredService<IPlaylistImagesService>());
        Assert.IsType<PlaylistImageHandler>(
            scope.ServiceProvider.GetRequiredService<PlaylistImageHandler>());
    }

    private sealed class TestAccessTokenProvider : IAccessTokenProvider
    {
        public Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
            => Task.FromResult<string?>(null);
    }
}
