using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    internal class Player
    {
        public string Name { get; }

        public Points Points { get; } = new Points();

        public Player(string name)
        {
            Name = name;
        }
    }
}
