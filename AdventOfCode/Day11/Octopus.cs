using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day11
{
    internal class Octopus
    {
        public int Energy { get; private set; }
        public bool Flashed { get; private set; }

        public Octopus(int energy)
        {
            Energy = energy;
            Flashed = false;
        }

        public void Increment()
        {
            Energy += 1;
        }

        public bool ShouldFlash()
        {
            return Energy > 9 && !Flashed;
        }

        public void Flash()
        {
            Flashed = true;
        }

        public void Reset()
        {
            Flashed = false;
            Energy = 0;
        }
    }
}
