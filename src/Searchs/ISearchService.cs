// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Searchs;

public interface ISearchService
{
    Task<SearchListResponse> ListAsync(
        StringValues part,
        SearchListOptions? options = null, 
        CancellationToken cancellationToken = default);

    Task<SearchListResponse> ListForContentOwnerAsync(
        StringValues part,
        string contentOwner,
        SearchListOptions? options = null,
        CancellationToken cancellationToken = default);

    Task<SearchListResponse> ListForDeveloperAsync(
        StringValues part,
        string developer,
        SearchListOptions? options = null,
        CancellationToken cancellationToken = default);

    Task<SearchListResponse> ListForMineAsync(
        StringValues part,
        bool mine,
        SearchListOptions? options = null,
        CancellationToken cancellationToken = default);
}
