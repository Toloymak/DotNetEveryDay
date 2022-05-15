using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace DotNetEveryDay.Extensions.Extensions;

public static class StringExtensions
{
    private const int MaxOptimizationStringLength = 1000;

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
    /// <param name="sourceString"></param>
    /// <param name="memoryOptimization">Allow to increase memory allocation but make it slower</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToLowerStart(this string? sourceString, bool memoryOptimization = true)
    {
        if (sourceString.IsNullOrEmpty())
            return sourceString;

        var firstLetterInLowerTitle = CultureInfo.CurrentCulture.TextInfo.ToLower(sourceString![0]);
        if (firstLetterInLowerTitle == sourceString[0])
            return sourceString;

        // To protect stack by stackoverflow
        if (memoryOptimization is false
            || sourceString!.Length > MaxOptimizationStringLength)
            return $"{CultureInfo.CurrentCulture.TextInfo.ToLower(sourceString[0])}{sourceString[1..]}";

        Span<char> transformedString = stackalloc char[sourceString.Length];

        for (var i = 0; i < sourceString.Length; i++)
        {
            if (i == 0)
            {
                transformedString[i] = firstLetterInLowerTitle;
            }
            else
                transformedString[i] = sourceString[i];
        }

        return new string(transformedString);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToCamelCase(this string? sourceString)
    {
        return sourceString.ToCamelCase(isPascalCase: false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToPascalCase(this string? sourceString)
    {
        return sourceString.ToCamelCase(isPascalCase: true);
    }


    private static readonly char[] SymbolsForRemoving = {'_', ' ', '-', ','};
    private static readonly char[] SymbolsForReplacingToDot = {'!', '?'};

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string? ToCamelCase(this string? sourceString, bool isPascalCase)
    {
        if (sourceString.IsNullOrWhiteSpace())
            return sourceString;

        var needBigLetter = false;
        var isFirstLetter = true;

        var needOptimisation = sourceString!.Length <= MaxOptimizationStringLength;
        var resultBuilder = needOptimisation ? null : new StringBuilder();
        Span<char> resultString = needOptimisation ? stackalloc char[sourceString.Length] : null;
        var currentResultNumber = 0;

        foreach (var letter in sourceString)
        {
            char? resultLetter = null;
            if (SymbolsForRemoving.Contains(letter))
            {
                needBigLetter = true;
            }
            else if (SymbolsForReplacingToDot.Contains(letter))
            {
                needBigLetter = false;
                isFirstLetter = true;
                resultLetter = '.';
            }
            else if (isFirstLetter)
            {
                resultLetter = isPascalCase
                    ? CultureInfo.CurrentCulture.TextInfo.ToUpper(letter)
                    : CultureInfo.CurrentCulture.TextInfo.ToLower(letter);
                isFirstLetter = false;
            }
            else if (needBigLetter)
            {
                resultLetter = CultureInfo.CurrentCulture.TextInfo.ToUpper(letter);
                needBigLetter = false;
            }
            else
            {
                resultLetter = letter;
            }

            if (resultLetter == null)
                continue;

            if (needOptimisation)
                resultString[currentResultNumber++] = resultLetter.Value;
            else
                resultBuilder!.Append(resultLetter.Value);
        }

        if (needOptimisation)
        {
            Span<char> trimmedResultString = stackalloc char[currentResultNumber];

            for (var i = 0; i < currentResultNumber; i++)
            {
                trimmedResultString[i] = resultString[i];
            }

            return trimmedResultString.ToString();
        }
        else
        {
            return resultBuilder!.ToString();
        }
    }
}