// Licensed under the MIT license by loonfactory.

using System.Globalization;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.HttpOverrides;

namespace Loonfactory.Google.Apis.YouTube.V3.Example;

internal static class HandleRequestResults
{
    internal static HandleRequestResult InvalidState = HandleRequestResult.Fail("The oauth state was missing or invalid.");
}

/// <summary>
/// Initializes a new instance of <see cref="OAuthHandler{TOptions}"/>.
/// </summary>
/// <inheritdoc />
public class TemporaryOAuthHandler<TOptions>(IOptionsMonitor<TOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : OAuthHandler<TOptions>(options, logger, encoder) where TOptions : OAuthOptions, new()
{
    protected new string BuildRedirectUri(string targetPath)
    {
        // Since the forward propagation in OAuthHandler is not performed properly,
        // it is temporarily bypassed.
        //
        // When it is normalized in the future, the logic should be removed.
        var options = Context.RequestServices.GetRequiredService<IOptions<ForwardedHeadersOptions>>();
        var forwarded = new ForwardedHeadersMiddleware(context => Task.CompletedTask, Context.RequestServices.GetRequiredService<ILoggerFactory>(), options);
        forwarded.ApplyForwarders(Context);

        return Request.Scheme + Uri.SchemeDelimiter + Request.Host + OriginalPathBase + targetPath;
    }

    /// <inheritdoc />
    protected override async Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
    {
        var query = Request.Query;

        var state = query["state"];
        var properties = Options.StateDataFormat.Unprotect(state);

        if (properties == null)
        {
            return HandleRequestResults.InvalidState;
        }

        // OAuth2 10.12 CSRF
        if (!ValidateCorrelationId(properties))
        {
            return HandleRequestResult.Fail("Correlation failed.", properties);
        }

        var error = query["error"];
        if (!StringValues.IsNullOrEmpty(error))
        {
            // Note: access_denied errors are special protocol errors indicating the user didn't
            // approve the authorization demand requested by the remote authorization server.
            // Since it's a frequent scenario (that is not caused by incorrect configuration),
            // denied errors are handled differently using HandleAccessDeniedErrorAsync().
            // Visit https://tools.ietf.org/html/rfc6749#section-4.1.2.1 for more information.
            var errorDescription = query["error_description"];
            var errorUri = query["error_uri"];
            if (StringValues.Equals(error, "access_denied"))
            {
                var result = await HandleAccessDeniedErrorAsync(properties);
                if (!result.None)
                {
                    return result;
                }
                var deniedEx = new AuthenticationFailureException("Access was denied by the resource owner or by the remote server.");
                deniedEx.Data["error"] = error.ToString();
                deniedEx.Data["error_description"] = errorDescription.ToString();
                deniedEx.Data["error_uri"] = errorUri.ToString();

                return HandleRequestResult.Fail(deniedEx, properties);
            }

            var failureMessage = new StringBuilder();
            failureMessage.Append(error);
            if (!StringValues.IsNullOrEmpty(errorDescription))
            {
                failureMessage.Append(";Description=").Append(errorDescription);
            }
            if (!StringValues.IsNullOrEmpty(errorUri))
            {
                failureMessage.Append(";Uri=").Append(errorUri);
            }

            var ex = new AuthenticationFailureException(failureMessage.ToString());
            ex.Data["error"] = error.ToString();
            ex.Data["error_description"] = errorDescription.ToString();
            ex.Data["error_uri"] = errorUri.ToString();

            return HandleRequestResult.Fail(ex, properties);
        }

        var code = query["code"];

        if (StringValues.IsNullOrEmpty(code))
        {
            return HandleRequestResult.Fail("Code was not found.", properties);
        }

        var codeExchangeContext = new OAuthCodeExchangeContext(properties, code.ToString(), BuildRedirectUri(Options.CallbackPath));
        using var tokens = await ExchangeCodeAsync(codeExchangeContext);

        if (tokens.Error != null)
        {
            return HandleRequestResult.Fail(tokens.Error, properties);
        }

        if (string.IsNullOrEmpty(tokens.AccessToken))
        {
            return HandleRequestResult.Fail("Failed to retrieve access token.", properties);
        }

        var identity = new ClaimsIdentity(ClaimsIssuer);

        if (Options.SaveTokens)
        {
            var authTokens = new List<AuthenticationToken>();

            authTokens.Add(new AuthenticationToken { Name = "access_token", Value = tokens.AccessToken });
            if (!string.IsNullOrEmpty(tokens.RefreshToken))
            {
                authTokens.Add(new AuthenticationToken { Name = "refresh_token", Value = tokens.RefreshToken });
            }

            if (!string.IsNullOrEmpty(tokens.TokenType))
            {
                authTokens.Add(new AuthenticationToken { Name = "token_type", Value = tokens.TokenType });
            }

            if (!string.IsNullOrEmpty(tokens.ExpiresIn))
            {
                int value;
                if (int.TryParse(tokens.ExpiresIn, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
                {
                    // https://www.w3.org/TR/xmlschema-2/#dateTime
                    // https://learn.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings
                    var expiresAt = TimeProvider.GetUtcNow() + TimeSpan.FromSeconds(value);
                    authTokens.Add(new AuthenticationToken
                    {
                        Name = "expires_at",
                        Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                    });
                }
            }

            properties.StoreTokens(authTokens);
        }

        var ticket = await CreateTicketAsync(identity, properties, tokens);
        if (ticket != null)
        {
            return HandleRequestResult.Success(ticket);
        }
        else
        {
            return HandleRequestResult.Fail("Failed to retrieve user information from remote server.", properties);
        }
    }
}
