// Licensed under the MIT license by loonfactory.

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public static class CommentDefaults
{
    private const string ApiRootUrl = "https://www.googleapis.com/youtube/v3";
    public static readonly string ListEndpoint = $"{ApiRootUrl}/comments";

    public static readonly string InsertEndpoint = $"{ApiRootUrl}/comments";

    public static readonly string UpdateEndpoint = $"{ApiRootUrl}/comments";
    public static readonly string DeleteEndpoint = $"{ApiRootUrl}/comments";

    public static readonly string SetModerationStatusEndpoint = $"{ApiRootUrl}/comments/setModerationStatus";
}