using FTCtest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTCtest.Players
{
    internal class HumanPlayer : IPlayer
    {
        public int[] GenerateSecretNumber()
        {
            int[] secretNumber = new int[4];
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int digit;
                do
                {
                    digit = random.Next(0, 10);
                } while (Array.IndexOf(secretNumber, digit) != -1);

                secretNumber[i] = digit;
            }

            return secretNumber;
        }

        public int[] MakeGuess()
        {
            Random random = new Random();
            int[] guess = new int[4];

            for (int i = 0; i < 4; i++)
            {
                guess[i] = random.Next(0, 10);
            }

            return guess;
        }
        public bool ProvideFeedback(int bulls, int cows)
        {
            return bulls == 4 && cows == 4;
        }
    }
}
