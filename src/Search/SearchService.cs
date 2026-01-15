// Licensed under the MIT license by loonfactory.
using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Search;

public class SearchService(
    IAccessTokenProvider accessTokenProvider,
    IYouTubeHandlerProvider handlers
) : ISearchService
{
    public IYouTubeHandlerProvider Handlers { get; } = handlers;
    public IAccessTokenProvider AccessTokenProvider { get; } = accessTokenProvider;

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

        if (properties.ForMine == true)
        {
            var token = await AccessTokenProvider.GetAccessTokenAsync(cancellationToken).ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(token))
            {
                // @TODO: Replace InvalidOperationException with a YouTubeApiException aligned with the API's 403/401 error model.
                throw new InvalidOperationException("@TODO");
            }

            properties.AccessToken = token;
        }

        var result = await handler.HandleSearchListAsync(properties, cancellationToken).ConfigureAwait(false);
        return result.Succeeded switch
        {
            true => result.Resource,
            false => throw new NotImplementedException("@TODO")
        };
    }
}
