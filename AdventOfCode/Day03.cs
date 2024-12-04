using System.Text.RegularExpressions;

namespace AdventOfCode;
public class Day03 : AbstractBaseDay
{
    const string instructionPattern = @"\bdo\(\)|\bdon't\(\)|mul\(\d{1,3},\d{1,3}\)";
    readonly MatchCollection instructions;

    public Day03()
    {
        instructions = Regex.Matches(_inputText, instructionPattern);
    }

    public override ValueTask<string> Solve_1()
    {
        int sum = 0;
        foreach (Match instruction in instructions)
        {
            if (instruction.Value.StartsWith("mul"))
            {
                sum += Mul(instruction);
            }
        }
        return ValueTask.FromResult(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int sum = 0;
        bool enabled = true;
        foreach (Match instruction in instructions)
        {
            switch (instruction.Value)
            {
                case "do()":
                    enabled = true;
                    break;
                case "don't()":
                    enabled = false;
                    break;
                default: // mul(x,y)
                    if (enabled)
                    {
                        sum += Mul(instruction);
                    }
                    break;
            }
        }
        return ValueTask.FromResult(sum.ToString());
    }

    static int Mul(Match mulInstruction)
    {
        // mul(x,y)
        int x = int.Parse(mulInstruction.Value.Split(",")[0][4..]);
        int y = int.Parse(mulInstruction.Value.Split(",")[1][0..^1]);
        return x * y;
    }
}
