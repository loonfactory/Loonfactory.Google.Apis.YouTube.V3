// Licensed under the MIT license by loonfactory.

using System.ComponentModel.DataAnnotations;

namespace Loonfactory.Google.Apis.YouTube.V3.ChannelSections;

/// <summary>
/// The YouTubeChannelSectionResourceSnippet contains basic details about the ChannelSection.
/// </summary>
public class YouTubeChannelSectionContentDetailsResource
{
    public IEnumerable<string>? PlayLists { get; set; }
    public IEnumerable<string>? Channels { get; set; }
}