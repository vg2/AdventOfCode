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

            var map = new Dictionary<string, long>();
            for (var i = 0; i < result.Length - 1; i++)
            {
                var key = $"{result[i]}{result[i + 1]}";
                AddOrIncrement(map, key);
            }

            for (var i = 0; i < 40; i++)
            {
                var newMap = new Dictionary<string, long>();


                foreach(var key in map.Keys)
                {
                    if (instruction.PairInsertions.TryGetValue(key, out var insertionValue))
                    {
                        AddOrIncrement(newMap, $"{key[0]}{insertionValue}", incrementVal: map[key]);
                        AddOrIncrement(newMap, $"{insertionValue}{key[1]}", incrementVal: map[key]);
                    }
                    else
                    {
                        AddOrIncrement(newMap, key, incrementVal: map[key]);
                    }
                }

                map = newMap;
            }

            var summary = new Dictionary<char, long>();
            foreach (var key in map.Keys)
            {
                AddOrIncrement(summary, key[0], map[key]);
            }

            var amountOfMostCommon = summary.Max(x => x.Value);
            var min = summary.Min(x => x.Value);

            return amountOfMostCommon - min + 1;

        }

        private void AddOrIncrement<T>(Dictionary<T, long> map, T key, long incrementVal = 1)
        {
            if (!map.TryAdd(key, incrementVal))
            {
                map[key] += incrementVal;
            }
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
