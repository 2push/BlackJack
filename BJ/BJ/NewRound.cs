using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class NewRound
    {
        private ConsoleOutput _textOutput = new ConsoleOutput();
        private Disrtibution _disrtibution = new Disrtibution();
       
        public void StartTheGame()
        {        
            if (_textOutput.AskForBeginning())
            {
                InitiateNewRound();
            }
        }

        public void InitiateNewRound()
        {           
            _disrtibution.Start(out Player player, out Player bot);
            CheckMoneyAmount(player, bot);
        }
       
        private void AskForNewRound()
        {          
            if (_textOutput.AskForNewRound())
            {
                InitiateNewRound();
                return;
            }
            _textOutput.ShowEndGameMessage();
        }
        
        private void CheckMoneyAmount(Player player, Player bot)
        {
            if (player.Money < 19)
            {
                _textOutput.ShowPlayerLostMessage();
                return;
            }

            if (bot.Money < 19)
            {
                _textOutput.ShowPlayerWonMessage();
                return;
            }
            AskForNewRound();
        }
    }
}
