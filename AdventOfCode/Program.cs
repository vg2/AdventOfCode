
using AdventOfCode.Day1;

var fileLines = System.IO.File.ReadAllLines(@"Day1\input.txt");

var input = fileLines.Select(f => int.Parse(f)).ToArray();

var dayOne = new DayOne(input);

Console.WriteLine(dayOne.Answer().ToString());

Console.Read();