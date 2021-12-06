

using AdventOfCode.Day5;

var input = DayFiveInputReader.ReadInput(@"Day5\input.txt");
var day = new DayFive(input);
Console.WriteLine(day.Answer().ToString());
Console.Read();