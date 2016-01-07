// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "Parser.fsy"

#indent "off"

open Generators
open System.Diagnostics

# 13 "Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | ZERO_OR_ONE
  | ZERO_OR_MORE
  | ONE_OR_MORE
  | ESCAPE of (string)
  | ALTERNATION
  | RANGE of (char*char)
  | LITERAL of (string)
  | OPEN_SET
  | CLOSE_SET
  | OPEN_PARENTHESIS
  | CLOSE_PARENTHESIS
  | ANY_CHAR
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_ZERO_OR_ONE
    | TOKEN_ZERO_OR_MORE
    | TOKEN_ONE_OR_MORE
    | TOKEN_ESCAPE
    | TOKEN_ALTERNATION
    | TOKEN_RANGE
    | TOKEN_LITERAL
    | TOKEN_OPEN_SET
    | TOKEN_CLOSE_SET
    | TOKEN_OPEN_PARENTHESIS
    | TOKEN_CLOSE_PARENTHESIS
    | TOKEN_ANY_CHAR
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_regEx
    | NONTERM_quantifier
    | NONTERM_char
    | NONTERM_alternation

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | ZERO_OR_ONE  -> 1 
  | ZERO_OR_MORE  -> 2 
  | ONE_OR_MORE  -> 3 
  | ESCAPE _ -> 4 
  | ALTERNATION  -> 5 
  | RANGE _ -> 6 
  | LITERAL _ -> 7 
  | OPEN_SET  -> 8 
  | CLOSE_SET  -> 9 
  | OPEN_PARENTHESIS  -> 10 
  | CLOSE_PARENTHESIS  -> 11 
  | ANY_CHAR  -> 12 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_ZERO_OR_ONE 
  | 2 -> TOKEN_ZERO_OR_MORE 
  | 3 -> TOKEN_ONE_OR_MORE 
  | 4 -> TOKEN_ESCAPE 
  | 5 -> TOKEN_ALTERNATION 
  | 6 -> TOKEN_RANGE 
  | 7 -> TOKEN_LITERAL 
  | 8 -> TOKEN_OPEN_SET 
  | 9 -> TOKEN_CLOSE_SET 
  | 10 -> TOKEN_OPEN_PARENTHESIS 
  | 11 -> TOKEN_CLOSE_PARENTHESIS 
  | 12 -> TOKEN_ANY_CHAR 
  | 15 -> TOKEN_end_of_input
  | 13 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_regEx 
    | 3 -> NONTERM_regEx 
    | 4 -> NONTERM_regEx 
    | 5 -> NONTERM_regEx 
    | 6 -> NONTERM_regEx 
    | 7 -> NONTERM_regEx 
    | 8 -> NONTERM_regEx 
    | 9 -> NONTERM_regEx 
    | 10 -> NONTERM_quantifier 
    | 11 -> NONTERM_quantifier 
    | 12 -> NONTERM_quantifier 
    | 13 -> NONTERM_quantifier 
    | 14 -> NONTERM_char 
    | 15 -> NONTERM_char 
    | 16 -> NONTERM_alternation 
    | 17 -> NONTERM_alternation 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 15 
let _fsyacc_tagOfErrorTerminal = 13

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | ZERO_OR_ONE  -> "ZERO_OR_ONE" 
  | ZERO_OR_MORE  -> "ZERO_OR_MORE" 
  | ONE_OR_MORE  -> "ONE_OR_MORE" 
  | ESCAPE _ -> "ESCAPE" 
  | ALTERNATION  -> "ALTERNATION" 
  | RANGE _ -> "RANGE" 
  | LITERAL _ -> "LITERAL" 
  | OPEN_SET  -> "OPEN_SET" 
  | CLOSE_SET  -> "CLOSE_SET" 
  | OPEN_PARENTHESIS  -> "OPEN_PARENTHESIS" 
  | CLOSE_PARENTHESIS  -> "CLOSE_PARENTHESIS" 
  | ANY_CHAR  -> "ANY_CHAR" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | ZERO_OR_ONE  -> (null : System.Object) 
  | ZERO_OR_MORE  -> (null : System.Object) 
  | ONE_OR_MORE  -> (null : System.Object) 
  | ESCAPE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ALTERNATION  -> (null : System.Object) 
  | RANGE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | LITERAL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | OPEN_SET  -> (null : System.Object) 
  | CLOSE_SET  -> (null : System.Object) 
  | OPEN_PARENTHESIS  -> (null : System.Object) 
  | CLOSE_PARENTHESIS  -> (null : System.Object) 
  | ANY_CHAR  -> (null : System.Object) 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 10us; 65535us; 0us; 2us; 4us; 5us; 7us; 8us; 11us; 12us; 14us; 15us; 17us; 18us; 20us; 21us; 25us; 26us; 29us; 30us; 37us; 36us; 7us; 65535us; 6us; 7us; 10us; 11us; 13us; 14us; 16us; 17us; 19us; 20us; 24us; 25us; 28us; 29us; 2us; 65535us; 22us; 27us; 34us; 35us; 2us; 65535us; 4us; 9us; 37us; 38us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 14us; 22us; 25us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 1us; 2us; 3us; 4us; 3us; 3us; 16us; 17us; 1us; 3us; 1us; 3us; 1us; 3us; 1us; 4us; 1us; 4us; 1us; 4us; 1us; 4us; 1us; 5us; 1us; 5us; 1us; 5us; 1us; 6us; 1us; 6us; 1us; 6us; 1us; 7us; 1us; 7us; 1us; 7us; 2us; 8us; 9us; 1us; 8us; 1us; 8us; 1us; 8us; 1us; 8us; 1us; 9us; 1us; 9us; 1us; 9us; 1us; 9us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 15us; 1us; 15us; 2us; 16us; 17us; 1us; 17us; 1us; 17us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 11us; 15us; 17us; 19us; 21us; 23us; 25us; 27us; 29us; 31us; 33us; 35us; 37us; 39us; 41us; 43us; 45us; 47us; 50us; 52us; 54us; 56us; 58us; 60us; 62us; 64us; 66us; 68us; 70us; 72us; 74us; 76us; 79us; 81us; |]
let _fsyacc_action_rows = 39
let _fsyacc_actionTableElements = [|5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 49152us; 1us; 32768us; 0us; 3us; 0us; 16385us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 2us; 16400us; 5us; 37us; 11us; 6us; 3us; 16394us; 1us; 31us; 2us; 32us; 3us; 33us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 16387us; 1us; 32768us; 11us; 10us; 3us; 16394us; 1us; 31us; 2us; 32us; 3us; 33us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 16388us; 3us; 16394us; 1us; 31us; 2us; 32us; 3us; 33us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 16389us; 3us; 16394us; 1us; 31us; 2us; 32us; 3us; 33us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 16390us; 3us; 16394us; 1us; 31us; 2us; 32us; 3us; 33us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 16391us; 2us; 16398us; 6us; 23us; 7us; 34us; 1us; 32768us; 9us; 24us; 3us; 16394us; 1us; 31us; 2us; 32us; 3us; 33us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 16392us; 1us; 32768us; 9us; 28us; 3us; 16394us; 1us; 31us; 2us; 32us; 3us; 33us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 16393us; 0us; 16395us; 0us; 16396us; 0us; 16397us; 1us; 16398us; 7us; 34us; 0us; 16399us; 1us; 16400us; 5us; 37us; 5us; 16386us; 4us; 19us; 7us; 16us; 8us; 22us; 10us; 4us; 12us; 13us; 0us; 16401us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 6us; 7us; 9us; 10us; 16us; 19us; 23us; 29us; 30us; 32us; 36us; 42us; 43us; 47us; 53us; 54us; 58us; 64us; 65us; 69us; 75us; 76us; 79us; 81us; 85us; 91us; 92us; 94us; 98us; 104us; 105us; 106us; 107us; 108us; 110us; 111us; 113us; 119us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 0us; 5us; 5us; 3us; 3us; 3us; 5us; 5us; 0us; 1us; 1us; 1us; 0us; 2us; 1us; 3us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 16387us; 65535us; 65535us; 65535us; 16388us; 65535us; 65535us; 16389us; 65535us; 65535us; 16390us; 65535us; 65535us; 16391us; 65535us; 65535us; 65535us; 65535us; 16392us; 65535us; 65535us; 65535us; 16393us; 16395us; 16396us; 16397us; 65535us; 16399us; 65535us; 65535us; 16401us; |]
let _fsyacc_reductions ()  =    [| 
# 162 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data :  regExGenerator )) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 171 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 24 "Parser.fsy"
                                            fun () -> _1 ""  
                   )
# 24 "Parser.fsy"
                 :  regExGenerator ));
# 182 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 28 "Parser.fsy"
                         
                     			identity 
                     		
                   )
# 28 "Parser.fsy"
                 : 'regEx));
# 194 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'quantifier)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 33 "Parser.fsy"
                        
                     			(_4 _2) >> _5
                     		
                   )
# 33 "Parser.fsy"
                 : 'regEx));
# 209 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'alternation)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'quantifier)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "Parser.fsy"
                        
                     			_4 (alternation _2) >> _5
                     		
                   )
# 38 "Parser.fsy"
                 : 'regEx));
# 224 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'quantifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "Parser.fsy"
                         
                     			(_2 char) >> _3
                     		
                   )
# 43 "Parser.fsy"
                 : 'regEx));
# 238 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'quantifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "Parser.fsy"
                        
                     			_2(literal _1) >> _3
                     		
                   )
# 48 "Parser.fsy"
                 : 'regEx));
# 253 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'quantifier)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "Parser.fsy"
                         
                     			_2(literal _1) >> _3
                     		
                   )
# 53 "Parser.fsy"
                 : 'regEx));
# 268 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : char*char)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'quantifier)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "Parser.fsy"
                        
                     			_4 ( range _2 ) >> _5
                     		
                   )
# 57 "Parser.fsy"
                 : 'regEx));
# 283 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'char)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'quantifier)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "Parser.fsy"
                        
                     			_4( set _2 ) >> _5
                     		
                   )
# 61 "Parser.fsy"
                 : 'regEx));
# 298 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "Parser.fsy"
                               Quantifiers.one 
                   )
# 66 "Parser.fsy"
                 : 'quantifier));
# 308 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "Parser.fsy"
                                        Quantifiers.zeroOrOne 
                   )
# 67 "Parser.fsy"
                 : 'quantifier));
# 318 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "Parser.fsy"
                                         Quantifiers.zeroOrMore 
                   )
# 68 "Parser.fsy"
                 : 'quantifier));
# 328 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "Parser.fsy"
                                        Quantifiers.oneOrMore 
                   )
# 69 "Parser.fsy"
                 : 'quantifier));
# 338 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "Parser.fsy"
                             [] 
                   )
# 72 "Parser.fsy"
                 : 'char));
# 348 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'char)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "Parser.fsy"
                                       _1 :: _2 
                   )
# 73 "Parser.fsy"
                 : 'char));
# 360 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "Parser.fsy"
                                      [ _1 ] 
                   )
# 76 "Parser.fsy"
                 : 'alternation));
# 371 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'regEx)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'alternation)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "Parser.fsy"
                                                        _1 :: _3 
                   )
# 77 "Parser.fsy"
                 : 'alternation));
|]
# 384 "Parser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 16;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf :  regExGenerator  =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
