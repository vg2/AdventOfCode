using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day10
{
    internal class DayTen
    {
        private readonly string[] input;
        private readonly Dictionary<char, char> Pairs = new Dictionary<char, char>
        {
            {'(',')' },
            {'[',']'},
            {'{','}'},
            {'<','>'},
        };

        private readonly Dictionary<char, int> Score = new Dictionary<char, int>
        {
            {')', 3 },
            {']',57},
            {'}',1197},
            {'>',25137 },
        };



        public DayTen(string[] input)
        {
            this.input = input;
        }

        public int Answer()
        {
            var illegalChars = new List<char>();

            foreach (var line in this.input)
            {
                var stack = new Stack<char>();
                foreach (var c in line)
                {
                    if (!stack.Any())
                    {
                        stack.Push(c);
                    }
                    else if (Pairs.ContainsKey(c))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        if (Pairs[stack.Peek()] == c)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            illegalChars.Add(c);
                            break;
                        }
                    }
                }
            }

            return illegalChars.Select(ch => Score[ch]).Sum();
        }

    }
}
