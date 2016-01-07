module Generators

open System

type regExGenerator = unit -> string

let randomBoolean =
    let r = new Random()
    (r.Next(0, 1023) % 2) = 1

let randomRange min max = 
    let r = new Random()
    r.Next(min, max)

// TODO: Only printable chars?
// TODO: Support unicode
let identityGen s =
    s

let charGen s = 
    let n = randomRange 1 255
    n |> Convert.ToChar
        |> Seq.singleton
        |> Seq.append s
        |> String.Concat

let literalGen c s = 
    [s; c] |> String.Concat  


module Quantifiers =
    let zeroOrOne g s =
        match randomBoolean with
            | true -> g s
            | false -> s

    let one g s =
        g s
    