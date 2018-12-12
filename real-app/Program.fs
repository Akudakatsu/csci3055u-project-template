// Learn more about F# at http://fsharp.org

open System
open Deck
open Game

let s = Shoe()

[<EntryPoint>]
let main argv =
    let game = new Game(Shoe())
    game.Initialize
    let mutable ans = ""
    while not (ans.Equals "exit") do
        printfn "\nEnter a Command: hit | stand | exit"
        ans <- Console.ReadLine()

        if ans.Equals "hit" then game.Hit
        elif ans.Equals "stand" then game.Stand
    printfn "Hit any key to exit."
    Console.ReadKey() |> ignore
    0 // return an integer exit code

