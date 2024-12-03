using System.Text.RegularExpressions;

namespace AdventOfCode;
public class Day03 : AbstractBaseDay
{
    public override ValueTask<string> Solve_1()
    {
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";
        MatchCollection matches = Regex.Matches(_inputText, pattern);

        int sum = 0;
        foreach (Match match in matches)
        {
            int x = int.Parse(match.Value.Split(",")[0][4..]);
            int y = int.Parse(match.Value.Split(",")[1][0..^1]);
            sum += x * y;
        }
        return ValueTask.FromResult(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return ValueTask.FromResult("Not implemented");
    }
}
