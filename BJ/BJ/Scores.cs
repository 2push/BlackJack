using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Scores
    {
        public void AddScores(Player character, Card card)
        {
            character.Cards.ForEach(x =>
            {
                if (x.CardType is CardType.Ace && character.CurrentPoints > GameValues.scoreLimitToLowAce)
                {
                    x.CardValue = GameValues.aceLowValue;
                }
            });
            character.CurrentPoints = character.Cards.Sum(x => x.CardValue);
            ConsoleOutput.ShowWhatCardTaken(character.PlayerType, card);
            CheckScores(character);
        }
       
        public void CheckScores(Player character)
        {
            ConsoleOutput.ShowScoresHas(character.PlayerType, character.CurrentPoints);
            if (character.CurrentPoints > GameValues.scoreLimit)
            {
                ConsoleOutput.ShowBustsMessage(character.PlayerType);
                return;
            }
        }

        public PlayerType CheckFinalScores(Player user, Player bot)
        {
            if (user.CurrentPoints > GameValues.scoreLimit)
            {
                ConsoleOutput.ShowPlayerLostMessage();
                RefreshScores(user, bot);
                return PlayerType.Bot;
            }
            if (user.CurrentPoints > bot.CurrentPoints || bot.CurrentPoints > GameValues.scoreLimit)
            {
                ConsoleOutput.ShowPlayerWinMessage();
                RefreshScores(user, bot);
                return PlayerType.User;
            }
            ConsoleOutput.ShowPlayerLostMessage();
            RefreshScores(user, bot);
            return PlayerType.Bot;
        }

        private void RefreshScores(Player user, Player bot)
        {
            user.CurrentPoints = 0;
            bot.CurrentPoints = 0;
        }
    }
}
