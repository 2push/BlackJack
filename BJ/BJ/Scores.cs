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
        private int _cardValue = 2;
        private Dictionary<CardType, int> _cardsValue = new Dictionary<CardType, int>();

        public Scores(Dealer dealer)
        {
            _dealer = dealer;
            _dealer.CardReceived += AddScores;

            for (int i = 1; i < GameValues.cardsTillAceNum; i++)
            {
                _cardsValue.Add((CardType)i, _cardValue);
                if (_cardValue < GameValues.cardValueMax)
                {
                    _cardValue++;
                }               
            }
        }
         
        public void AddScores(Player character, CardType cardType)
        {
            _cardsValue[CardType.Ace] = GameValues.aceLowValue;
            if (character.CurrentPoints < GameValues.aceHighValue)
            {
                _cardsValue[CardType.Ace] = GameValues.aceHighValue;
            }
            character.CurrentPoints += _cardsValue[cardType];
            ConsoleOutput.ShowWhatCardTaken(character.PlayerType, cardType, _cardsValue[cardType]);
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

        public PlayerType CheckFinalScores(ref Player user, ref Player bot)
        {
            if (user.CurrentPoints > GameValues.scoreLimit)
            {
                ConsoleOutput.ShowPlayerLostMessage();
                RefreshScores(ref user, ref bot);
                return PlayerType.Bot;
            }
            if (user.CurrentPoints > bot.CurrentPoints || bot.CurrentPoints > GameValues.scoreLimit)
            {
                ConsoleOutput.ShowPlayerWonMessage();
                RefreshScores(ref user, ref bot);
                return PlayerType.User;
            }
            ConsoleOutput.ShowPlayerLostMessage();
            RefreshScores(ref user, ref bot);
            return PlayerType.Bot;
        }

        private void RefreshScores(ref Player user, ref Player bot)
        {
            user.CurrentPoints = 0;
            bot.CurrentPoints = 0;
        }
    }
}
