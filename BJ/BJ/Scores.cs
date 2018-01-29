using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Scores
    {
        ConsoleOutput consoleOutput = new ConsoleOutput();
        Dealer _dealer;
        private int _cardValue = 2;
        Dictionary<CardType, int> _cardsValue = new Dictionary<CardType, int>();

        public Scores(Dealer dealer)
        {
            _dealer = dealer;
            _dealer.CardReceived += AddScores;

            for (int i = 1; i < 13; i++)
            {
                _cardsValue.Add((CardType)i, _cardValue);
                if (_cardValue < 10)
                {
                    _cardValue++;
                }               
            }
        }

        
              
        public void AddScores(Player character, CardType cardType)
        {
            _cardsValue[CardType.Ace] = 1;
            if (character.CurrentPoints < 11)
            {
                _cardsValue[CardType.Ace] = 11;
            }
            character.CurrentPoints += _cardsValue[cardType];
            consoleOutput.ShowWhatCardTaken(character.PlayerType, cardType, _cardsValue[cardType]);
            CheckScores(character);
        }

        public void CheckScores(Player character)
        {
            consoleOutput.ShowScoresHas(character.PlayerType, character.CurrentPoints);
            if (character.CurrentPoints > 21)
            {
                consoleOutput.ShowBustsMessage(character.PlayerType);
                return;
            }
        }

        public PlayerType CheckFinalScores(int playerPoints, int botPoints)
        {
            if (playerPoints > Values.scoreLimit)
            {
                consoleOutput.ShowPlayerLostMessage();
                return PlayerType.Bot;
            }
            if (playerPoints > botPoints || botPoints > Values.scoreLimit)
            {
                consoleOutput.ShowPlayerWonMessage();
                return PlayerType.User;
            }
            consoleOutput.ShowPlayerLostMessage();
            return PlayerType.Bot;
        }
    }
}
