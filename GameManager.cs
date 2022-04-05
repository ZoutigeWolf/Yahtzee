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

        private static int _currentPlayerIndex = 0;

        public static Dice Dice { get; private set; } = new Dice(5);


        static void Main()
        {
            Console.Clear();

            AddPlayers();

            _currentPlayerIndex = new Random().Next(players.Count);

            while (true)
            {
                NextPlayer();
            }
        }   

        static void AddPlayers()
        {
            if (players.Count > 0)
            {
                return;
            }

            Console.Clear();
            
            Console.WriteLine("How many players?");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Clear();
                
                Console.WriteLine($"Enter the name for player {i + 1} (enter 'cpu' for a bot player)");
                string? playerName = Console.ReadLine();

                if (playerName == null || string.IsNullOrEmpty(playerName))
                {
                    playerName = $"Player {i + 1}";
                }

                Player player = playerName.ToLower() == "cpu" ? new UserPlayer(playerName) : new UserPlayer(playerName);
                
                players.Add(player);
            }

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
            players[_currentPlayerIndex].PlayTurn();

            if (_currentPlayerIndex >= players.Count)
            {
                _currentPlayerIndex = 0;
            }
            
            _currentPlayerIndex++;
        }

    }
}