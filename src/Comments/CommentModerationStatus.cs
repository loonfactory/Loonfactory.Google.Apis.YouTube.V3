// Licensed under the MIT license by loonfactory.

using System.Runtime.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

/// <summary>
/// Represents the review status of a YouTube comment.
/// </summary>
public enum CommentModerationStatus
{
    /// <summary>
    /// Indicates the comment is held for review by the moderator.
    /// </summary>
    [EnumMember(Value = "heldForReview")]
    HeldForReview,

    /// <summary>
    /// Indicates the comment is published and visible to the public.
    /// </summary>
    [EnumMember(Value = "published")]
    Published,

    /// <summary>
    /// Indicates the comment is rejected as inappropriate and hidden along with all its replies.
    /// </summary>
    [EnumMember(Value = "rejected")]
    Rejected
}
