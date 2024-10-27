// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Defines a mechanism for retrieving access tokens required for authenticating with external services.
/// </summary>
public interface IAccessTokenProvider
{
    /// <summary>
    /// Asynchronously retrieves an access token.
    /// </summary>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation, with the access token as the result.
    /// Returns <c>null</c> if the token cannot be retrieved.
    /// </returns>
    Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}