module Generators

open System

type regExGenerator = unit -> string

let max_random_occurences = 64

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

let rangeGen (c : char*char) s =
    let n = randomRange ( Convert.ToInt32 (fst c)) (Convert.ToInt32 (snd c))
    n |> Convert.ToChar
        |> Seq.singleton
        |> Seq.append s
        |> String.Concat


module Quantifiers =
    let rec loop g s n =
        match n with
            | 0 -> s
            | _ -> loop g (g s) (n-1)

    let zeroOrOne g s =
        loop g s (randomRange 0 1)

    let one g s =
        g s

    let zeroOrMore g s =
        let n = randomRange 0 max_random_occurences
        loop g s n

    let oneOrMore g s =
        let n = randomRange 1 max_random_occurences
        loop g s n


            
    