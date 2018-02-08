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
        public int CardValue { get; set; } = GameValues.cardSmallestValue;

        public Card(CardType cardType)
        {
            this.CardType = cardType;
            GetCardValue();
        }

        private void GetCardValue()
        {
            for (int i = 1; i < GameValues.cardsTillAceNum; i++)
            {
                if (CardType == (CardType)i)
                {
                    return;
                }
                if (CardValue < GameValues.cardValueMax)
                {
                    CardValue++;
                }
            }
            CardValue = GameValues.aceHighValue;
        }
    }
}
