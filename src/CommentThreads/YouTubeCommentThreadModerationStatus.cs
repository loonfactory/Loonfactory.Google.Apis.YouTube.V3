// Licensed under the MIT license by loonfactory.

using System.Runtime.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

/// <summary>
/// @TODO
/// </summary>
public enum YouTubeCommentThreadModerationStatus
{
    /// <summary>
    /// @TODO
    /// </summary>
    [EnumMember(Value = "heldForReview")]
    HeldForReview,

    /// <summary>
    /// @TODO
    /// </summary>
    [EnumMember(Value = "likelySpam")]
    LikelySpam,

    /// <summary>
    /// @TODO
    /// </summary>
    [EnumMember(Value = "published")]
    Published
}
