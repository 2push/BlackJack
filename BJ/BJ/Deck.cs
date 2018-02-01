using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Deck
    {
        private List<CardType> _cardsList = new List<CardType>();
        private int _typeIterator = GameValues.firstTypeOfCardsToGenerate;
        public List<CardType> GetDeck()
        {
            GenerateDeck();
            return _cardsList;
        }

        private void GenerateDeck()
        {
            for (int i = 0; i < GameValues.amountOfCards; i++)
            {
                if (i % GameValues.cardsInType == 0)
                {
                    _typeIterator++;
                }
                _cardsList.Add((CardType)_typeIterator);
            }
        }
    }
}
