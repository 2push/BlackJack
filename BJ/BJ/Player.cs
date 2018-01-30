using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    internal class Player 
    {
        public PlayerType PlayerType { get; private set; }
        public int CurrentPoints { get; set; }
        public int Money { get; set; } 
        public List<CardType> Cards { get; set; }
        public int Victories { get; set; }

        public Player(PlayerType playerType)
        {
            PlayerType = playerType;
            if (playerType == PlayerType.User)
            {
                Money = GameValues.playerMoney;
            }
            if (playerType == PlayerType.Bot)
            {
                Money = GameValues.botMoney;
            }
        }
    }
}
