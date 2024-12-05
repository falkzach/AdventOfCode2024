using AdventOfCode2024.Shared.Enum;

namespace AdventOfCode2024.Shared.Input;

public interface IInputReader
{
    public List<List<T>> Read<T>(Day day, Puzzle puzzle, string delimeter = "  ", bool hasHeaders = false);
}
