using AdventOfCode2024.Shared.Enum;
using AdventOfCode2024.Shared.Input;

namespace AdventOfCode2024.Solutions;

public abstract class Solution(Day day) : ISolution
{
    protected Puzzle puzzle;
    protected IInputReader inputReader;

    public void Solve(Puzzle p)
    {
        puzzle = p;
        Console.WriteLine($"Puzzle {p}");
        switch (puzzle)
        {
            case Puzzle.One:
                Puzzle1();
                break;
            case Puzzle.Two:
                Puzzle2();
                break;
        }
    }
    public abstract void Puzzle1();
    public abstract void Puzzle2();
}
