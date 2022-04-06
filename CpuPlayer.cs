using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    internal class CpuPlayer : Player
    {
        public CpuPlayer(string name) : base(name)
        {
            
        }

        private Dice _dice = new Dice(5);
        private int _rollsRemaining = 3;
        
        public override void PlayTurn()
        {
            _dice = new Dice(5);
        }
    }
}
