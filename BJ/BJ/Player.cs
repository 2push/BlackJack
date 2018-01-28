using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Player 
    {
        public PlayerType PlayerType { get; private set; }
        public int CurrentPoints { get; set; }
        public int Money { get; set; } = 100;
        public List<CardType> Cards { get; set; }
        public int Victories { get; set; }

        public Player(PlayerType playerType)
        {
            PlayerType = playerType;
            if (playerType == PlayerType.User)
            {
                Money = 100;
            }
            if (playerType == PlayerType.Bot)
            {
                Money = 1500;
            }
        }
    }
}
