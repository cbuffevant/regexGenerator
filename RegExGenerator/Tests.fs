module Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Microsoft.FSharp.Text.Lexing
open RegExGenerator.Main

[<TestClass>]
type UnitTest() = 

    member x.Assert regEx testInput = 
        Diagnostics.Debug.WriteLine(regEx + " >> " + testInput)
        let r = System.Text.RegularExpressions.Regex(regEx)
        Assert.IsTrue(r.IsMatch(testInput))

    member x.TestGenerator regEx = 
        regEx 
        |> regExGenerator 
        |> x.Assert regEx

    [<TestMethod>]
    member x.TestAnyCharacter () = 
        "." |> x.TestGenerator

    [<TestMethod>]
    member x.TestMultipleCharacters () =
        "..." |> x.TestGenerator

    [<TestMethod>]
    member x.TestLiteralCharacter () = 
        "\\@" |> x.TestGenerator

    [<TestMethod>]
    member x.TestLiteralDotCharacter () =
        "\\@.." |> x.TestGenerator

    [<TestMethod>]
    member x.TestZeroOrOneCharacter () = 
        "\\@.h?" |> x.TestGenerator