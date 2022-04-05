using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    internal static class PointDefenitions
    {
        public static int FullHouse { get { return 25; } }
        public static int SmallStreet { get { return 30; } }
        public static int LargeStreet { get { return 40; } }
        public static int TopScore { get { return 50; } }
    }
    
    internal class Points
    {
        public int ones = 0;
        public int twos = 0;
        public int threes = 0;
        public int fours = 0;
        public int fives = 0;
        public int sixes = 0;

        public int threeOfAKind = 0;
        public int carre = 0;
        public int fullHouse = 0;
        public int smallStreet = 0;
        public int largeStreet = 0;
        public int topScore = 0;
        public int chance = 0;
    }
}
