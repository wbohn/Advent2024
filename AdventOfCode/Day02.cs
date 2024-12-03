namespace AdventOfCode;
public class Day02 : AbstractBaseDay
{
    public Day02()
    {
        int safeCount = 0;
        foreach (var safetyReport in _inputLines)
        {
            var levels = safetyReport.Split(" ")
                .Select(int.Parse);
            if (IsSortedSafely(levels))
            {
                safeCount++;
            }
        }
    }
    public override ValueTask<string> Solve_1()
    {
        int safeCount = 0;
        foreach (var safetyReport in _inputLines)
        {
            var levels = safetyReport.Split(" ")
                .Select(int.Parse);
            if (IsSortedSafely(levels))
            {
                safeCount++;
            }
        }
        return new ValueTask<string>(safeCount.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int safeCount = 0;
        foreach (var safetyReport in _inputLines)
        {
            var levels = safetyReport.Split(" ")
                .Select(int.Parse);
            if (IsSortedSafely(levels))
            {
                safeCount++;
            }
            else
            {
                for (int i = 0; i < levels.Count(); i++)
                {
                    var newLevels = levels.Where((_, index) => index != i);
                    if (IsSortedSafely(newLevels))
                    {
                        safeCount++;
                        break;
                    }
                }
            }
        }
        return new ValueTask<string>(safeCount.ToString());
    }

    static bool IsSortedSafely(IEnumerable<int> levels)
    {
        return IsIncreasingSafely(levels) || IsDecreasingSafely(levels);
    }

    static bool IsIncreasingSafely(IEnumerable<int> levels)
    {
        return levels.Zip(
            levels.Skip(1), (a, b) => a < b && (b - a) >= 1 && (b - a) <= 3)
            .All(x => x);
    }

    static bool IsDecreasingSafely(IEnumerable<int> levels)
    {
        return levels.Zip(
            levels.Skip(1), (a, b) => a > b && (a - b) >= 1 && (a - b) <= 3)
            .All(x => x);
    }
}
