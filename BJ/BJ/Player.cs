using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Player : ICharacter
    {
        public int CurrentPoints { get; set; }
        public int Money { get; set; } = 100;
        public List<CardType> Cards { get; set; }
        public int Victories { get; set; }

        public override string ToString()
        {
            return ("Player");
        }
    }
}
