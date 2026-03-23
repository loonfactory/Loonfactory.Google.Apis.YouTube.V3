// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Tests;

public class TestHttpMessageHandler : HttpMessageHandler
{
    private Func<HttpRequestMessage, HttpResponseMessage?>? _sender;
    private Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage?>>? _senderAsync;

    public Func<HttpRequestMessage, HttpResponseMessage?>? Sender
    {
        get => _sender;
        set
        {
            _sender = value;
            if (value != null)
            {
                _senderAsync = null;
            }
        }
    }

    public Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage?>>? SenderAsync
    {
        get => _senderAsync;
        set
        {
            _senderAsync = value;
            if (value != null)
            {
                _sender = null;
            }
        }
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (_senderAsync != null)
        {
            var response = await _senderAsync(request, cancellationToken).ConfigureAwait(false);
            return response ?? new HttpResponseMessage();
        }

        if (_sender != null)
        {
            var response = _sender(request);
            return response ?? new HttpResponseMessage();
        }

        return new HttpResponseMessage();
    }
}
