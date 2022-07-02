using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack3
{
    public class Card
    {
        public string cardName { get; set; }
        public int cardValue { get; set; }

        public Card(string cardName, int cardValue)
        {
            this.cardName = cardName;
            this.cardValue = cardValue;
        }

        public override string ToString()
        {
            return cardName;
        }
    }
}
