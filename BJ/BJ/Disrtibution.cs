using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Disrtibution
    {
        Player _player = new Player(PlayerType.User);
        Player _bot = new Player(PlayerType.Bot);
        Random rnd = new Random(); //bot's decision
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
            ConsoleOutput.AnnounceMoneyAmount(_player, _bot);
            DoPlayersTurn(_player);
            DoPlayersTurn(_bot);
            TransferMoneyToWinner(scores.CheckFinalScores(ref _player,ref _bot));
            player = _player;
            bot = _bot;
        }       

        private void DoPlayersTurn(Player player)
        {
            ConsoleOutput.ShowTurnMessage(player.PlayerType);
            dealer.GetFirstTwoCards(ref player);             
            while (player.PlayerType is PlayerType.User ? ConsoleOutput.AskForNewCard() : BotsDecision())
            {            
                dealer.GetCard(ref player);
            }            
        }

        private bool BotsDecision()
        {
            return Convert.ToBoolean(rnd.Next(GameValues.randomBoolRange));
        }

        private void TransferMoneyToWinner(PlayerType characterType)
        {
            if (characterType is PlayerType.User)
            {
                _bot.Money = _bot.Money - GameValues.moneyTransfer;
                _player.Money = _player.Money + GameValues.moneyTransfer;
                return;
            }
            _bot.Money += GameValues.moneyTransfer;
            _player.Money -= GameValues.moneyTransfer;          
        }       
    }
}