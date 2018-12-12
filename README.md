# _F#_

- Muhammad Naveed Karim
- muhammad.karim@uoit.net

## About the language

> _History_
>
> F# is a strongly typed, multi-paradigm programming language that encompasses functional, imperative, and object-oriented programming methods. It was first released in 2005. (from Wikipedia)
>
> _Some interesting features_
>
> F# supports immutable types (like Clojure), but also supports mutable types, like generic collections commonly found in OOP languages. It can also create true custom objects (through classes) and these features combined allow for the creation of very complex applications.

## About the syntax
> _Some basic snippets (more detailed syntax can be found in basic-syntax)_
> 
> #### Let form
> ```
> let <symbol> = <value>
> 
> let <name>() =
>     <argument-less-function-body>
> 
> let <name> arg_1 arg_2 =
>     <function-with-2-arguments-body>
> ```
> 
> #### Anonymous Functions And Recursion
> ```
> (fun x y -> x + y)
> 
> let rec <name> <args> =
>     <body-involving-call-to-<name>>
> ```
> 
> #### Lists (Immutable)
> ```
> let list_1 = [for i in [1..10] do yield i] // [1; 2; .. 9; 10]
> let list_2 = [for i in 1..10 do if i % 2 = 0 then yield i * i] // list of even squares
> ```
> 
> #### Classes
> ```
> type <name> =
>     class
>           val <name-1> : <type> // official language type
>           ..
>             
>           new (<constructor-args-here) = 
>                 { <name-1> = <value>;
>                       .. } // all 'val' variables must be assigned in constructor
> 
>           member x.<name-2> <optional-args> =
>                 <member-body> // class function
>                 // access class variables/members via x.<name-1>
> 
>           ..
>     end
> ```

## About the tools

> The optimal way to use F# is through Visual Studio; it has great support for creating large projects very easily.
>
> F# Interactive (fsi.exe) can be used to run .fsx files (F# script files vs .fs source files); identical code.
>
> Note: I tested this on Win10, where the fsi.exe is provided by Visual Studio. I cannot say how this will work on other OS'es.

## About the standard library
> #### Lists (Immutable)
> ```
> let list_1 = [1.0; 2.0; 3.0; 4.0; 5.0] // list of floats
> printfn "%O" (List.average list_1) // gets average of elements (only takes float lists)
> printfn "%O" (List.sum list_1) // gets the sum of elements
> // supports many more functions (like ones found in Clojure)
> ```
>
> #### Enums
> ```
> type Days =
>     | Sun = 0
>     | Mon = 1
>     | Tues = 1
>     | Wed = 1
>     | Thurs = 1
>     | Fri = 1
>     | Sat = 1
> ```
>
> Supports many more types, these are just simple examples.

## About open source library
> _Incomplete_

# Analysis of the language

## The Style of Programming
> As stated above, F# is a combination of functional, imperative and object-oriented paradigms.

## Meta-Programming
> _Incomplete_

## Symbol Resolution and Closure
> All symbols are resolved immediately and must exist before being referenced (classes are excepted when referring to their members).

## Scoping Rules (Lexical vs Dynamic)
> F# uses lexical scoping; I didn't find any examples of dynamic scoping.

## Functional Programming Constructs
> F# supports functional programming constructs by default. It does not require () by default, but they are needed during nested calls.
> ```
> printfn "%O" (List.average list_1) 
> ```

## Type System
> F# has a static type system. The system is very strict about mixing types as well, see the code below:
>```
> let func x y = x + y
> printfn "%O" (func 1 2) // perfectly fine
> printfn "%O" (func 1.0 2.0) // error, 
> // cannot send floats to func because it has been restricted to ints fro 1st call
>```

## Strengths and Weaknesses
> All the programming aspects of F# are its strengths. It supports multiple paradigms, allowing for ideal combinations of all aspects of programming to create powerful and complex applications.
>
> I dislike the process of compiling F# outside of Visual Studio, it is a nightmare compared to other languages I have used: Clojure, Python, Java, C#, C++.
