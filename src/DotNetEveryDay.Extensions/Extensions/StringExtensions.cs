using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace DotNetEveryDay.Extensions.Extensions;

public static class StringExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string? sourceString)
        => string.IsNullOrEmpty(sourceString);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace(this string? sourceString)
        => string.IsNullOrWhiteSpace(sourceString);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToTitleCase(this string? sourceString)
        => sourceString.IsNullOrWhiteSpace()
            ? sourceString
            : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sourceString!);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToLowerCamelCase(this string? sourceString)
        => sourceString.IsNullOrWhiteSpace()
            ? sourceString 
            : $"{CultureInfo.CurrentCulture.TextInfo.ToLower(sourceString![0])}{sourceString[1..]}";
}