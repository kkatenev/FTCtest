using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTCtest.Interfaces
{
    internal interface IPlayer
    {
        int[] GenerateSecretNumber();
        int[] MakeGuess();
        bool ProvideFeedback(int bulls, int cows);
    }
}
