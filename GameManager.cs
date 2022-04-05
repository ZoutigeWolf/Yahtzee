using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    internal static class GameManager
    {
        public static List<Player> players = new List<Player>();
        private static bool _playersAdded = false;

        private static int _currentPlayerIndex = 0;

        public static Dice Dice { get; private set; } = new Dice(5);

        static void Main()
        {
            Console.WriteLine("Enter 1 for the test, nothing for the game");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                int[] test = new int[] { 2, 2, 3, 3, 3 };

                Console.WriteLine(test.ContainsNTimes(2) && test.ContainsNTimes(3));

                return;
            }

            Console.Clear();

            AddPlayers();

            _currentPlayerIndex = new Random().Next(players.Count);
        }

        static void AddPlayers()
        {
            if (_playersAdded)
                return;

            Console.Clear();
            
            Console.WriteLine("How many players?");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Clear();
                
                Console.WriteLine($"Enter the name for player {i + 1}");
                string? playerName = Console.ReadLine();

                if (playerName == null || string.IsNullOrEmpty(playerName))
                {
                    playerName = $"Player {i + 1}";
                }

                Player player = new Player(playerName);
                players.Add(player);
            }

            _playersAdded = true;

            Console.Clear();

            Console.WriteLine("Players:");

            foreach (Player player in players)
            {
                Console.WriteLine(player.Name);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.Clear();
        }

        static void NextPlayer()
        {
            _currentPlayerIndex++;

            if (_currentPlayerIndex >= players.Count)
            {
                _currentPlayerIndex = 0;
            }
        }

        static void StartTurn()
        {
            Console.Clear();

            Console.WriteLine($"{players[_currentPlayerIndex].Name}'s turn");
            Console.WriteLine("Press any key to roll the dice");
            Console.ReadKey();

            Console.Clear();
            
            Console.WriteLine("Dice:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}: {Dice.Values[i]}");
            }

            Console.WriteLine("Enter the values of the dice you want to keep separated by a space");
            string? diceToKeep = Console.ReadLine();

            if (diceToKeep != null && !string.IsNullOrEmpty(diceToKeep))
            {
                int[] values = Array.ConvertAll(diceToKeep.Split(" "), s => int.Parse(s));
                Dice.KeepValues(values);
            }

            // Test
        }
    }
}