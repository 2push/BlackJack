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
        private Stack<Card> _cardsStack;
        private Random _random = new Random();
        private Scores _scores = new Scores();

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
            _scores.AddScores(character, character.Cards.Last());
        }

        private Stack<Card> SortDeck(List<Card> listOfCards)
        {
            listOfCards = listOfCards.ToArray().OrderBy(x => _random.Next()).ToList<Card>();
            return new Stack<Card>(listOfCards);
        }
    }
}