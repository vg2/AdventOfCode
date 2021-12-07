using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7
{
    internal class DaySeven
    {
        private readonly int[] input;
        public DaySeven(int[] input)
        {
            this.input = input;
        }

        public int Answer()
        {
            var total = int.MaxValue;
            var highestPosition = input.Max();
            var answer = new int[input.Length];
            for (int i = 0; i < highestPosition; i++)
            {                
                for (int j = 0; j < input.Length; j++)
                {
                    var diff = Math.Abs(input[j] - i);
                    var current = 0;
                    while (diff > 0)
                    {
                        current += diff;
                        diff--;
                    }
                    answer[j] = current;
                }
                var currentTotal = answer.Sum();
                if (currentTotal < total)
                {
                    total = currentTotal;
                }
            }

            return total;
        }
    }

}