using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    internal static class Extensions
    {
        public static bool ContainsNTimes(this int[] array, int n)
        {
            return array.GroupBy(i => i).Any(g => g.Count() == n);
        }
        public static bool IsIncreasing(this int[] array, int n)
        {
            for (int i = 0; i < array.Length - n + 1; i++)
            {
                if (array[i] > array[i + n - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAllSame(this int[] array)
        {
            return array.GroupBy(i => i).Count() == 1;
        }
    }
}
