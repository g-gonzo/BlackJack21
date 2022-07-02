using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack3
{
    class Program
    {

        // Variables
        public static string playersInput = "";

        static Players PlayerOne = new Players { name = "Player"};
        static Players Dealer = new Players { name = "Dealer"};

        static void Main(string[] args)
        {
            while (true)
            {
                Deck.ShuffleDeck();
                WelcomeMessage();
                GameLoop();
                ResetGame();
            }

        }

        public static void WelcomeMessage()
        {
            Console.WriteLine($"Let's play Black Jack!");

        }

        public static void GameLoop()
        {
            var isGameStillGoing = true;

            DealCardsStart();
            do
            { 
                DisplayPlayersCards();
                DisplayOneDealerCard();

                do
                {
                    Console.Write($"Do you want a (H)it or (S)tay or (R)eset? ");
                    playersInput = Console.ReadKey().KeyChar.ToString().ToUpper();
                    Console.WriteLine();
                }
                while (!playersInput.Equals("H") && !playersInput.Equals("S") && !playersInput.Equals("R"));

                if (playersInput.Equals("H"))
                {
                    isGameStillGoing = HitMe();
                }
                else if (playersInput.Equals("R"))
                {
                    isGameStillGoing = false;
                }
                else if (playersInput.Equals("S"))
                {
                    DisplayAllDealersCards();
                    while (Dealer.GetPlayersTotal() < 17)
                    {
                        Dealer.AddCardToHand(Deck.DealSingleCard());
                        DisplayAllDealersCards();
                    }

                    isGameStillGoing = false;
                    
                    Stay();
                }
            }
 
            while (isGameStillGoing);  
            Console.ReadLine();
        }

        public static bool HitMe()
        {
            PlayerOne.AddCardToHand(Deck.DealSingleCard());

            if (PlayerOne.GetPlayersTotal() > 21)
            {
                Console.WriteLine("Sorry, its a bust, you lose!");
                return false;
            }
            return true;
        }

        public static void Stay()
        {

            if ((PlayerOne.GetPlayersTotal() > Dealer.GetPlayersTotal()) || Dealer.GetPlayersTotal() > 21)
            {
                Console.WriteLine($"Congratulations! You won the game! The dealer's hand was : {Dealer.GetPlayersTotal()}");
                Console.WriteLine($"The player's hand was : {PlayerOne.GetPlayersTotal()}");
            }
            else if (PlayerOne.GetPlayersTotal() == Dealer.GetPlayersTotal())
            {
                Console.WriteLine("Push");
            }
            else
            {
                Console.WriteLine($"Sorry, you lost the game! The dealer's hand was : {Dealer.GetPlayersTotal()}");
                Console.WriteLine($"The player's hand was : {PlayerOne.GetPlayersTotal()}");
            }
        }

        public static void DealCardsStart()
        {
            var cards = Deck.DealCardsInPlay();

            PlayerOne.PlayersCards.AddRange(cards.Take(2));
            Dealer.PlayersCards.AddRange(cards.TakeLast(2));
        }

        public static void DisplayPlayersCards()
        {
            Console.WriteLine(PlayerOne.ShowMePlayersCards());
            Console.WriteLine($"Players Total : {PlayerOne.GetPlayersTotal()}");
        }

        public static void DisplayAllDealersCards()
        {
            Console.WriteLine(Dealer.ShowMePlayersCards());
            Console.WriteLine($"Dealers Total : {Dealer.GetPlayersTotal()}");
        }

        public static void DisplayOneDealerCard()
        {
            Console.WriteLine($"Displaying Dealer's Card: {Dealer.PlayersCards[0]}");
        }

        public static void ResetGame()
        {
            Deck.DeckOfCards.Clear();
            PlayerOne.PlayersCards.Clear();
            Dealer.PlayersCards.Clear();
        }

    }
}


