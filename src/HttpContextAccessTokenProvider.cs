// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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
        var authResult = await context.AuthenticateAsync().ConfigureAwait(false);
        if (authResult != null)
        {
            return authResult.Properties?.GetTokenValue("access_token");
        }

        return null;
    }
}