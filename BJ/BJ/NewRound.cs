using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class NewRound
    {
        private Disrtibution _disrtibution = new Disrtibution();
       
        public void StartTheGame()
        {        
            if (ConsoleOutput.AskForBeginning())
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
            if (ConsoleOutput.AskForNewRound())
            {
                InitiateNewRound();
                return;
            }
            ConsoleOutput.ShowEndGameMessage();
        }
        
        private void CheckMoneyAmount(Player player, Player bot)
        {
            if (player.Money < GameValues.minimumMoneyAllowed)
            {
                ConsoleOutput.ShowPlayerLostMessage();
                return;
            }

            if (bot.Money < GameValues.minimumMoneyAllowed)
            {
                ConsoleOutput.ShowPlayerWinMessage();
                return;
            }
            AskForNewRound();
        }
    }
}
