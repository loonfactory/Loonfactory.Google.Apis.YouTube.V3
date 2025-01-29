// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public class YouTubeMembershipsLevelProperties : YouTubeProperties
{
    public static readonly string PartsKey = "part";

    public YouTubeMembershipsLevelProperties()
    { }

    public YouTubeMembershipsLevelProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public YouTubeMembershipsLevelProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues? Parts
    {
        get => GetParameter<string>(PartsKey);
        set => SetParameter(PartsKey, value);
    }
}