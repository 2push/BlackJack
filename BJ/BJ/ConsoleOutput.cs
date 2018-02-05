using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal static class ConsoleOutput
    {
        public static bool AskForBeginning()
        {
            Console.WriteLine("G'day!Let's begin? Yes/no");
            return Console.ReadLine() == Answer.Yes.ToString();
        }

        public static bool AskForNewRound()
        {
            Console.WriteLine("One more round? Yes/no");
            return Console.ReadLine() == Answer.Yes.ToString(); 
        }

        public static void ShowEndGameMessage()
        {
            Console.WriteLine("Thanks for the game");
            Console.ReadKey();
        }

        public static void ShowPlayerLostMessage()
        {
            Console.WriteLine("Player lost");
        }

        public static void ShowPlayerWinMessage()
        {
            Console.WriteLine("Player won");
        }

        public static void ShowTurnMessage(PlayerType playerType)
        {
            Console.WriteLine(String.Format("{0}'s turn", playerType));
        }

        public static bool AskForNewCard()
        {
            Console.WriteLine("More? Yes/no");
            return Console.ReadLine() == Answer.Yes.ToString();
        }

        public static void ShowWhatCardTaken(PlayerType playerType, Card card)
        {
            Console.WriteLine(String.Format("{0} has taken one card, which is {1} for {2} points.", playerType, card.CardType, card.CardValue));
        }

        public static void ShowScoresHas(PlayerType playerType, int currentPoints)
        {
            Console.WriteLine(String.Format("{0} has {1} points", playerType, currentPoints));
        }

        public static void ShowBustsMessage(PlayerType playerType)
        {
            Console.WriteLine(String.Format("{0} busts!", playerType));
        }

        public static void AnnounceMoneyAmount(Player user, Player bot)
        {
            Console.WriteLine(String.Format("{0} has {1} money", user.PlayerType, user.Money));
            Console.WriteLine(String.Format("{0} has {1} money", bot.PlayerType, bot.Money));
        }
    }
}
