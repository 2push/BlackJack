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
        private List<CardType> _cards;
        Random rnd = new Random();
        public delegate void AddingScores(Player player, CardType cardType);
        public event AddingScores CardReceived;

        public Dealer()
        {
            _cards = _deck.GetDeck();
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
            _randomElementIndex = rnd.Next(_cards.Count);
            character.Cards.Add(_cards[_randomElementIndex]);
            _cards.RemoveAt(_randomElementIndex);
            if (CardReceived != null)
            {
                CardReceived(character, character.Cards.Last());
            }
        }
    }
}