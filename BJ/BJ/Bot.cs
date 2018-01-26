using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class Bot : ICharacter
    {
        Random rnd = new Random();

        public int CurrentPoints { get; set; }
        public int Money { get; set; } = 1500;
        public int Victories { get; set; }
        public List<CardType> Cards { get; set; }

        public bool Decision()
        {
            return Convert.ToBoolean(rnd.Next(2));
        }

        public override string ToString()
        {
            return ("Computer");
        }
    }
}
