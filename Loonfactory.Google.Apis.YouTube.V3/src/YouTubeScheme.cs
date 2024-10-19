// Licensed under the MIT license by loonfactory.

using System.Diagnostics.CodeAnalysis;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// YouTubeSchemes assign a name to a specific <see cref="IYouTubeHandler"/>
/// handlerType.
/// </summary>
public class YouTubeScheme
{
    /// <summary>
    /// Initializes a new instance of <see cref="YouTubeScheme"/>.
    /// </summary>
    /// <param name="name">The name for the YouTube scheme.</param>
    /// <param name="displayName">The display name for the YouTUbe scheme.</param>
    /// <param name="handlerType">The <see cref="IYouTubeHandler"/> type that handles this scheme.</param>
    public YouTubeScheme(string name, string? displayName, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (!typeof(IYouTubeHandler).IsAssignableFrom(handlerType))
        {
            throw new ArgumentException("handlerType must implement IYouTubeHandler.");
        }

        Name = name;
        HandlerType = handlerType;
        DisplayName = displayName;
    }

    /// <summary>
    /// The name of the authentication scheme.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The display name for the scheme. Null is valid and used for non user facing schemes.
    /// </summary>
    public string? DisplayName { get; }

    /// <summary>
    /// The <see cref="IYouTubeHandler"/> type that handles this scheme.
    /// </summary>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    public Type HandlerType { get; }
}