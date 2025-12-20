// Licensed under the MIT license by loonfactory.

using Microsoft.Extensions.Primitives;

namespace Loonfactory.Google.Apis.YouTube.V3.Comments;

public class CommentProperties : YouTubeProperties
{
    public static readonly string PartKey = "part";
    public static readonly string IdKey = "id";
    public static readonly string ParentIdKey = "parentId";
    public static readonly string MaxResultsKey = "maxResults";
    public static readonly string PageTokenKey = "pageToken";
    public static readonly string TextFormatKey = "textFormat";
    public static readonly string ModerationStatusKey = "moderationStatus";
    public static readonly string BanAuthorKey = "banAuthor";

    public CommentProperties()
    { }

    public CommentProperties(IDictionary<string, string?> items)
        : base(items)
    { }

    public CommentProperties(IDictionary<string, string?> items, IDictionary<string, object?> parameters)
        : base(items, parameters)
    { }

    public StringValues Part
    {
        get => GetParameter<StringValues>(PartKey);
        set => SetParameter(PartKey, value);
    }
    public string? Id
    {
        get => GetParameter<string>(IdKey);
        set => SetParameter(IdKey, value);
    }

    public string? ParentId
    {
        get => GetParameter<string>(ParentIdKey);
        set => SetParameter(ParentIdKey, value);
    }

    public uint? MaxResults
    {
        get => GetParameter<uint>(MaxResultsKey);
        set => SetParameter(MaxResultsKey, value);
    }

    public string? PageToken
    {
        get => GetParameter<string>(PageTokenKey);
        set => SetParameter(PageTokenKey, value);
    }

    public string? TextFormat
    {
        get => GetParameter<string>(TextFormatKey);
        set => SetParameter(TextFormatKey, value);
    }

    public CommentModerationStatus? ModerationStatus
    {
        get => GetParameter<CommentModerationStatus>(ModerationStatusKey);
        set => SetParameter(ModerationStatusKey, value);
    }

    public bool? BanAuthor
    {
        get => GetParameter<bool>(BanAuthorKey);
        set => SetParameter(BanAuthorKey, value);
    }
}