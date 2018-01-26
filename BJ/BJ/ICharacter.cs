using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    interface ICharacter
    {
        int CurrentPoints { get; set; }
        int Money { get; set; }
        int Victories { get; set; }
        List<CardType> Cards { get; set; }
        string ToString();
    }
}
