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
            {')', 1 },
            {']',2},
            {'}',3},
            {'>',4 },
        };



        public DayTen(string[] input)
        {
            this.input = input;
        }

        public long Answer()
        {
            var illegalLines = new List<string>();

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
                            illegalLines.Add(line);
                            break;
                        }
                    }
                }
            }

            var incompleteLines = input.Except(illegalLines);
            var completions = new List<long>();
            foreach (var line in incompleteLines)
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
                    }
                }
                var lineCompletion = stack.Select(c => Pairs[c]);
                long lineScore = 0;
                foreach (var c in lineCompletion)
                {
                    lineScore *= 5;
                    lineScore += Score[c];
                }
                completions.Add(lineScore);
            }

            return completions.OrderBy(c => c).ElementAt(completions.Count / 2);
        }

    }
}
