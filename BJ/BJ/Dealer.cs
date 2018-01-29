using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Dealer
    {
        private int _randomElementIndex;
        Deck _deck = new Deck();
        private List<CardType> _cardsList;
        private Stack<CardType> _cardsStack;
        Random rnd = new Random();
        public delegate void AddingScores(Player player, CardType cardType);
        public event AddingScores CardReceived;

        public Dealer()
        {
            _cardsList = _deck.GetDeck();
            SortDeck();
            _cardsStack = new Stack<CardType>(_cardsList);
        }

        public void GetFirstTwoCards(ref Player character)
        {
            for (int i = 0; i < 2; i++)
            {
                GetCard(ref character);
            }
        }

        public void GetCard(ref Player character)
        {
            character.Cards.Add(_cardsStack.Pop());
            if (CardReceived != null)
            {
                CardReceived(character, character.Cards.Last());
            }
        }

        private void SortDeck()
        {
            for (int i = 0; i < _cardsList.Count; i++)
            {
                CardType tmp = _cardsList[0];
                _cardsList.RemoveAt(0);
                _cardsList.Insert(rnd.Next(_cardsList.Count), tmp);
            }
        }     
    }
}