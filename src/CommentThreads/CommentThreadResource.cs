// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.CommentThreads;

/// <summary>
/// @TODO
/// </summary>
public class CommentThreadResource
{
    /// <summary>
    /// @TODO
    /// </summary>
    public string? Kind { get; set; }

    /// <summary>
    /// The Etag of this resource.
    /// </summary>
    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? Id { get; set; }

    public CommentThreadSnippet? Snippet { get; set; }
    public CommentThreadReplie? Replies { get; set; }
}