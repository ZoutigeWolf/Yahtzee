using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    internal class Dice
    {
        public int Amount { get; private set; }

        public List<int> Values { get; private set; } = new List<int>();
        public List<int> ValuesToKeep { get; private set; } = new List<int>();

        public Dice(int amount)
        {
            Amount = amount;

            Roll();
        }

        public void Roll()
        {
            Values.Clear();

            Random rand = new Random();
            
            for (int i = 0; i < Amount; i++)
            {
                Values.Add(rand.Next(1, 7));
            }

            UnkeepValues();
        }

        public void KeepValues(int[] values)
        {
            foreach (int value in values)
            {
                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i] == value)
                    {
                        ValuesToKeep.Add(value);
                        Values.RemoveAt(i);
                    }
                }
            }
        }
        
        public void UnkeepValues()
        {
            foreach (int value in ValuesToKeep)
            {
                Values.Add(value);
            }

            ValuesToKeep.Clear();
        }

        public void PrintValues()
        {
            Console.WriteLine("Dice values:");
            foreach (int val in Values)
            {
                Console.WriteLine(val);
            }
        }

        public int GetSum() => Values.Sum() + ValuesToKeep.Sum();

        public int GetSum(int i)
        {
            int count = 0;

            foreach (int die in Values)
            {
                if (die == i)
                {
                    count++;
                }
            }

            return count;
        }

        public string[] GetAvailableScores(Points points)
        {
            int[] total = Values.ToArray();

            List<string> scores = new List<string>();

            if (total.Contains(1) && points.ones == 0)
            {
                scores.Add("Ones");
            }

            if (total.Contains(2) && points.twos == 0)
            {
                scores.Add("Twos");
            }

            if (total.Contains(3) && points.threes == 0)
            {
                scores.Add("Threes");
            }

            if (total.Contains(4) && points.fours == 0)
            {
                scores.Add("Fours");
            }

            if (total.Contains(5) && points.fives == 0)
            {
                scores.Add("Fives");
            }

            if (total.Contains(6) && points.sixes == 0)
            {
                scores.Add("Sixes");
            }

            if (total.ContainsNTimes(3) && points.threeOfAKind == 0)
            {
                scores.Add("Three of a kind");
            }

            if (total.ContainsNTimes(4) && points.fourOfAKind == 0)
            {
                scores.Add("Four of a kind");
            }

            if (total.ContainsNTimes(3) && total.ContainsNTimes(2) && points.fullHouse == 0)
            {
                scores.Add("Full house");
            }

            if (total.IsIncreasing(4) && points.smallStreet == 0)
            {
                scores.Add("Small street");
            }

            if (total.IsIncreasing(5) && points.largeStreet == 0)
            {
                scores.Add("Large street");
            }

            if (total.IsAllSame() && points.topScore == 0)
            {
                scores.Add("Yahtzee");
            }

            return scores.ToArray();
        }

        public int GetPoints(string category)
        {
            switch (category)
            {
                case "Ones":
                    return GetSum(1);

                case "Twos":
                    return GetSum(2);

                case "Threes":
                    return GetSum(3);

                case "Fours":
                    return GetSum(4);

                case "Fives":
                    return GetSum(5);

                case "Sixes":
                    return GetSum(6);

                case "Three of a kind":
                    return GetSum();

                case "Four of a kind":
                    return GetSum();

                case "Full house":
                    return PointDefenitions.FullHouse;

                case "Small street":
                    return PointDefenitions.SmallStreet;

                case "Large street":
                    return PointDefenitions.LargeStreet;

                case "Yahtzee":
                    return PointDefenitions.TopScore;

                default:
                    return 0;
            }
        }
    }
}
