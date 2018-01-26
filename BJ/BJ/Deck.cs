using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Deck
    {
        List<CardType> cards = new List<CardType>();

        public List<CardType> GetDeck()
        {
            GenerateDeck();
            return cards;
        }

        private void GenerateDeck()
        {
            for (int i = 1; i < 14; i++)
            {
                cards.AddRange(GenerateCardType(i));
            }
        }

        private List<CardType> GenerateCardType(int cardTypeNum)
        {
            var cardsOfAType = new List<CardType>();
            
            for (int i = 0; i < 4; i++)
            {
                cardsOfAType.Add((CardType)cardTypeNum);
            }
            return cardsOfAType;
        }
    }
}
