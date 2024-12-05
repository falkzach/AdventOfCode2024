namespace AdventOfCode2024.Shared.Input;

public static class InputUtils
{
    public static List<List<T>> Transpose<T>(List<List<T>> input)
    {
        if (input == null || input.Count == 0)
        {
            return new List<List<T>>();
        }

        int columnCount = input.Max(row => row.Count);

        var result = new List<List<T>>();

        for (int i = 0; i < columnCount; i++)
        {
            result.Add(new List<T>());
        }

        foreach (var row in input)
        {
            for (int i = 0; i < columnCount; i++)
            {
                if (i < row.Count)
                {
                    result[i].Add(row[i]);
                }
            }
        }

        return result;
    }
}
