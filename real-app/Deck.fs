module Deck

open System

// suits enum
type Suits =
    | C = 0 // clubs
    | D = 1 // diamonds
    | H = 2 // hearts
    | S = 3 // spades

// faces enum
type Faces =
    | Ace = 0
    | Two = 1
    | Three = 2
    | Four = 3
    | Five = 4
    | Six = 5
    | Seven = 6
    | Eight = 7
    | Nine = 8
    | Ten = 9
    | Jack = 10
    | Queen = 11
    | King = 12

// card record
type Card = {Suit:Suits; Face:Faces}

// builds a shoe of 8 full decks (like in classic BlackJack)
let Shoe() =
    [for l in [1..1] do
        for i in [0..Enum.GetValues(typeof<Suits>).Length - 1] do
            for j in [0..Enum.GetValues(typeof<Faces>).Length - 1] do
                yield {Suit = enum<Suits> i; Face = enum<Faces> j}]
