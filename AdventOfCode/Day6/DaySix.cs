using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day6
{
    internal class DaySix
    {
        private readonly DaySixInput daySixInput;

        public DaySix(DaySixInput daySixInput)
        {
            this.daySixInput = daySixInput;
        }

        public int Answer()
        {
            for (var i = 0; i < 80; i++)
            {
                this.daySixInput.Fish.ForEach(f => f.Tick());
            }
            var counter = this.daySixInput.Fish.Sum(f => f.Count());

            return counter;
        }
    }
}
