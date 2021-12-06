
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;

// Day One
//var input = DayOneInputReader.ReadInput(@"Day1\input.txt");
//var dayOne = new DayOne(input);

//Console.WriteLine(dayOne.Answer().ToString());

// Day 2
var input = DayThreeInputReader.ReadInput(@"Day3\input.txt");
var dayThree = new DayThree(input);
Console.WriteLine(dayThree.Answer().ToString());
Console.Read();