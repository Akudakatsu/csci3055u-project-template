module Game

open System
open System.Collections.Generic
open Deck

type Game =
    class
        val Shoe : List<Card>
        val Discard : List<Card>
        val PlayerHands : List<List<Card>> // list of list of cards (in case of split)
        val DealerHand : List<Card>
        val mutable Hidden : Card // dealer's hidden card
        val mutable Dealer : int // store dealer value
        val Player : List<int> // store each hand's value
        val InPlay : List<bool> // is each hand in play?
        val mutable Hand : int // which hand is the current focus

        new (shoe) =
            { Shoe = Game.SetUp shoe;
                Discard = new List<Card>();
                PlayerHands = new List<List<Card>>();
                DealerHand = new List<Card>();
                Hidden = {Face = Faces.Ace; Suit = Suits.S}; // placeholder card
                Dealer = 0;
                Player = new List<int>();
                InPlay = new List<bool>();
                Hand = 0 }
        
        static member SetUp shoe =
            let dynShoe = List<Card>()
            for i in shoe do
                dynShoe.Add(i)
            dynShoe
        
        member x.Initialize =
            printfn "New Game ----------------------------------------"
            x.Shuffle
            x.PlayerHands.Add(new List<Card>())
            x.Player.Add 0 // value for that hand
            x.InPlay.Add true // first hand is in play

            for i in [1..2] do // run twice, adding 2 cards
                (x.PlayerHands.Item 0).Add x.Deal // add card to first hand

                if x.DealerHand.Count = 1 then
                    x.Hidden <- x.Deal
                else
                    x.DealerHand.Add x.Deal // add card to dealer
            
            x.Value x.DealerHand false
            x.Value (x.PlayerHands.Item x.Hand) true
        
        member private x.Deal =
            let card = x.Shoe.Item 0 // first card
            x.Shoe.RemoveAt 0
            card
        
        member private x.Shuffle =
            for i in [0..x.Discard.Count - 1] do
                x.Shoe.Add (x.Discard.Item 0) // add top card
                x.Discard.RemoveAt 0 // remove top card from discard
            let rng = Random()
            for i in [1..5] do // do 5 shuffles
                for j in [1..x.Shoe.Count] do // run for length of Shoe
                    let n = rng.Next(0, x.Shoe.Count)
                    let card = x.Shoe.Item n // get card at index
                    x.Shoe.RemoveAt n // remove that card
                    x.Shoe.Add card // add that card to the end
            //printfn ""
        
        member x.Hit =
            if x.InPlay.Item x.Hand then // if this hand is in play
                (x.PlayerHands.Item x.Hand).Add x.Deal // add a new card
                x.Value (x.PlayerHands.Item x.Hand) true

        member x.DealerHit =
            if x.DealerHand.Count < 2 then
                x.DealerHand.Add x.Hidden // add the hidden card
            else
                x.DealerHand.Add x.Deal // if in hit stage, add card
            x.Value x.DealerHand false
            if x.Dealer < 17 then
                x.DealerHit // keeps hitting till value >= 17

        member x.Double =
            printfn ""
        
        member x.Split =
            printfn ""
        
        member x.Stand =
            x.DealerHit // player ended turn, start hit
            x.EndGame // turn ended, compare cards
        
        member x.Surrender =
            printfn ""
        
        member x.Value hand p = // p for is player?
            let mutable value = 0
            for i in hand do // go through cards in hand
                value <- value + Game.FaceVal i false // default hand value
            
            if value > 21 then // is this hands value bust?
                value <- 0
                for i in hand do
                    value <- value + Game.FaceVal i true // change ace values
            if p then
                x.Player.Item x.Hand <- value
                x.Print hand p
                if value > 21 then
                    x.InPlay.Item x.Hand <- false // still above, send hand out of play
                    if x.Hand < x.PlayerHands.Count - 1 then
                        x.Hand <- x.Hand + 1 // move on to hand if applicable
                    else
                        x.DealerHand.Add x.Hidden // add this to keep track of cards (cause dealer won't hit)
                        x.EndGame // hand has gone bust, end this session
            else
                x.Dealer <- value
                x.Print hand p
        
        member x.EndGame =
            if x.Player.Item x.Hand > 21 then
                printfn "You Lose"
            elif x.Dealer > 21 then
                printfn "You Win"
            elif x.Player.Item x.Hand > x.Dealer then
                printfn "You Win"
            else
                printfn "You Lose"
            printfn ""
            x.New // set up new game
        
        member x.New =
            printfn "New Game ----------------------------------------"
            for i in [0..x.PlayerHands.Count - 1] do
                for j in [0..(x.PlayerHands.Item i).Count - 1] do
                    x.Discard.Add ((x.PlayerHands.Item i).Item j) // add the cards within hands to discard pile
                x.PlayerHands.RemoveAt 0 // remove all hands
                x.Player.RemoveAt 0 // remove all values of hands
                x.InPlay.RemoveAt 0 // remove all in play statuses
            for i in [0..x.DealerHand.Count - 1] do
                x.Discard.Add (x.DealerHand.Item 0) // add cards before removing
                x.DealerHand.RemoveAt 0 // remove all cards
            x.Dealer <- 0
            x.Hand <- 0

            if x.Discard.Count > x.Shoe.Count then
                x.Shuffle
            //printfn "" // add a line

            x.PlayerHands.Add(new List<Card>())
            x.Player.Add 0 // value for that hand
            x.InPlay.Add true // first hand is in play

            for i in [1..2] do // run twice, adding 2 cards
                (x.PlayerHands.Item 0).Add x.Deal // add card to first hand

                if x.DealerHand.Count = 1 then
                    x.Hidden <- x.Deal
                else
                    x.DealerHand.Add x.Deal // add card to dealer
            
            x.Value x.DealerHand false
            x.Value (x.PlayerHands.Item x.Hand) true
        
        member x.Print hand p =
            let mutable n = 0
            if p then printf "\nYour Hand: "
            else printf "\nDealer's Hand: "
            for i in hand do
                n <- n + 1
                if n = hand.Count then
                    printf "%O of %O " i.Face i.Suit
                else
                    printf "%O of %O, " i.Face i.Suit
            if p then printfn "| Value: %O" (x.Player.Item x.Hand)
            else printfn "| Value: %O"  x.Dealer
                
                    
        static member FaceVal card c = // face of card, c for change (for Ace exclusively)
            if card.Face = Faces.Two then 2
            elif card.Face = Faces.Three then 3
            elif card.Face = Faces.Four then 4
            elif card.Face = Faces.Five then 5
            elif card.Face = Faces.Six then 6
            elif card.Face = Faces.Seven then 7
            elif card.Face = Faces.Eight then 8
            elif card.Face = Faces.Nine then 9
            elif card.Face = Faces.Ten then 10
            elif card.Face = Faces.Jack then 10
            elif card.Face = Faces.Queen then 10
            elif card.Face = Faces.King then 10
            elif card.Face = Faces.Ace && (not c) then 11 // false = A as 11
            elif card.Face = Faces.Ace && c then 1 // true = A as 1
            else 0
    end
