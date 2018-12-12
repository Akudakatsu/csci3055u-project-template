open System

let no_args() =
    printfn "Function with no arguments"

let no_args_2() =
    let x = 2
    printfn "%Ond function with no arguments" x

let with_args x y =
    (x + y) * (x + y)

// anonymous functions, can be defined in a lot of places
printfn "basic anonymous: %O" ( (fun x -> x * x * x) 5 )

// nested functions using anonymous functions
let nested l w =
    (fun h -> l * w * h)

// restricting function types, both parameters and return
let restrict (x:float) (y:float) :float =
    y / x

// basic recursion, 'rec' keyword is required, without the call can't find the function
let rec fib n =
    if n < 2 then
        n
    else
        fib (n - 1) + fib (n - 2)

// arrow notations
// ex. let with_args x y = x + y
// is: val with_args int -> int -> int (right most being the return type)
// this is how f# reports about data types in functions

// this function takes a function as an argument with a restriction on data types
let taking_fn (f:int -> int -> int) x y =
    f x y
let taking_fn_2 f x y =
    f x y

// function composition
let f1 x = x + 10
let f2 x = x * 3
let f = f1 >> f2 // basically do f1 then f2

no_args()
no_args_2()
printfn "%O" (with_args 3 5)
//printfn "%O" (with_args 3.0 5.0) // function is locked to int after first call, = error
printfn "%O" (nested 3 5) // prints the returned function
printfn "%O" (nested 3 5 7)
//printfn "%O" (restrict 3 5) // error, only takes floats
//printfn "%i" (restrict 3.0 5.0) // error, return type is float
printfn "%O" (restrict 3.0 5.0)
printfn "1: %O\n2: %O\n6: %O\n7: %O\n8: %O\n10: %O\n40: %O" (fib 1) (fib 2) (fib 6) (fib 7) (fib 8) (fib 10) (fib 40)
printfn "passing functions: %O" (taking_fn (fun x y -> x + y) 4 6)
//printfn "passing functions %O" (taking_fn (fun x y -> x + y) 4.0 6.0) // error, type restricted
printfn "passing functions 2: %O" (taking_fn_2 (fun x y -> x + y) 5.0 7.0)
printfn "passing functions 3: %O" (taking_fn_2 (fun x y -> x + y) 5 7)
// because the function is anonymous, can pass any arguments, without type restrictions
printfn "composition: %O" (f 10)

// function pipelining, applies functions as successive operations, '|>'
// return types must be compatible as arguments for next function
printfn "pipelining: %O" (10 |> f1 |> f2)

// ignoring returned values
with_args 3 5 |> ignore // use of 'ignore' keyword

// simple take the read key, and ignore it
Console.ReadKey() |> ignore
