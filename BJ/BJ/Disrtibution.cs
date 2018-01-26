using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Disrtibution
    {
        Deck _deck = new Deck();
        Player _player = new Player();
        Bot _bot = new Bot();

        private List<CardType> _cards;
        private int _randomElementIndex;
        Random rnd = new Random();
        Dictionary<CardType, int> cardsValue = new Dictionary<CardType, int>()
            {
                {CardType.Two, 2},
                {CardType.Three, 3},
                {CardType.Four, 4},
                {CardType.Five, 5},
                {CardType.Six, 6},
                {CardType.Seven, 7},
                {CardType.Eight, 8},
                {CardType.Nine, 9},
                {CardType.Ten, 10},
                {CardType.Jack, 10},
                {CardType.Queen, 10},
                {CardType.King, 10}
            };

        public void Start(out ICharacter player, out ICharacter bot)
        {
            _cards = _deck.GetDeck();
            _player.Cards = new List<CardType>();
            _bot.Cards = new List<CardType>();
            RefreshPoints();
            AnnounceMoneyAmount();
            DoPlayersTurn();
            DoBotsTurn();
            player = _player;
            bot = _bot;
        }

        private void RefreshPoints()
        {
            _player.CurrentPoints = 0;
            _bot.CurrentPoints = 0;
        }

        private void DoPlayersTurn()
        {
            Console.WriteLine("Your turn");
            GetFirstTwoCards(_player);
            Console.WriteLine("More? y/n");
            while (Console.ReadLine() == "y")
            {            
                GetCard(_player);
            }
            
        }

        private void DoBotsTurn()
        {
            Console.WriteLine("Bot's turn");
            GetFirstTwoCards(_bot);
            while (_bot.Decision())
            {
                GetCard(_bot);
            }
            CheckFinalScores();
        }

        private void GetFirstTwoCards(ICharacter character)
        {
            for (int i = 0; i < 2; i++)
            {
                GetCard(character);
            }
        }

        private void GetCard(ICharacter character)
        {
            _randomElementIndex = rnd.Next(_cards.Count);
            character.Cards.Add(_cards[_randomElementIndex]);
            _cards.RemoveAt(_randomElementIndex);
            AddScores(character, character.Cards.Last());
        }       

        private void AddScores(ICharacter character, CardType cardType)
        {
            cardsValue[CardType.Ace] = 1;
            if (character.CurrentPoints < 11)
            {
                cardsValue[CardType.Ace] = 11;
            }
            character.CurrentPoints += cardsValue[cardType];
            Console.WriteLine(String.Format("{0} has taken one card, which is {1} for {2} points.", character.ToString(), cardType,cardsValue[cardType]));
            CheckScores(character); 
        }

        private void CheckScores(ICharacter character)
        {
            Console.WriteLine(String.Format("{0} has {1} points", character.ToString(), character.CurrentPoints));
            if (character.CurrentPoints > 21)
            {
                Console.WriteLine(String.Format("{0} busts!", character.ToString()));
                return;
            }           
        }

        private void CheckFinalScores()
        {
            if (_player.CurrentPoints > 21)
            {
                Console.WriteLine("Computer has won!");
                TransferMoneyToWinner(_bot);
                return;                 
            }
            if (_player.CurrentPoints > _bot.CurrentPoints || _bot.CurrentPoints > 21)
            {
                Console.WriteLine("Player has won!");
                TransferMoneyToWinner(_player);
                return;
            }
            Console.WriteLine("Computer has won!");
            TransferMoneyToWinner(_bot);
        }

        private void AnnounceMoneyAmount()
        {
            Console.WriteLine(String.Format("{0} has {1} money", _player.ToString(), _player.Money));
            Console.WriteLine(String.Format("{0} has {1} money", _bot.ToString(), _bot.Money));
        }

        private void TransferMoneyToWinner(ICharacter character)
        {
            if (character is Player)
            {
                _bot.Money = _bot.Money - 20;
                _player.Money = _player.Money + 20;
                return;
            }
            _bot.Money += 20;
            _player.Money -= 20;          
        }       
    }
}
