using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Card
    {
        public CardType CardType { get; set; }
        public int CardValue { get; set; }

        public Card(CardType cardType)
        {
            this.CardType = cardType;
        }        
    }
}
