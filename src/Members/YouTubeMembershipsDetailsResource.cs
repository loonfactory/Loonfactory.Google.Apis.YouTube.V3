// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class YouTubeMembershipsDetailsResource
{
    public string? HighestAccessibleLevel { get; set; }
    public string? HighestAccessibleLevelDisplayName { get; set; }
    public IEnumerable<string>? AccessibleLevels { get; set; }
    public YouTubeMembershipsDurationResource? MembershipsDuration { get; set; }
    public IEnumerable<YouTubeMembershipsDurationAtLevelResource>? MembershipsDurationAtLevel { get; set; }
}