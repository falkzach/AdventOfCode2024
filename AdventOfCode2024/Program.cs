using AdventOfCode2024.Shared.Enum;
using AdventOfCode2024.Shared.Runner;
using AdventOfCode2024.Solutions;

Console.WriteLine("Hello AdventOfCode2024!");

var day = args.Length > 0
    ? (Day) Enum.Parse(typeof(Day), args[0])
    : Day.None;

if (day is Day.None)
{
    Console.WriteLine("Supply a day in arg[0] 1-31");
}

var puzzle = args.Length > 0
    ? (Puzzle) Enum.Parse(typeof(Puzzle), args[1])
    : Puzzle.None;

if (puzzle is Puzzle.None)
{
    Console.WriteLine("Supply a puzzle in arg[1] 1-2");
}

Console.WriteLine($"Running day {day.ToString()?.ToLower()}...");

ISolution solution = SolutionReflection.GetSolution(day);
Console.WriteLine($"Running solution {solution.ToString()}");
solution.Solve(puzzle);
Console.WriteLine($"Solution executed: {solution.ToString()}");
