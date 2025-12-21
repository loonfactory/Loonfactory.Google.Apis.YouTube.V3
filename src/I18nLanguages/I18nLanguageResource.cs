// Licensed under the MIT license by loonfactory.

using System.Text.Json.Serialization;

namespace Loonfactory.Google.Apis.YouTube.V3.I18nLanguages;

public class I18nLanguageResource
{
    public string? Kind { get; set; }

    [JsonPropertyName("etag")]
    public string? ETag { get; set; }

    public string? Id { get; set; }

    public I18nLanguageSnippet? Snippet { get; set; }
}