// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Tests;

public class TestHttpMessageHandler : HttpMessageHandler
{
    public Func<HttpRequestMessage, HttpResponseMessage?>? Sender { get; set; }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (Sender != null)
        {
            return Task.FromResult(Sender(request));
        }

        return Task.FromResult<HttpResponseMessage>(null);
    }
}