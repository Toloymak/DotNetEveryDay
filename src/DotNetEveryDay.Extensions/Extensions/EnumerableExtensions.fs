namespace IdentityServer4.Helpers.Extensions

open System
open System.Collections.Generic
open System.Runtime.CompilerServices

[<Extension>]
type EnumerableExtensions =
    [<Extension>]
    static member inline IsNullOrEmpty(collection: seq<'T>) =
        collection = null || collection |> Seq.isEmpty        

    [<Extension>]
    static member inline HasDuplicates(collection: seq<'T>, selector: Func<'T, 'TProp>) : bool =
        if collection.IsNullOrEmpty() then
            false
        else
            let hashSet: HashSet<'TProp> = new HashSet<'TProp>()
            let convertedSelector = FuncConvert.FromFunc selector
        
            collection |> Seq.exists(convertedSelector >> hashSet.Add >> not)