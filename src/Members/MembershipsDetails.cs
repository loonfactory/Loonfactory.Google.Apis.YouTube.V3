// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Members;

public class MembershipsDetails
{
    public string? HighestAccessibleLevel { get; set; }
    public string? HighestAccessibleLevelDisplayName { get; set; }
    public IEnumerable<string>? AccessibleLevels { get; set; }
    public MembershipsDuration? MembershipsDuration { get; set; }
    public IEnumerable<MembershipsDurationAtLevel>? MembershipsDurationAtLevel { get; set; }
}