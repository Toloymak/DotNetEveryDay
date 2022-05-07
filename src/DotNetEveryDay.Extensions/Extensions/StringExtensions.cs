using System.Globalization;
using System.Runtime.CompilerServices;

namespace DotNetEveryDay.Extensions.Extensions;

public static class StringExtensions
{
    /// <inheritdoc cref="string.IsNullOrEmpty"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string? sourceString)
        => string.IsNullOrEmpty(sourceString);

    /// <inheritdoc cref="string.IsNullOrWhiteSpace"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace(this string? sourceString)
        => string.IsNullOrWhiteSpace(sourceString);

    /// <inheritdoc cref="TextInfo.ToTitleCase"/>
    /// <param name="sourceString"></param>
    /// <param name="cultureInfo">Culture info, CurrentCulture by default</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToTitleCase(this string? sourceString, CultureInfo? cultureInfo = null)
        => sourceString.IsNullOrWhiteSpace()
            ? sourceString
            : (cultureInfo ?? CultureInfo.CurrentCulture).TextInfo.ToTitleCase(sourceString!);

    /// <summary>
    /// Convert text to lower case
    /// </summary>
    /// <param name="sourceString"></param>
    /// <param name="cultureInfo">Culture info, CurrentCulture by default</param>
    /// <returns></returns>
    /// <example>Test StrING => test string</example>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToLowerCase(this string? sourceString, CultureInfo? cultureInfo = null)
        => sourceString.IsNullOrWhiteSpace()
            ? sourceString
            : (cultureInfo ?? CultureInfo.CurrentCulture).TextInfo.ToLower(sourceString!);

    /// <summary>
    /// Make the first latter small
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToLowerStart(this string? sourceString)
        => sourceString.IsNullOrWhiteSpace()
            ? sourceString 
            : $"{CultureInfo.CurrentCulture.TextInfo.ToLower(sourceString![0])}{sourceString[1..]}";
}