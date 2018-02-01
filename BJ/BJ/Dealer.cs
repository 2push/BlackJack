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
        private Random _random = new Random();
        public delegate void AddingScores(Player player, CardType cardType);
        public event AddingScores CardReceived;

        public Dealer()
        {
            _cardsStack = SortDeck(_deck.GetDeck());          
        }

        public void GetFirstCards(Player character)
        {
            for (int i = 0; i < GameValues.amountOfFirstCards; i++)
            {
                GetCard(character);
            }
        }

        public void GetCard(Player character)
        {
            character.Cards.Add(_cardsStack.Pop());
            if (CardReceived != null)
            {
                CardReceived(character, character.Cards.Last());
            }
        }

        private Stack<CardType> SortDeck(List<CardType> listOfCards)
        {
            listOfCards = listOfCards.ToArray().OrderBy(x => _random.Next()).ToList<CardType>();
            return new Stack<CardType>(listOfCards);
        }
    }
}