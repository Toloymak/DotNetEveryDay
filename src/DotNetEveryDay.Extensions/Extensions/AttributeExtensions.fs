namespace DotNetEveryDay.Extensions.Extensions

open System.Collections.Concurrent
open System.Runtime.CompilerServices
open System

[<AllowNullLiteral>]
[<Extension>]
type AttributeExtensions() =
    [<DefaultValue>]
    static val mutable private CachedAttributes: ConcurrentDictionary<string, Attribute>
    
    static do
        AttributeExtensions.CachedAttributes <- ConcurrentDictionary<string, Attribute>()
    
    [<Extension>]
    static member GetAttribute<'TAttribute when 'TAttribute :> Attribute>(_type: Type, propertyName: string) =     
        AttributeExtensions.CachedAttributes.GetOrAdd(
            $"{_type}.{propertyName}_{typeof<'TAttribute>}",
            fun i -> AttributeExtensions.GetAttributeFromProperty<'TAttribute>(_type, propertyName))
        :?> 'TAttribute
        
    static member private GetAttributeFromProperty<'TAttribute when 'TAttribute :> Attribute>(
        _type: Type, propertyName: string) : Attribute =
        let attribute  =
            _type.GetProperty(propertyName).GetCustomAttributes(typeof<'TAttribute>, false)
            |> Seq.tryHead

        match attribute with
        | Some value -> value :?> Attribute
        | None -> null