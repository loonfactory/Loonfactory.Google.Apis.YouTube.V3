// Licensed under the MIT license by loonfactory.

using System.ComponentModel.DataAnnotations;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// Describes caption metadata.
/// </summary>
/// <remarks>Nullable members distinguish an absent field from an API default value.</remarks>
/// <seealso href="https://developers.google.com/youtube/v3/docs/captions" />
public class CaptionSnippet
{
    /// <summary>
    /// Gets or sets the associated video identifier.
    /// </summary>
    public string? VideoId { get; set; }

    /// <summary>
    /// Gets or sets the last modification timestamp.
    /// </summary>
    /// <remarks>
    /// The API represents this timestamp in ISO 8601 format.
    /// </remarks>
    public DateTimeOffset? LastUpdated { get; set; }

    /// <summary>
    /// Gets or sets the track category: ASR, forced, or standard.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>ASR</term><description>Speech-recognition captions.</description></item>
    /// <item><term>forced</term><description>Shown when no other track is selected, for example during foreign-language dialogue.</description></item>
    /// <item><term>standard</term><description>Regular captions; the API default.</description></item>
    /// </list>
    /// </remarks>
    public string? TrackKind { get; set; }

    /// <summary>
    /// Gets or sets the BCP-47 language tag.
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// Gets or sets the display name, limited to 150 characters.
    /// </summary>
    /// <remarks>
    /// Shown in the player when choosing a caption track. Tracks sharing a video and language must have distinct names.
    /// </remarks>
    [MaxLength(150)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the audio category: commentary, descriptive, primary, or unknown.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>commentary</term><description>Alternate commentary audio.</description></item>
    /// <item><term>descriptive</term><description>Alternate descriptive audio.</description></item>
    /// <item><term>primary</term><description>The main audio.</description></item>
    /// <item><term>unknown</term><description>Unspecified audio category; the API default.</description></item>
    /// </list>
    /// </remarks>
    public string? AudioTrackType { get; set; }

    /// <summary>
    /// Gets or sets whether accessibility captions are provided.
    /// </summary>
    /// <remarks>
    /// For deaf or hard-of-hearing viewers. The API default is <see langword="false"/>.
    /// </remarks>
    public bool? IsCC { get; set; }

    /// <summary>
    /// Gets or sets whether large text is used.
    /// </summary>
    /// <remarks>
    /// For viewers with impaired vision. The API default is <see langword="false"/>.
    /// </remarks>
    public bool? IsLarge { get; set; }

    /// <summary>
    /// Gets or sets whether simplified reading is used.
    /// </summary>
    /// <remarks>
    /// Uses roughly third-grade reading level for language learners. The API default is <see langword="false"/>.
    /// </remarks>
    public bool? IsEasyReader { get; set; }

    /// <summary>
    /// Gets or sets whether the track is unpublished.
    /// </summary>
    /// <remarks>
    /// Draft tracks are not publicly visible. The API default is <see langword="false"/>.
    /// </remarks>
    public bool? IsDraft { get; set; }

    /// <summary>
    /// Gets or sets whether YouTube generated timing automatically.
    /// </summary>
    /// <remarks>
    /// <para>When false, timing comes from the uploaded file; when true, YouTube synchronized it with the audio.</para>
    /// <para>The <c>sync</c> request parameter was deprecated on March 13, 2024. Auto-sync remains available in Creator Studio.</para>
    /// </remarks>
    public bool? IsAutoSynced { get; set; }

    /// <summary>
    /// Gets or sets the processing state: failed, serving, or syncing.
    /// </summary>
    /// <remarks>
    /// Values are <c>failed</c>, <c>serving</c>, and <c>syncing</c>.
    /// </remarks>
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets the processing failure code.
    /// </summary>
    /// <remarks>
    /// Only returned when <see cref="Status"/> is <c>failed</c>.
    /// <list type="bullet">
    /// <item><term>processingFailed</term><description>Processing failed.</description></item>
    /// <item><term>unknownFormat</term><description>Unrecognized format.</description></item>
    /// <item><term>unsupportedFormat</term><description>Unsupported format.</description></item>
    /// </list>
    /// </remarks>
    public string? FailureReason { get; set; }
}
