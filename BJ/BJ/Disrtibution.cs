using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Disrtibution
    {
        Player _player = new Player(PlayerType.User);
        Player _bot = new Player(PlayerType.Bot);
        Random rnd = new Random(); //bot's decision
        TextOutput textOutput = new TextOutput();
        Dealer dealer = new Dealer();
        
        Dictionary<CardType, int> cardsValue = new Dictionary<CardType, int>
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

        public Disrtibution()
        {
            dealer.CardReceived += AddScores;
        }

        public void Start(out Player player, out Player bot)
        {          
            _player.Cards = new List<CardType>();
            _bot.Cards = new List<CardType>();
            RefreshPoints();
            textOutput.AnnounceMoneyAmount(_player, _bot);
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
            textOutput.ShowYourTurnMessage();
            dealer.GetFirstTwoCards(ref _player);      
            while (textOutput.AskForNewCard())
            {            
                dealer.GetCard(ref _player);
            }            
        }

        private void DoBotsTurn()
        {
            textOutput.ShowBotsTurnMessage();
            dealer.GetFirstTwoCards(ref _bot);
            while (BotsDecision())
            {
                dealer.GetCard(ref _bot);
            }
            CheckFinalScores();
        }

        private bool BotsDecision()
        {
            return Convert.ToBoolean(rnd.Next(2));
        }

        private void AddScores(Player character, CardType cardType)
        {
            cardsValue[CardType.Ace] = 1;
            if (character.CurrentPoints < 11)
            {
                cardsValue[CardType.Ace] = 11;
            }
            character.CurrentPoints += cardsValue[cardType];
            textOutput.ShowWhatCardTaken(character.PlayerType, cardType, cardsValue[cardType]);
            CheckScores(character); 
        }

        private void CheckScores(Player character)
        {
            textOutput.ShowScoresHas(character.PlayerType, character.CurrentPoints);
            if (character.CurrentPoints > 21)
            {
                textOutput.ShowBustsMessage(character.PlayerType);
                return;
            }           
        }

        private void CheckFinalScores()
        {
            if (_player.CurrentPoints > 21)
            {
                textOutput.ShowPlayerLostMessage();
                TransferMoneyToWinner(_bot);
                return;                 
            }
            if (_player.CurrentPoints > _bot.CurrentPoints || _bot.CurrentPoints > 21)
            {
                textOutput.ShowPlayerWonMessage();
                TransferMoneyToWinner(_player);
                return;
            }
            textOutput.ShowPlayerLostMessage();
            TransferMoneyToWinner(_bot);
        }

        private void TransferMoneyToWinner(Player character)
        {
            if (character.PlayerType is PlayerType.User)
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
