// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

/// <summary>
/// @TODO
/// </summary>
public class CommentResource
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

    public CommentSnippet? Snippet { get; set; }
}