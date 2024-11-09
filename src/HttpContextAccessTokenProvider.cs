// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;

namespace Loonfactory.Google.Apis.YouTube.V3;

public class HttpContextAccessTokenProvider(
    IAuthenticationSchemeProvider schemeProvider,
    IHttpContextAccessor httpContextAccessor
) : IAccessTokenProvider
{
    public IAuthenticationSchemeProvider SchemeProvider { get; } = schemeProvider;

    public IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;

    public virtual Task<AuthenticationScheme?> GetGoogleSchemeAsync() => SchemeProvider.GetSchemeAsync(GoogleDefaults.AuthenticationScheme);
    public async Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        var context = HttpContextAccessor.HttpContext ?? throw new InvalidOperationException("@TODO");
        var googleScheme = await GetGoogleSchemeAsync().ConfigureAwait(false);

        if (googleScheme != null)
        {
            var authenticateResult = await context.AuthenticateAsync(googleScheme.Name).ConfigureAwait(false);

            if (authenticateResult.Succeeded)
            {
                var accessToken = authenticateResult.Properties.GetTokenValue("access_token");
                return accessToken;
            }
        }

        return null;
    }
}