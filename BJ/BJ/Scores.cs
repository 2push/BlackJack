using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Scores
    {
        private int _cardValue;
        public void AddScores(Player character, Card card)
        {
            _cardValue = GameValues.cardSmallestValue;
            character.CurrentPoints += GetCardValue(character.CurrentPoints, card);
            ConsoleOutput.ShowWhatCardTaken(character.PlayerType, card);
            CheckScores(character);
        }

        public int GetCardValue(int playerScore, Card card)
        {
            for (int i = 1; i < GameValues.cardsTillAceNum; i++)
            {
                if (card.CardType == (CardType)i)
                {
                    card.CardValue = _cardValue;
                    return card.CardValue;
                }
                if (_cardValue < GameValues.cardValueMax)
                {
                    _cardValue++;
                }
            }
            if (playerScore > GameValues.scoreLimitToHighAce)
            {
                card.CardValue = GameValues.aceLowValue;
                return card.CardValue;
            }
            card.CardValue = GameValues.aceHighValue;
            return card.CardValue;
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
