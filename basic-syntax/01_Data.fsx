// import System
open System

// Integers
// Can use letter suffixes to change bits, and sign
// 8-bit to 64-bit signed and unsigned : y, uy, s, us, u, L, UL; default is a 32 bit signed integer
let integer = 531564853
let big_integer = 5415786456569875645158687465665465I // uses >= 4 bytes

// Floats
// Can use letter suffixes to change bits (and precision)
// 32/128 : F, M; defaults to 64-bit double
let dbl = 3.141592653589793238462643383279 // won't store the entire number due to 64-bit precision limitations

// Character Data
let character = 'F' // any single unicode character from 0000 to ffff (uses 2 bytes)
let str = "Hello World" // from empty to 2GB of text data (uses 20 + 2 * length bytes)

// Boolean
let boolean = true // can be true/false

// explicit type declarations
let int_2:uint32 = 531564853u // need suffix 'u' or error
let float_2:decimal = 3.141592653589793238462643383279M // need M suffix or error

// print formatting: %[flags][width][.precision]specifier; there are more, but the following are most common
// %s for strings (exclusively, not even for characters)
// %b for booleans
// %i all integer types (except big I)
// %f all float types
// %A for pretty printing tuples (really any kind of array like sequences)
//    shows data types as well, prints "string" as "string" not string
// %O calls object ToString() and prints that (what I'll use for convenience)
//    optimal printing, ex. for doubles, prints w/ max precision by default,
//    unlike %f where it has to be specified via .15 (still kind of incorrect)
printfn "%O\n%O\n%O\n%O\n%O\n%O\n%O\n%O" integer big_integer dbl character str boolean int_2 float_2

// mutable variables
let mutable mut_var = "string"
printfn "Before: %O" mut_var
mut_var <- "changed" // data type cannot change
printfn "After: %O" mut_var
mut_var <- "final"
printfn "Final: %O" mut_var

// tuples (can store any kind of data)
let tuple_1 = ("string", 5, 4.0, 5 * 3, integer * 2) // calculates expressions before storing
 // deconstructing a fixed size tuple into its elements (maintains data types)
let t1,t2,t3,t4,t5 = tuple_1
printfn "%A\n%O, %O, %O, %O, %O" tuple_1 t1 t2 t3 t4 t5
// showing special "fst" and "snd" functions of F# (applicable to 2-tuples)
let tuple_2 = ("first", "second")
printfn "First: %O, Second: %O" (fst tuple_2) (snd tuple_2)

// records, explciit types are necessary; type <name> = {[field-1 : type]; .. }
type person = {first:string; last:string} // records are based on fields, do not duplicate fields
let john = {first = "John"; last = "Smith"} // a person
printfn "%O %O" john.first john.last
// creating a record based on an existing record
let john2 = {john with last = "Doe"} // ex. person wants to change last name
printfn "%O %O" john2.first john2.last

// Lists (can only contain one type)
let list_1 = [1.0; 2.0; 3.0; 4.0; 5.0] // list literal
let list_2 = 1::2::3::4::5::[] // using cons operator ::
let list_3 = List.init 5 (fun i -> 2 * i + 4) // initialize using 5 values via the anonymous function (covered later)
printfn "%A\n%A\n%A" list_1 list_2 list_3
// list comprehensions (syntactic sugar like python)
let list_4 = [1..10] // simple range(1, 11)
let list_5 = [1..2..10] // range(1, 11, 2), step is in the middle
let list_6 = ['a'..'i'] // can use characters too
let list_7 = [for i in 1..10 -> i * i] // like python (loops covered later)
let list_8 = [for i in 1..10 do if i % 2 = 0 then yield i * i] // adding conditions inside loops (covered later)
// yield vs yield! -> yield adds a value to the list; yield! adds a collection of values to the list
let list_9 = [for i in 1..10 do yield! [i..i+1]] // creates 20 elements going 1,2 , 2,3 , 3,4 ..
printfn "%A\n%A\n%A\n%A\n%A\n%A" list_4 list_5 list_6 list_7 list_8 list_9

// list properties
//      Head = first element, Tail = list without first element, Length = length of list,
//      IsEmpty = true/false if list is empty, Item(index) = element at zero-based index
printfn "%O\n%A\n%O\n%O\n%O" list_8.Head list_8.Tail list_8.IsEmpty list_8.Length (list_8.Item 4)

// List operators
printfn "%A\n%O\n%O\n%A\n%A"
    (List.append list_8 list_7) // append 2 lists as list-1-values, list-2-values
    (List.average list_1) // gets avg of elements, can only take floats (integers fail)
    (List.averageBy (fun i -> 2.0 * i) list_1) // get avg, but applies function to each element first
    (List.collect (fun e -> [for i in 1..e -> i * i]) list_2) // creates sublists for each e then returns all concatenated
    (List.concat [list_7; list_8; list_5]) // concatenates a list of lists in order
// and many more (similar to clojure)
// ex. filter, forall (every?), map, max, min, nth, partition, reduce, sort, sortBy, etc. (not an exhaustive list)

// other data types (not expanded upon for this project)
// sequences - quite similar to lists, slightly different syntax
// sets - declaration and methods similar to lists; caveats: no duplicates, no guaranteed order
// maps - much like clojure maps, but no keywords as keys
// mutable lists - classic generic collections found in procedural languages
// mutable dictionaries - classic generic collections found in procedural languages

Console.ReadKey() |> ignore
