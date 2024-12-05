using System.Reflection;
using AdventOfCode2024.Shared.Enum;
using AdventOfCode2024.Solutions;

namespace AdventOfCode2024.Shared.Runner;

public static class SolutionReflection
{
    public static ISolution GetSolution(Day day)
    {
        if (day == Day.None)
        {
            throw new ArgumentException("Day cannot be None", nameof(day));
        }

        // Construct the class name dynamically
        string className = $"AdventOfCode2024.Solutions.Day{(int)day}";

        // Get the type from the current assembly
        Type type = Assembly.GetExecutingAssembly().GetType(className);

        if (type == null)
        {
            throw new TypeLoadException($"Class '{className}' not found in the current assembly.");
        }

        // Ensure the type implements ISolution
        if (!typeof(ISolution).IsAssignableFrom(type))
        {
            throw new InvalidOperationException($"Class '{className}' does not implement ISolution.");
        }

        // Create an instance of the class
        return (ISolution)Activator.CreateInstance(type, day);
    }
}
