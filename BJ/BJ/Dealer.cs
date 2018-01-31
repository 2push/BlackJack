using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Dealer
    {
        private Deck _deck = new Deck();
        private Stack<CardType> _cardsStack;
        private Random _rnd = new Random();
        public delegate void AddingScores(Player player, CardType cardType);
        public event AddingScores CardReceived;

        public Dealer()
        {
            _cardsStack = SortDeck(_deck.GetDeck());          
        }

        public void GetFirstCards(ref Player character)
        {
            for (int i = 0; i < GameValues.amountOfFirstCards; i++)
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

        public Stack<CardType> SortDeck(List<CardType> listOfCards)
        {
            int n = listOfCards.Count;
            while (n > 1)
            {
                n--;
                int k = _rnd.Next(n + 1);
                CardType value = listOfCards[k];
                listOfCards[k] = listOfCards[n];
                listOfCards[n] = value;
            }
            return new Stack<CardType>(listOfCards);
        }
    }
}