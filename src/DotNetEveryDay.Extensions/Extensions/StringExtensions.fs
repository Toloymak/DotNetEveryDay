namespace DotNetEveryDay.Extensions.Extensions

open System.Globalization
open System.Runtime.CompilerServices
open System

[<Extension>]
type StringExtensions =
    [<Extension>]
    static member inline IsNullOrEmpty(sourceString: string) =
        String.IsNullOrEmpty(sourceString)
        
    [<Extension>]
    static member inline IsNullOrWhiteSpace(sourceString: string) =
        String.IsNullOrWhiteSpace(sourceString)
        
    [<Extension>]
    static member inline ToTitleCase(sourceString: string) =
        sourceString |> CultureInfo.CurrentCulture.TextInfo.ToTitleCase
        
    [<Extension>]
    static member inline ToLowerCamelCase(sourceString: string) =
        if sourceString.IsNullOrWhiteSpace() then
            sourceString
        else
            CultureInfo.CurrentCulture.TextInfo.ToLower(sourceString[0]).ToString() + sourceString.Substring(1)