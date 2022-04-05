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

            for (int i = 0; i < Amount; i++)
            {
                Random rand = new Random();

                Values.Add(rand.Next(1, 7));
            }
        }

        public void KeepValues(int[] values)
        {
            foreach (int value in values)
            {
                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i] == value)
                    {
                        ValuesToKeep[i] = value;
                        Values.RemoveAt(i);
                    }
                }
            }
        }

        public int GetSum() => Values.Sum() + ValuesToKeep.Sum();

        public string[] GetAvailableScores()
        {
            int[] total = Values.Concat(ValuesToKeep).ToArray();

            List<string> scores = new List<string>();

            if (total.Contains(1))
            {
                scores.Add("Ones");
            }

            if (total.Contains(2))
            {
                scores.Add("Twos");
            }

            if (total.Contains(3))
            {
                scores.Add("Threes");
            }

            if (total.Contains(4))
            {
                scores.Add("Fours");
            }

            if (total.Contains(5))
            {
                scores.Add("Fives");
            }

            if (total.Contains(6))
            {
                scores.Add("Sixes");
            }

            if (total.ContainsNTimes(3))
            {
                scores.Add("Three of a kind");
            }

            if (total.ContainsNTimes(4))
            {
                scores.Add("Carre");
            }

            if (total.ContainsNTimes(3) && total.ContainsNTimes(2))
            {
                scores.Add("Full House");
            }

            if (total.IsIncreasing(4))
            {
                scores.Add("Small Street");
            }

            if (total.IsIncreasing(5))
            {
                scores.Add("Large Street");
            }

            if (total.IsAllSame())
            {
                scores.Add("Yahtzee");
            }

            return scores.ToArray();
        }
    }
}
