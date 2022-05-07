using System.Collections.Concurrent;

namespace DotNetEveryDay.Extensions.Extensions;


public static class AttributeExtensions
{
    private static readonly ConcurrentDictionary<string, Attribute?> CachedAttributes =
        new(Environment.ProcessorCount, 256);

    /// <summary>
    /// Get attribute if exist or null for property by property name
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyName"></param>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    public static TAttribute? GetPropertyAttribute<TAttribute>(this Type type, string propertyName)
        where TAttribute : Attribute
    {
        if (type == null) throw new ArgumentNullException(nameof(type));

        if (propertyName.IsNullOrWhiteSpace()) return null;
        
        return (TAttribute?) CachedAttributes.GetOrAdd($"{type}.{propertyName}_{typeof(TAttribute)}",
            _ => (TAttribute?) type.GetProperty(propertyName)
            ?.GetCustomAttributes(typeof(TAttribute), false)
            .FirstOrDefault());
    }
}