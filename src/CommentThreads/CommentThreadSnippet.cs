// Licensed under the MIT license by loonfactory.

using Loonfactory.Google.Apis.YouTube.V3.Comments;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

/// <summary>
/// The YouTubeCommentThreadSnippetResource contains basic details about the Comment.
/// </summary>
public class CommentThreadSnippet
{
    public string? ChannelId { get; set; }
    public string? VideoId { get; set; }
    public CommentResource? TopLevelComment { get; set; }
    public bool? CanReply { get; set; }
    public uint? TotalReplyCount { get; set; }
    public bool? IsPublic { get; set; }
}