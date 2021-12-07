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
            var answer = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {                
                for (int j = 0; j < input.Length; j++)
                {
                    answer[j] = Math.Abs(input[j] - input[i]);
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