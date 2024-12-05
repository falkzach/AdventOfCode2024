using AdventOfCode2024.Shared.Enum;
using AdventOfCode2024.Shared.Input;

namespace AdventOfCode2024.Solutions;

public class Day1(Day day) : Solution(day)
{
    public override void Puzzle1()
    {
        inputReader = new CsvInputReader();
        var data = inputReader.Read<int>(day, puzzle);
        var transposedData = InputUtils.Transpose(data);
        transposedData[0].Sort();
        transposedData[1].Sort();

        var totalGap = 0;

        for (var i = 0; i < transposedData[0].Count; ++i)
        {
            totalGap += Math.Abs(transposedData[0][i] - transposedData[1][i]);
        }
        Console.WriteLine($"total gap: {totalGap}");
    }

    public override void Puzzle2()
    {
        inputReader = new CsvInputReader();
        var data = inputReader.Read<int>(day, puzzle);
        var transposedData = InputUtils.Transpose(data);
        transposedData[0].Sort();
        transposedData[1].Sort();

        var totalGap = 0;

        var HASHMAP_USE_A_HASHMAP = new Dictionary<int, int>();
        foreach (var x in transposedData[0].Distinct())
        {
            HASHMAP_USE_A_HASHMAP.Add(x, 0);
        }

        foreach (var x in transposedData[1])
        {
            if (HASHMAP_USE_A_HASHMAP.ContainsKey(x))
            {
                HASHMAP_USE_A_HASHMAP[x]++;
            }
        }

        foreach (var x in HASHMAP_USE_A_HASHMAP)
        {
            totalGap += x.Key * x.Value;
        }

        Console.WriteLine($"total gap 2: {totalGap}");
    }
}
