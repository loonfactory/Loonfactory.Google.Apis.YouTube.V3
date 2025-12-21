// Licensed under the MIT license by loonfactory.

using System.ComponentModel.DataAnnotations;

namespace Loonfactory.Google.Apis.YouTube.V3.Captions;

/// <summary>
/// The CaptionSnippet contains basic details about the caption.
/// </summary>
public class CaptionSnippet
{
    /// <summary>
    /// The ID that YouTube uses to uniquely identify the video associated with the caption track.
    /// </summary>
    public string? VideoId { get; set; }

    /// <summary>
    /// The date and time when the caption track was last updated. The value is specified in ISO 8601 format.
    /// </summary>
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// The caption track's type. 
    /// <para>
    /// Valid values for this property are:
    /// </para>
    /// <para>
    /// <strong>ASR</strong> – A caption track generated using automatic speech recognition. 
    /// </para>
    /// <para>
    /// <strong>forced</strong> – A caption track that plays when no other track is selected in the player. 
    /// For example, a video that shows aliens speaking in an alien language might have a forced caption track 
    /// to only show subtitles for the alien language. 
    /// </para>
    /// <para>
    /// <strong>standard</strong> – A regular caption track. This is the default value.
    /// </para>
    /// </summary>
    public string? TrackKind { get; set; }

    /// <summary>
    /// The language of the caption track. The property value is a BCP-47 language tag.
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// The name of the caption track. The name is intended to be visible to the user as an option during playback. The maximum name length supported is 150 characters.
    /// </summary>
    [MaxLength(150)]
    public string? Name { get; set; }

    /// <summary>
    /// The type of audio track associated with the caption track.
    /// <para>
    /// Valid values for this property are:
    /// </para>
    /// <para>
    /// <strong>commentary</strong> – The caption track corresponds to an alternate audio track that includes commentary, 
    /// such as director commentary.
    /// </para>
    /// <para>
    /// <strong>descriptive</strong> – The caption track corresponds to an alternate audio track that includes additional descriptive audio.
    /// </para>
    /// <para>
    /// <strong>primary</strong> – The caption track corresponds to the primary audio track for the video, which is the audio track normally associated with the video.
    /// </para>
    /// <para>
    /// <strong>unknown</strong> – This is the default value.
    /// </para>
    /// </summary>
    public string? AudioTrackType { get; set; }

    /// <summary>
    /// Indicates whether the track contains closed captions for the deaf and hard of hearing. The default value is false.
    /// </summary>
    public bool? IsCC { get; set; }

    /// <summary>
    /// Indicates whether the caption track uses large text for the vision-impaired. 
    /// The default value is <c>false</c>.
    /// </summary>
    public bool? IsLarge { get; set; }

    /// <summary>
    /// Indicates whether caption track is formatted for "easy reader," meaning it is at a third-grade level for language learners.
    /// The default value is <c>false</c>.
    /// </summary>
    public bool? IsEasyReader { get; set; }

    /// <summary>
    /// Indicates whether the caption track is a draft. If the value is true, then the track is not publicly visible.
    /// The default value is <c>false</c>.
    /// </summary>
    public bool? IsDraft { get; set; }

    /// <summary>
    /// Indicates whether YouTube synchronized the caption track to the audio track in the video.
    /// The value will be true if a sync was explicitly requested when the caption track was uploaded.
    /// For example, when calling the captions.insert or captions.update methods,
    /// you can set the sync parameter to true to instruct YouTube to sync the uploaded track to the video.
    /// If the value is false, YouTube uses the time codes in the uploaded caption track to determine when to display captions.
    /// </summary>
    public bool? IsAutoSynced { get; set; }

    /// <summary>
    /// The caption track's status.
    /// <para>
    /// Valid values for this property are:
    /// </para>
    /// <para>
    /// <strong>failed</strong> – The caption track has failed to process or serve.
    /// </para>
    /// <para>
    /// <strong>serving</strong> – The caption track is currently available and serving.
    /// </para>
    /// <para>
    /// <strong>syncing</strong> – The caption track is in the process of being synced.
    /// </para>
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// The reason that YouTube failed to process the caption track. 
    /// This property is only present if the state property's value is <c>failed</c>.
    /// <para>
    /// Valid values for this property are:
    /// </para>
    /// <para>
    /// <strong>processingFailed</strong> – YouTube failed to process the uploaded caption track.
    /// </para>
    /// <para>
    /// <strong>unknownFormat</strong> – The caption track's format was not recognized.
    /// </para>
    /// <para>
    /// <strong>unsupportedFormat</strong> – The caption track's format is not supported.
    /// </para>
    /// </summary>
    public string? FailureReason { get; set; }
}