using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public long Answer()
        {
            var timers = new long[9];
            var intList = daySixInput.Fish.Select(f => f.Timer);

            foreach (var num in intList)
            {
                timers[num]++;
            }

            for (var i = 0; i < 256; i++)
            {
                long newFish = 0;
                for (var j = 0; j < 8; j++)
                {
                    if (j == 0)
                    {
                        newFish = timers[j];
                    }
                    timers[j] = timers[j + 1];
                }
                timers[6] += newFish;
                timers[8] = newFish;
            }

            return timers.Sum();
        }
    }
}
