using System.Runtime.CompilerServices;

namespace DotNetEveryDay.Extensions.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Check if collection is null or empty
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable)
        => enumerable is null || !enumerable.Any();

    /// <summary>
    /// Check <see cref="enumerable"/> duplicates by some compare field
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="compareField"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProp"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasDuplicates<T, TProp>(this IEnumerable<T>? enumerable, Func<T, TProp> compareField)
    {
        if (enumerable is null)
            return false;

        var array = enumerable.ToArray();

        // TODO: [Optimization] Memory might be optimized
        var hashSet = new HashSet<TProp>(array.Length);
        
        foreach (var item in array)
            if (!hashSet.Add(compareField(item)))
                return true;

        return false;
    }
}