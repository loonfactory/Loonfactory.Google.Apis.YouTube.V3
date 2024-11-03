// Licensed under the MIT license by loonfactory.

using System.Diagnostics.CodeAnalysis;

namespace Loonfactory.Google.Apis.YouTube.V3;

/// <summary>
/// Contains the result of an Authenticate call
/// </summary>
public class YouTubeResult<T> where T : class
{
    private static readonly YouTubeResult<T> _noResult = new() { None = true };

    protected YouTubeResult() { }
    protected YouTubeResult(T resource)
    {
        Resource = resource;
    }

    [MemberNotNullWhen(true, nameof(Resource))]
    public bool Succeeded => Failure == null;

    /// <summary>
    /// The authentication ticket.
    /// </summary>
    public T? Resource { get; protected set; }

    public YouTubeProperties? Properties { get; protected set; }

    /// <summary>
    /// Holds failure information from the authentication.
    /// </summary>
    public Exception? Failure { get; protected set; }

    /// <summary>
    /// Indicates that there was no information returned for this authentication scheme.
    /// </summary>
    public bool None { get; protected set; }

    public static YouTubeResult<T> Success(T resource)
    {
        ArgumentNullException.ThrowIfNull(resource);
        return new YouTubeResult<T>(resource);
    }

    /// <summary>
    /// Indicates that there was no information returned for this authentication scheme.
    /// </summary>
    /// <returns>The result.</returns>
    public static YouTubeResult<T> NoResult()
    {
        return _noResult;
    }

    /// <summary>
    /// Indicates that there was a failure during authentication.
    /// </summary>
    /// <param name="failure">The failure exception.</param>
    /// <returns>The result.</returns>
    public static YouTubeResult<T> Fail(Exception failure)
    {
        return new YouTubeResult<T>() { Failure = failure };
    }

    /// <summary>
    /// Indicates that there was a failure during authentication.
    /// </summary>
    /// <param name="failure">The failure exception.</param>
    /// <param name="properties">Additional state values for the authentication session.</param>
    /// <returns>The result.</returns>
    public static YouTubeResult<T> Fail(Exception failure, YouTubeProperties? properties)
    {
        return new YouTubeResult<T>() { Failure = failure, Properties = properties };
    }

    /// <summary>
    /// Indicates that there was a failure during authentication.
    /// </summary>
    /// <param name="failureMessage">The failure message.</param>
    /// <returns>The result.</returns>
    public static YouTubeResult<T> Fail(string failureMessage)
        => Fail(new YouTubeRequestFailureException(failureMessage));

    /// <summary>
    /// Indicates that there was a failure during authentication.
    /// </summary>
    /// <param name="failureMessage">The failure message.</param>
    /// <param name="properties">Additional state values for the authentication session.</param>
    /// <returns>The result.</returns>
    public static YouTubeResult<T> Fail(string failureMessage, YouTubeProperties? properties)
        => Fail(new YouTubeRequestFailureException(failureMessage), properties);
}

public class YouTubeResult : YouTubeResult<object>
{
    private static readonly YouTubeResult _noResult = new() { None = true };
    public static new YouTubeResult NoResult => _noResult;
}