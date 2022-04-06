using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    internal class UserPlayer : Player
    {    
        public UserPlayer(string name) : base(name)
        {
            
        }

        private Dice _dice = new Dice(5);
        private int _rollsRemaining = 3;

        public override void PlayTurn()
        {
            Console.WriteLine($"{Name}'s turn");

            _dice = new Dice(5);

            _rollsRemaining = 3;

            RollDice();
        }

        private void RollDice()
        {
            Console.WriteLine("Press any key to roll the dice");
            Console.ReadKey();

            Console.Clear();

            _dice.Roll();
            _rollsRemaining--;

            _dice.PrintValues();

            if (_rollsRemaining > 0)
            {
                Console.WriteLine($"Do you want to reroll? {_rollsRemaining} rolls left (y/n)");
                string? reroll = Console.ReadLine();

                if (reroll != null && reroll.ToLower() == "y")
                {
                    Console.Clear();
                    RollDice();
                }
            }

            string[] scoreableCategories = _dice.GetAvailableScores(Points);

            Console.Clear();

            int category;

            _dice.PrintValues();

            while (true)
            {

                Console.WriteLine("Enter the index of the category to score in:");
                for (int i = 0; i < scoreableCategories.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {scoreableCategories[i]}");
                }

                string? categoryInput = Console.ReadLine();

                if (int.TryParse(categoryInput, out int cat))
                {
                    if (cat > 0 && cat <= scoreableCategories.Length + 1)
                    {
                        category = cat - 1;
                        break;
                    }
                }

                Console.WriteLine("Invalid category");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine($"Scored {_dice.GetPoints(scoreableCategories[category])} points in the category {scoreableCategories[category]}");

            switch (scoreableCategories[category])
            {
                case "Ones":
                    Points.ones = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Twos":
                    Points.twos = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Threes":
                    Points.threes = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Fours":
                    Points.fours = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Fives":
                    Points.fives = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Sixes":
                    Points.sixes = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Three of a kind":
                    Points.threeOfAKind = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Four of a kind":
                    Points.fourOfAKind = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Full house":
                    Points.fullHouse = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Small street":
                    Points.smallStreet = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Large street":
                    Points.largeStreet = _dice.GetPoints(scoreableCategories[category]);
                    break;

                case "Yahtzee":
                    Points.topScore = _dice.GetPoints(scoreableCategories[category]);
                    break;
                    
                default:
                    break;
            }
        }
    }
}
