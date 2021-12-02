
using AdventOfCode.Day1;
using AdventOfCode.Day2;

// Day One
//var input = DayOneInputReader.ReadInput(@"Day1\input.txt");
//var dayOne = new DayOne(input);

//Console.WriteLine(dayOne.Answer().ToString());

// Day 2
var input = DayTwoInputReader.ReadInput(@"Day2\input.txt");
var dayTwo = new DayTwo(input);
Console.WriteLine(dayTwo.Answer().ToString());
Console.Read();