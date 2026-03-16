// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Tests;

public class TestHttpMessageHandler : HttpMessageHandler
{
    public Func<HttpRequestMessage, HttpResponseMessage?>? Sender { get; set; }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (Sender != null)
        {
            var response = Sender(request);
            return Task.FromResult(response ?? new HttpResponseMessage());
        }

        return Task.FromResult(new HttpResponseMessage());
    }
}
