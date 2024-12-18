﻿namespace AdventOfCode;

public class Day01 : AbstractBaseDay
{
    private readonly List<int> leftList = [];
    private readonly List<int> rightList = [];

    public Day01()
    {
        foreach (var line in _inputLines)
        {
            List<int> locationIds = line.Split("   ")
                .Select(int.Parse)
                .ToList();
            leftList.Add(locationIds[0]);
            rightList.Add(locationIds[1]);
        }
    }

    public override ValueTask<string> Solve_1()
    {
        var pairedLocationIds = leftList.OrderBy(n => n)
            .Zip(rightList.OrderBy(n => n));

        var distances = pairedLocationIds.Select(pair => Math.Abs(pair.First - pair.Second));
        foreach (var (First, Second) in pairedLocationIds)
        {
            int distance = Math.Abs(First - Second);
        }
        return new ValueTask<string>(distances.Sum().ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int similarityScore = leftList
            .Sum(id => id * rightList.Count(n => n == id));

        return new ValueTask<string>(similarityScore.ToString());
    }
}
