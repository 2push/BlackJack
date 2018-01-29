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
        ConsoleOutput consoleOutput = new ConsoleOutput();
        Dealer dealer = new Dealer();
        Scores scores;
             
        public Disrtibution()
        {
            scores = new Scores(dealer);
        }

        public void Start(out Player player, out Player bot)
        {    
            _player.Cards = new List<CardType>();
            _bot.Cards = new List<CardType>();
            RefreshPoints();
            consoleOutput.AnnounceMoneyAmount(_player, _bot);
            DoPlayersTurn();
            DoBotsTurn();
            TransferMoneyToWinner(scores.CheckFinalScores(_player.CurrentPoints, _bot.CurrentPoints));
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
            consoleOutput.ShowYourTurnMessage();
            dealer.GetFirstTwoCards(ref _player);      
            while (consoleOutput.AskForNewCard())
            {            
                dealer.GetCard(ref _player);
            }            
        }

        private void DoBotsTurn()
        {
            consoleOutput.ShowBotsTurnMessage();
            dealer.GetFirstTwoCards(ref _bot);
            while (BotsDecision())
            {
                dealer.GetCard(ref _bot);
            }          
        }

        private bool BotsDecision()
        {
            return Convert.ToBoolean(rnd.Next(2));
        }

        private void TransferMoneyToWinner(PlayerType characterType)
        {
            if (characterType is PlayerType.User)
            {
                _bot.Money = _bot.Money - Values.moneyTransfer;
                _player.Money = _player.Money + Values.moneyTransfer;
                return;
            }
            _bot.Money += Values.moneyTransfer;
            _player.Money -= Values.moneyTransfer;          
        }       
    }
}