

using AdventOfCode.Day6;

var input = DaySixInputReader.ReadInput(@"Day6\input.txt");
var day = new DaySix(input);
Console.WriteLine(day.Answer().ToString());
Console.Read();