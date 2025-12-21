// Licensed under the MIT license by loonfactory.

using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class MemberHandler(IOptionsMonitor<YouTubeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : YouTubeHandler(options, logger, encoder), IMemberHandler
{
    public virtual async Task<YouTubeResult<MemberListResponse>> HandleMemberListAsync(MemberProperties properties, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(properties);

        if ((properties.Parts?.Count ?? 0) == 0)
        {
            throw new InvalidOperationException("@TODO");
        }

        var response = await AuthorizationSendAsync(
            HttpMethod.Get,
            MemberDefaults.ListEndpoint,
            properties,
            cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new NotImplementedException("Handling of unsuccessful HTTP responses is not yet implemented.");
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return YouTubeResult<MemberListResponse>.Success(
            JsonSerializer.Deserialize<MemberListResponse>(body, YouTubeDefaults.JsonSerializerOptions)!
        );
    }
}