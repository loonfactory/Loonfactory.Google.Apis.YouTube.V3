// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class MembershipsDurationAtLevel
{
    public string? Level { get; set; }
    public DateTimeOffset? MemberSince { get; set; }
    public int? MemberTotalDurationMonths { get; set; }
}