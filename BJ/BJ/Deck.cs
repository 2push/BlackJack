using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Deck
    {
        private List<Card> _cardsList = new List<Card>();
        private int _typeIterator;
        public List<Card> GetDeck()
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
                _cardsList.Add(new Card((CardType)_typeIterator));
            }
        }
    }
}
