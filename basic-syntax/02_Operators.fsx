open System

// arithmetic operators
let add = 5 + 2
let sub = 5 - 2
let mul = 5 * 2
let div = 5.0 / 2.0 // if integers only, does integer division
let modl = 5 % 2
let pow = 5.0 ** 2.0 // not supported with integer types
printfn "Arithmetic:\n%O\n%O\n%O\n%O\n%O\n%O\n" add sub mul div modl pow

// comparison operators
printfn "Comparison:\n%O\n%O\n%O\n%O\n%O\n%O\n"
    (1 = 2)
    (1 <> 2)
    (1 < 2)
    (1 > 2)
    (1 <= 2)
    (1 >= 2)

// boolean operators
printfn "Boolean:\n%O\n%O\n%O\n"
    (true && false) // and
    (true || false) // or
    (not true)

// bitwise operators, using 12 = 0000 1100, and 42 = 0010 1010
printfn "Bitwise:\n%O\n%O\n%O\n%O\n%O\n%O"
    (12 &&& 42) // bit and = 0000 1000 = 8
    (12 ||| 42) // bit or = 0010 1110 = 46
    (12 ^^^ 42) // bit xor = 0010 0110 = 38
    (~~~ 12) // one's complement (flips bits) = 1111 0011 = -13 (treats as signed)
    (12 <<< 2) // shifted 2 bits left = 0011 0000 = 48
    (42 >>> 2) // shifted 2 bits right = 0000 1010 = 10

Console.ReadKey() |> ignore
