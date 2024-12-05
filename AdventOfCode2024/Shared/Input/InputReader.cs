using AdventOfCode2024.Shared.Enum;

namespace AdventOfCode2024.Shared.Input;

using System.IO;
using System.Reflection;

public abstract class InputReader : IInputReader
{
    protected string FilePath { get; private set; }

    protected void SetFilePath(Day day, Puzzle puzzle)
    {
        // Use reflection to locate the "input" folder and a specific file
        string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string inputFolder = Path.Combine(assemblyLocation ?? string.Empty, "inputs");

        if (!Directory.Exists(inputFolder))
        {
            throw new DirectoryNotFoundException($"Input folder not found: {inputFolder}");
        }

        // Construct the filename dynamically based on the enum value
        string fileName = $"day{(int)day}-{(int)puzzle}.csv";
        string[] files = Directory.GetFiles(inputFolder, fileName);

        if (files.Length == 0)
        {
            throw new FileNotFoundException($"No files found in {inputFolder} matching '{fileName}'");
        }

        FilePath = files[0]; // Assume the first match is the file to read
    }

    public abstract  List<List<T>> Read<T>(Day day, Puzzle puzzle, string delimeter = "  ", bool hasHeaders = false);
}
