module Generators

open System

type regExGenerator = unit -> string

let max_random_occurences = 64

let r = new Random()

let randomBoolean =
    (r.Next(0, 1023) % 2) = 1

let randomRange min max = 
    let size = max - min
    (r.Next() % size) + min

// TODO: Only printable chars?
// TODO: Support unicode
let identity s =
    s

let char s = 
    let n = randomRange 1 255
    n |> Convert.ToChar
        |> Seq.singleton
        |> Seq.append s
        |> String.Concat

let literal c s = 
    [s; c] |> String.Concat  

let range (c : char*char) s =
    let n = randomRange ( Convert.ToInt32 (fst c)) (Convert.ToInt32 (snd c))
    n |> Convert.ToChar
        |> Seq.singleton
        |> Seq.append s
        |> String.Concat

let set (l : 'string list ) s = 
    let n = randomRange 0 l.Length
    [l.Item n; s] 
        |> String.Concat

let alternation (l : list<string -> string>) s =
    let n = randomRange 0 l.Length
    (l.Item n) s

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


            
    