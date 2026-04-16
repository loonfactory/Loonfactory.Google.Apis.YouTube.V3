// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3;

public class YouTubeApiRequestError
{
    public int? Code { get; set; }

    public string? Message { get; set; }

    public IEnumerable<YouTubeApiError>? Errors { get; set; }
}
