using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class ConsoleOutput
    {
        public bool AskForBeginning()
        {
            Console.WriteLine("G'day!Let's begin? y/n");
            return Console.ReadLine() == "y";
        }

        public bool AskForNewRound()
        {
            Console.WriteLine("One more round? y/n");
            return Console.ReadLine() == "y"; ;
        }

        public void ShowEndGameMessage()
        {
            Console.WriteLine("Thanks for the game");
            Console.ReadKey();
        }

        public void ShowPlayerLostMessage()
        {
            Console.WriteLine("Player lost");
        }

        public void ShowPlayerWonMessage()
        {
            Console.WriteLine("Player won");
        }

        public void ShowYourTurnMessage()
        {
            Console.WriteLine("Your turn");
        }

        public bool AskForNewCard()
        {
            Console.WriteLine("More? y/n");
            return Console.ReadLine() == "y";
        }

        public void ShowBotsTurnMessage()
        {
            Console.WriteLine("Bot's turn");
        }

        public void ShowWhatCardTaken(PlayerType playerType, CardType cardType, int cardValue)
        {
            Console.WriteLine(String.Format("{0} has taken one card, which is {1} for {2} points.", playerType, cardType, cardValue));
        }

        public void ShowScoresHas(PlayerType playerType, int currentPoints)
        {
            Console.WriteLine(String.Format("{0} has {1} points", playerType, currentPoints));
        }

        public void ShowBustsMessage(PlayerType playerType)
        {
            Console.WriteLine(String.Format("{0} busts!", playerType));
        }

        public void ShowComputerWon()
        {
            Console.WriteLine("Computer has won!");
        }

        public void ShowPlayerWon()
        {
            Console.WriteLine("Player has won!");
        }

        public void AnnounceMoneyAmount(Player user, Player bot)
        {
            Console.WriteLine(String.Format("{0} has {1} money", user.PlayerType, user.Money));
            Console.WriteLine(String.Format("{0} has {1} money", bot.PlayerType, bot.Money));
        }
    }
}
