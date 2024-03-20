using FTCtest.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTCtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new BullsAndCows();
            game.Start();
        }
    }
}
