module ParserCombinators.Tests

open System
open NUnit.Framework
open ParserCombinators

[<Test>]
let ``pchar matching`` () =
    let parser = pchar 'a'
    let res = run parser "abc"
    let expected = Success('a', "bc")
    Assert.AreEqual(expected, res)

[<Test>]
let ``pchar not matching`` () =
    let parser = pchar 'x'
    let res = run parser "abc"
    let expected: ParseResult<char * string> = Failure "Expecting 'x'. Got 'a'"
    Assert.AreEqual(expected, res)
