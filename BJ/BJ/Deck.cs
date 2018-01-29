using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Deck
    {
        List<CardType> cardsList = new List<CardType>();

        public List<CardType> GetDeck()
        {
            GenerateDeck();
            return cardsList;
        }

        private void GenerateDeck()
        {
            for (int i = 1; i < Values.cardsTypes; i++)
            {
                cardsList.AddRange(GenerateCardType(i));
            }
        }

        private List<CardType> GenerateCardType(int cardTypeNum)
        {
            var cardsOfAType = new List<CardType>();
            
            for (int i = 0; i < Values.cardsInType; i++)
            {
                cardsOfAType.Add((CardType)cardTypeNum);
            }
            return cardsOfAType;
        }
    }
}
