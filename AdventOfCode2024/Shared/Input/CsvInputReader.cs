using AdventOfCode2024.Shared.Enum;

namespace AdventOfCode2024.Shared.Input;

public class CsvInputReader : InputReader
{
    public override  List<List<T>> Read<T>(Day day, Puzzle puzzle, string delimeter = "  ", bool hasHeaders = false)
    {
        SetFilePath(day, puzzle);
        var data = new List<List<T>>();

        if (string.IsNullOrEmpty(FilePath))
        {
            throw new InvalidOperationException("File path is not set.");
        }

        Console.WriteLine($"Reading file: {FilePath}");

        try
        {
            var lines = File.ReadAllLines(FilePath);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return data;
            }

            // If headers are not included, skip the first line
            int startIndex = hasHeaders ? 1 : 0;

            for (int i = startIndex; i < lines.Length; i++)
            {
                var values = lines[i].Split(delimeter);
                data.Add(values.Select(x => (T)Convert.ChangeType(x, typeof(T)) ).ToList());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }

        return data;
    }
}
