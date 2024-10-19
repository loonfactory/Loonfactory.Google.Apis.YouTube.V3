// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Contains the options used by the <see cref="YouTubeHandler{T}"/>.
/// </summary>
public class YouTubeHandler<T>
{
    public async void A() {
        var clinet = new HttpClient();
        var result = await clinet.GetAsync("http://test").ConfigureAwait(false);
        result.Content.ReadAsStreamAsync();
    }
}
