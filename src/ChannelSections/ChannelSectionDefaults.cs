// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

public static class ChannelSectionDefaults
{
    private const string ApiRootUrl = "https://www.googleapis.com/youtube/v3";
    /// <summary>
    /// Endpoint URL for listing ChannelSections.
    /// </summary>
    public static readonly string ListEndpoint = $"{ApiRootUrl}/channelSections";

    /// <summary>
    /// Endpoint URL for inserting new ChannelSections.
    /// </summary>
    public static readonly string InsertEndpoint = $"{ApiRootUrl}/channelSections";

    /// <summary>
    /// Endpoint URL for updating existing ChannelSections.
    /// </summary>
    public static readonly string UpdateEndpoint = $"{ApiRootUrl}/channelSections";

    /// <summary>
    /// Endpoint URL for deleting ChannelSections.
    /// </summary>
    public static readonly string DeleteEndpoint = $"{ApiRootUrl}/channelSections";
}