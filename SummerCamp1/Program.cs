using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerCamp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit warrior1 = new Unit("Вася", 100, 20, 40, Factions.Good, false);
            Unit warrior2 = new Unit("Викинг", 200, 100, 10, Factions.Good, true);


            warrior1.Attack(warrior2);
            warrior2.Attack(warrior1);
        }
    }

    
}
