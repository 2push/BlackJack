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
        Player _player = new Player(PlayerType.User);
        Player _bot = new Player(PlayerType.Bot);
        Random _rnd = new Random(); //bot's decision

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

        public void Start(out Player player, out Player bot)
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
            while (BotsDecision())
            {
                GetCard(_bot);
            }
            CheckFinalScores();
        }

        private bool BotsDecision()
        {
            return Convert.ToBoolean(rnd.Next(2));
        }

        private void GetFirstTwoCards(Player character)
        {
            for (int i = 0; i < 2; i++)
            {
                GetCard(character);
            }
        }

        private void GetCard(Player character)
        {
            _randomElementIndex = rnd.Next(_cards.Count);
            character.Cards.Add(_cards[_randomElementIndex]);
            _cards.RemoveAt(_randomElementIndex);
            AddScores(character, character.Cards.Last());
        }       

        private void AddScores(Player character, CardType cardType)
        {
            cardsValue[CardType.Ace] = 1;
            if (character.CurrentPoints < 11)
            {
                cardsValue[CardType.Ace] = 11;
            }
            character.CurrentPoints += cardsValue[cardType];
            Console.WriteLine(String.Format("{0} has taken one card, which is {1} for {2} points.", character.PlayerType, cardType,cardsValue[cardType]));
            CheckScores(character); 
        }

        private void CheckScores(Player character)
        {
            Console.WriteLine(String.Format("{0} has {1} points", character.PlayerType, character.CurrentPoints));
            if (character.CurrentPoints > 21)
            {
                Console.WriteLine(String.Format("{0} busts!", character.PlayerType));
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
            Console.WriteLine(String.Format("{0} has {1} money", _player.PlayerType, _player.Money));
            Console.WriteLine(String.Format("{0} has {1} money", _bot.PlayerType, _bot.Money));
        }

        private void TransferMoneyToWinner(Player character)
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
