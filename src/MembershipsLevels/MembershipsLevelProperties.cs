// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.MembershipsLevels;

public class MembershipsLevelProperties : YouTubeProperties
{
    public static readonly string PartsKey = "part";

    public MembershipsLevelProperties()
    { }

    public MembershipsLevelProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public MembershipsLevelProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues? Parts
    {
        get => GetParameter<string>(PartsKey);
        set => SetParameter(PartsKey, value);
    }
}