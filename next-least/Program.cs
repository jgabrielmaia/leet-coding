using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

// BenchmarkRunner.Run<Solution>();

var problems = new List<int[]>() {
    new[]{1,2,3}, new []{ 1, 3, 6, 4, 1, 2 }, new []{ -1000000, 1000000 }, new []{ -1, -3 }
};

foreach (var problem in problems){
    var solution = new Solution {
        Numbers = problem
    };

    Console.Write(solution.solution_2());
    Console.Write(solution.solution());
}

public class Solution {

    [Params(new[]{1,2,3}, new []{ 1, 3, 6, 4, 1, 2 }, new []{ -1000000, 1000000 }, new []{ -1, -3 })]
    public int[] Numbers { get; set; } = {};

    [Benchmark]
    public int solution() {

        int[] to_solve = this.Numbers.Distinct().Where(x => x > 0).OrderBy(x => x).ToArray();

        if (!to_solve.Any())
            return 1;

        for (int i = 0; i < to_solve.Length; i++) {
            if(to_solve[i] == i+1)
                continue;
            return i+1;
        }

        return to_solve[to_solve.Length -1] + 1;
    }

    [Benchmark]
    public int solution_2()
    {
        HashSet<int> set = new HashSet<int>(this.Numbers.Where(x => x > 0));

        int smallestPositiveInteger = 1;

        while (set.Contains(smallestPositiveInteger))
        {
            smallestPositiveInteger++;
        }

        return smallestPositiveInteger;
    }

}