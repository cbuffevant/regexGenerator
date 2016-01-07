namespace RegExGenerator

module Main =

    open Microsoft.FSharp.Text.Lexing

    let private create_buffer = LexBuffer<char>.FromString
    let private parse = Parser.start Lexer.buildGenerator

    let testRegExLexer regEx = 
        let buffer = create_buffer regEx
        while true do
            let token = Lexer.buildGenerator buffer
            System.Diagnostics.Debug.WriteLine(sprintf "%A" token)
        ()

    let regExGenerator regEx =   
        //testRegExLexer regEx 
        let g = 
            regEx 
            |> create_buffer
            |> parse
        g()
