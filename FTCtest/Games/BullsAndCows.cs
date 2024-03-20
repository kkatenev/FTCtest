using FTCtest.Interfaces;
using FTCtest.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FTCtest
{
    internal class BullsAndCows
    {
        private IPlayer _player;
        private int[] secretNumber;
        private int[] secretNumberFromPlayer;

        public BullsAndCows()
        {
        }

        public void Start()
        {
            int choice = GetChoice(1, 2);

            if (choice == 1)
            {
                _player = new HumanPlayer();
                secretNumberFromPlayer = GetSecretNumberFromPlayer();
                secretNumber = _player.GenerateSecretNumber();
            }
            else
            {
                _player = new ComputerPlayer();
                secretNumber = _player.GenerateSecretNumber();
            }

            int attempts = 0;

            while (true)
            {

                if (PlayerTurn() == true)
                {
                    Console.WriteLine($"Вы угадали число!");
                    Console.WriteLine($"Количество попыток: {attempts}");
                    Console.WriteLine("Нажмите любую кнопку для завершения...");
                    Console.ReadLine();
                    break;
                }

                if (_player is HumanPlayer)
                {
                    if (ComputerTurn() == true)
                    {
                        Console.WriteLine($"Компьютер угадал число быстрее вас!");
                        Console.WriteLine($"Количество попыток: {attempts}");
                        Console.WriteLine("Нажмите любую кнопку для завершения...");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\nКомпьютер делает ход");
                        Console.WriteLine($"Компьютер не угадал число\n");
                    }
                }
                attempts++;
            }
        }

        private bool PlayerTurn()
        {
            var player = new ComputerPlayer();
            int[] guess = player.MakeGuess();

            if (guess.Length != 4 || guess.Any(x => x == -1))
            {
                Console.WriteLine("Ошибка! Введите четырехзначное число");
                return false;
            }

            int bulls = CountBulls(guess, secretNumber);
            int cows = CountCows(guess, secretNumber);
            return player.ProvideFeedback(bulls, cows);
        }

        private bool ComputerTurn()
        {
            int[] guess = _player.GenerateSecretNumber();
            int bulls = CountBulls(guess, secretNumberFromPlayer);
            int cows = CountCows(guess, secretNumberFromPlayer);

            return _player.ProvideFeedback(bulls, cows);
        }

        private int[] GetSecretNumberFromPlayer()
        {
            while (true)
            {
                Console.WriteLine("Введите четырехзначное число для соперника:");
                string input = Console.ReadLine();

                if (input.Length != 4 || !input.All(char.IsDigit))
                {
                    Console.WriteLine("Ошибка! Введите четырехзначное число");
                    continue;
                }

                return Array.ConvertAll(input.ToArray(), x => int.Parse(x.ToString()));
            }
        }

        private int CountBulls(int[] guess, int[] secretNumber)
        {
            return guess.Where((x, i) => x == secretNumber[i]).Count();
        }

        private int CountCows(int[] guess, int[] secretNumber)
        {
            return guess.Intersect(secretNumber).Count();
        }

        private int GetChoice(int min, int max)
        {
            Console.WriteLine("Добро пожаловать в игру 'Быки и Коровы'!");
            Console.WriteLine("Выберите режим игры:");
            Console.WriteLine("1. Я задумываю число, а компьютер отгадывает.");
            Console.WriteLine("2. Компьютер задумывает число, а я отгадываю.");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
            {
                Console.WriteLine($"Пожалуйста, введите число от {min} до {max}.");
            }
            return choice;
        }
    }
}
