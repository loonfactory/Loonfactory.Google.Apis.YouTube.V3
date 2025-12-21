// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

/// <summary>
/// The ChannelSectionContentDetails contains basic details about the ChannelSection.
/// </summary>
public class ChannelSectionContentDetails
{
    public IEnumerable<string>? PlayLists { get; set; }
    public IEnumerable<string>? Channels { get; set; }
}