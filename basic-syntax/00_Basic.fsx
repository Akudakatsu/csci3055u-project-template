// importing namespaces/modules (can be standard, or custom, shown later)
open System

(* Multi
   Line
   Comment *)

// Single Line Comment

// basic printing, can also use System.Console.Write/WriteLine(<data here>)
printf "Hello World!\n"
printfn "%s %s" "Hello" "World!"

// basic assignment
let symbol = "value"
// character = 'c', string = "string", intgers = 32, floats = 32.0

// basic function (no arguments)
let func() =
    printfn "Printing %s inside a function" symbol

// function with arguments (%<identifier> covered later)
let another x y =
    printfn "Arg-1 = %O & Arg-2 = %O" x y

// calling functions
func()
another 1 2

// used to keep console window open, ignore for now (System.Console)
Console.ReadKey() |> ignore
