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

    [Fact]
    public async Task GetHandlerAsync_ConcurrentCalls_SharesOneInitializationTask()
    {
        var services = new ServiceCollection();
        var initializationGate = new HandlerInitializationGate();

        services.AddYouTubeDataApiCore();
        services.AddSingleton(initializationGate);

        using var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        var handlerProvider = scope.ServiceProvider.GetRequiredService<IYouTubeHandlerProvider>();

        var first = handlerProvider.GetHandlerAsync<DelayedHandler>();
        await initializationGate.Started.Task.WaitAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(true);

        var second = handlerProvider.GetHandlerAsync<DelayedHandler>();

        Assert.Equal(1, initializationGate.Count);

        initializationGate.Continue.SetResult();
        var handlers = await Task.WhenAll(first, second).ConfigureAwait(true);

        Assert.Same(handlers[0], handlers[1]);
        Assert.Equal(1, initializationGate.Count);
    }

    [Fact]
    public async Task GetHandlerAsync_InitializationFails_CachesTheFailedTaskForTheScope()
    {
        var services = new ServiceCollection();
        var initialization = new FailingHandlerInitialization();

        services.AddYouTubeDataApiCore();
        services.AddSingleton(initialization);

        using var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        var handlerProvider = scope.ServiceProvider.GetRequiredService<IYouTubeHandlerProvider>();

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => handlerProvider.GetHandlerAsync<FailingHandler>()).ConfigureAwait(true);
        await Assert.ThrowsAsync<InvalidOperationException>(
            () => handlerProvider.GetHandlerAsync<FailingHandler>()).ConfigureAwait(true);

        Assert.Equal(1, initialization.Count);
    }

    private sealed class HandlerInitializationGate
    {
        public TaskCompletionSource Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource Continue { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int Count;
    }

    private sealed class DelayedHandler(HandlerInitializationGate initializationGate) : IYouTubeHandler
    {
        public async Task InitializeAsync()
        {
            Interlocked.Increment(ref initializationGate.Count);
            initializationGate.Started.SetResult();
            await initializationGate.Continue.Task.ConfigureAwait(false);
        }
    }

    private sealed class FailingHandlerInitialization
    {
        public int Count;
    }

    private sealed class FailingHandler(FailingHandlerInitialization initialization) : IYouTubeHandler
    {
        public Task InitializeAsync()
        {
            Interlocked.Increment(ref initialization.Count);
            throw new InvalidOperationException("Handler initialization failed.");
        }
    }
}
