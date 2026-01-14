// Licensed under the MIT license by loonfactory.
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Searchs;

public class SearchService(
    IYouTubeHandlerProvider handlers
) : ISearchService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;

    public Task<SearchListResponse> ListAsync(
        StringValues part,
        SearchListOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        options = options != null ? new SearchListOptions(options) : new SearchListOptions();

        return InternalListAsync(
            part,
            options,
            cancellationToken);
    }

    public Task<SearchListResponse> ListForContentOwnerAsync(
       StringValues part,
       string contentOwner,
       SearchListOptions? options = null,
       CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        ArgumentNullException.ThrowIfNull(contentOwner);

        options = options != null ? new SearchListOptions(options) : new SearchListOptions();
        options.ForContentOwner = contentOwner;

        return InternalListAsync(
            part,
            options,
            cancellationToken);

    }

    public Task<SearchListResponse> ListForDeveloperAsync(
        StringValues part,
        string developer,
        SearchListOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }
        ArgumentNullException.ThrowIfNull(developer);

        options = options != null ? new SearchListOptions(options) : new SearchListOptions();
        options.ForDeveloper = developer;

        return InternalListAsync(
            part,
            options,
            cancellationToken);
    }

    public Task<SearchListResponse> ListForMineAsync(
       StringValues part,
       bool mine,
       SearchListOptions? options = null,
       CancellationToken cancellationToken = default)
    {
        if (StringValues.IsNullOrEmpty(part))
        {
            throw new ArgumentException("part must be provided.", nameof(part));
        }

        options = options != null ? new SearchListOptions(options) : new SearchListOptions();
        options.ForMine = mine;

        return InternalListAsync(
            part,
            options,
            cancellationToken);
    }

    private async Task<SearchListResponse> InternalListAsync(
        StringValues part,
        SearchListOptions options,
        CancellationToken cancellationToken)
    {
        var handler = await Handlers.GetHandlerAsync<SearchHandler>()
                                 .ConfigureAwait(false) ?? throw new InvalidOperationException("SearchHandler could not be obtained.");

        var properties = options.ToSearchProperties();
        properties.Part = part;

        var result = await handler.HandleSearchListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }
}
