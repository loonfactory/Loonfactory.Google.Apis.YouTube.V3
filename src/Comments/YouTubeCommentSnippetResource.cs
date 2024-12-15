// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

/// <summary>
/// The YouTubeCommentSnippetResource contains basic details about the Comment.
/// </summary>
public class YouTubeCommentSnippetResource
{
    public string? AuthorDisplayName { get; set; }
    public string? AuthorProfileImageUrl { get; set; }
    public string? AuthorChannelUrl { get; set; }
    public YouTubeCommentAuthorChannelIdResource? AuthorChannelId { get; set; }
    public string? ChannelId { get; set; }
    public string? TextDisplay { get; set; }
    public string? TextOriginal { get; set; }
    public string? ParentId { get; set; }
    public bool? CanRate { get; set; }
    public string? ViewerRating { get; set; }
    public uint? LikeCount { get; set; }
    public string? ModerationStatus { get; set; }
    public DateTime? PublishedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}