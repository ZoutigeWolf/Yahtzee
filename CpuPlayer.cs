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

        private void RollDice()
        {
            _dice.Roll();

            _rollsRemaining--;

            KeyValuePair<string, float>[] chances = GetChances();
        }

        private KeyValuePair<string, float>[] GetChances()
        {
            List<KeyValuePair<string, float>> chances = new List<KeyValuePair<string, float>>();

            chances.Add(new KeyValuePair<string, float>("Ones", _dice.Values.Where(x => x == 1).Count() / 3 * 100f));
            chances.Add(new KeyValuePair<string, float>("Twos", _dice.Values.Where(x => x == 2).Count() / 3 * 100f));
            chances.Add(new KeyValuePair<string, float>("Threes", _dice.Values.Where(x => x == 3).Count() / 3 * 100f));
            chances.Add(new KeyValuePair<string, float>("Fours", _dice.Values.Where(x => x == 4).Count() / 3 * 100f));
            chances.Add(new KeyValuePair<string, float>("Fives", _dice.Values.Where(x => x == 5).Count() / 3 * 100f));
            chances.Add(new KeyValuePair<string, float>("Sixes", _dice.Values.Where(x => x == 6).Count() / 3 * 100f));

            chances.Add(new KeyValuePair<string, float>("Three of a kind", _dice.Values.ToArray().HighestValueCount() / 3 * 100f));
            chances.Add(new KeyValuePair<string, float>("Four of a kind", _dice.Values.ToArray().HighestValueCount() / 4 * 100f));

            return chances.ToArray();
        }
    }
}
