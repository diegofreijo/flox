module ParserCombinators

open System

type ParseResult<'a> =
    | Success of 'a
    | Failure of string

type Parser<'T> = Parser of (string -> ParseResult<'T * string>)

let pchar charToMatch =
    // define a nested inner function
    let innerFn str =
        if String.IsNullOrEmpty(str) then
            Failure "No more input"
        else
            let first = str.[0]

            if first = charToMatch then
                let remaining = str.[1..]
                Success(charToMatch, remaining)
            else
                let msg = sprintf "Expecting '%c'. Got '%c'" charToMatch first
                Failure msg
    // return the inner function
    Parser innerFn


let run parser input =
    // unwrap parser to get inner function
    let (Parser innerFn) = parser
    // call inner function with input
    innerFn input
