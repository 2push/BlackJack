using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Scores
    {
        private Dealer _dealer;
        private int _cardValue;

        public Scores(Dealer dealer)
        {
            _dealer = dealer;
            _dealer.CardReceived += AddScores;           
        }
         
        public void AddScores(Player character, CardType cardType)
        {
            _cardValue = GameValues.cardSmallestValue;
            character.CurrentPoints += DefineCardValue(character.CurrentPoints, cardType);
            ConsoleOutput.ShowWhatCardTaken(character.PlayerType, cardType, _cardValue);
            CheckScores(character);
        }

        private int DefineCardValue(int playerScore, CardType card)
        {
            for (int i = 1; i < GameValues.cardsTillAceNum; i++)
            {
                if (card == (CardType)i)
                {
                    return _cardValue;
                }
                if (_cardValue < GameValues.cardValueMax)
                {
                    _cardValue++;
                }
            }
            if (playerScore > GameValues.scoreLimitToHighAce)
            {
                _cardValue = GameValues.aceLowValue;
            }
            _cardValue = GameValues.aceHighValue;
            return _cardValue;
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
                ConsoleOutput.ShowPlayerWonMessage();
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
