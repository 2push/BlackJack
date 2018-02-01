using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Disrtibution
    {
        private Player _player = new Player(PlayerType.User);
        private Player _bot = new Player(PlayerType.Bot);
        private Random _random = new Random(); //bot's decision
        private Dealer _dealer = new Dealer();
        private Scores _scores;

        public Disrtibution()
        {
            _scores = new Scores(_dealer);
        }

        public void Start(out Player player, out Player bot)
        {    
            _player.Cards = new List<CardType>();
            _bot.Cards = new List<CardType>();
            ConsoleOutput.AnnounceMoneyAmount(_player, _bot);
            DoPlayersTurn(_player);
            DoPlayersTurn(_bot);
            TransferMoneyToWinner(_scores.CheckFinalScores(_player,_bot));
            player = _player;
            bot = _bot;
        }       

        private void DoPlayersTurn(Player player)
        {
            ConsoleOutput.ShowTurnMessage(player.PlayerType);
            _dealer.GetFirstCards(player);             
            while (player.PlayerType is PlayerType.User ? ConsoleOutput.AskForNewCard() : BotsDecision())
            {            
                _dealer.GetCard(player);
            }            
        }

        private bool BotsDecision()
        {
            return Convert.ToBoolean(_random.Next(GameValues.randomBoolRange));
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