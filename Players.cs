using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackJack3.Program;

namespace BlackJack3
{
    public class Players
    {
        public string name { get; set; }

        public List<Card> PlayersCards = new List<Card>();

        public string ShowMePlayersCards()

        {
            var cardDisplay = $"{name} Cards are: ";

            foreach (var card in PlayersCards)
            {
                cardDisplay += $" {card}";
            }
            return cardDisplay;
        }
                                                
        public void AddCardToHand(Card cardToAdd)
        {
           PlayersCards.Add(cardToAdd);
        }

        public int GetPlayersTotal()              // common way to access items in list
        {
            var cardValueTotal = 0;
            var aceTotal = 0;

            foreach (var item in PlayersCards)
            {
                cardValueTotal += item.cardValue;
                aceTotal += item.cardValue == 11 ? 1 : 0; // Ternary
            }


            if (cardValueTotal > 21)
            {
                while (cardValueTotal > 21 && aceTotal > 0)
                {
                    cardValueTotal -= 10;
                    aceTotal -= 1;
                }
            }
            return cardValueTotal;
        }
    }
}
