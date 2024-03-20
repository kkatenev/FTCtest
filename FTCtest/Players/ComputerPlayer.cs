using FTCtest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTCtest.Players
{
    internal class ComputerPlayer : IPlayer
    {
        public int[] GenerateSecretNumber()
        {
            Console.WriteLine("Вам загадано 4-значное число с неповторяющимися цифрами.");
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
            Console.WriteLine("Введите вашу попытку (четыре неповторяющиеся цифры):");
            string input = Console.ReadLine();
            int[] guess = Array.ConvertAll(input.ToCharArray(), c => (int)Char.GetNumericValue(c));
            return guess;
        }
        public bool ProvideFeedback(int bulls, int cows)
        {
            Console.WriteLine($"Быков: {bulls}, коров: {cows}");

            return bulls == 4 && cows == 4;
        }
    }
}
