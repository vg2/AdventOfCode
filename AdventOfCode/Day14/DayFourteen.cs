using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day14
{
    internal class DayFourteen
    {
        private readonly Instruction instruction;
        public DayFourteen(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            this.instruction = new Instruction(lines.First());

            foreach (var line in lines.Skip(2))
            {
                var split = line.Split(" -> ");
                this.instruction.PairInsertions.Add(split.First(), split.Last());
            }

        }

        public long Answer()
        {
            var result = this.instruction.Template;

            for (var i = 0; i < 10; i++)
            {
                var insertionPoints = new List<(int pos, string val)>();
                var index = 0;
                for (var p = 0; p < result.Length - 1; p++)
                {
                    if (instruction.PairInsertions.TryGetValue(result.Substring(p, 2), out var insertionValue))
                    {
                        insertionPoints.Add((p + 1 + index, insertionValue));
                        index++;
                    }
                }

                foreach (var insertionPoint in insertionPoints)
                {
                    result = result.Insert(insertionPoint.pos, insertionPoint.val);
                }
            }

            var summary = new Dictionary<char, long>();

            foreach (var ch in result)
            {
                if (!summary.ContainsKey(ch))
                {
                    summary.Add(ch, 0);
                }

                summary[ch] = summary[ch] + 1;
            }
            var amountOfMostCommon = summary.Max(x => x.Value);
            var min = summary.Min(x => x.Value);

            return amountOfMostCommon - min;

        }


    }

    internal class Instruction
    {
        public string Template { get; }
        public Dictionary<string, string> PairInsertions { get; }

        public Instruction(string template)
        {
            Template = template;
            PairInsertions = new Dictionary<string, string>();
        }
    }
}
