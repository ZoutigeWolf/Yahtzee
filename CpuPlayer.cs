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
        public override void PlayTurn()
        {
            throw new NotImplementedException();
        }
    }
}
