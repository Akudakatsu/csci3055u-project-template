open System

let x = 2

// basic if
if x > 20 then
    printfn "This is wrong."

// if else
if x > 20 then
    printfn "Failure"
else
    printfn "Success"

// if else-if else
if x > 20 then
    printfn "Really?"
elif x = 4 then
    printfn "Half"
elif x = 2 then
    printfn "Correct"
else
    printfn "Oh No!"

// nested ifs
if x < 20 then
    if x % 2 = 0 then
        if x = 2 then
            printfn "x < 20, even, = 2"
// could have just and'ed them

// basic for loop, increases variable
for i = 1 to 20 do
    if i = 20 then printf "%O\n" i
    else printf "%O, " i

// decreases variable
for i = 20 downto 1 do
    if i = 1 then printf "%O\n" i
    else printf "%O, " i

// iterating over a sequence of any kind
// [1..20] is range(1,21), can be a conventional list too
for i in [1..20] do
    if i = 20 then printf "%O\n" i
    else printf "%O, " i

// while loop (not an ideal condiion, requires mutability)
let mutable y = 20
while y > 0 do
    if y = 1 then printf "%O\n" y
    else printf "%O, " y
    y <- y - 1

// nested loops
for i in [1..5] do
    for j in [1..5] do
        if i = 5 && j = 5 then printf "%O\n" (i * j)
        else printf "%O, " (i * j)

// a complex combination of these inside functions with list comprehensions can be used
// to create new lists from existing lists

Console.ReadKey() |> ignore
