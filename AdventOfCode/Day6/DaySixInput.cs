using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day6
{
    internal class DaySixInput
    {
        public List<LanternFish> Fish { get;  }
        public DaySixInput(List<LanternFish> fish)
        {
            Fish = fish;
        }
    }

    internal class LanternFish
    {
        public int Timer { get; private set; }
        public List<LanternFish> Babies { get; } = new List<LanternFish>();

        public LanternFish(int defaultTimer)
        {
            Timer = defaultTimer;
        }
        public void Tick()
        {
            Babies.ForEach(b => b.Tick());

            if (Timer == 0)
            {
                Timer = 6;
                Babies.Add(new LanternFish(8));
            }
            else
            {
                Timer--;
            }
        }

        public int Count()
        {
            var counter = 1;
            if (Babies.Any())
            {
                counter += Babies.Sum(b => b.Count());
            }
            return counter;
        }
    }
}
