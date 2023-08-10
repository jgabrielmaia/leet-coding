// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;

var solution = new Solution();
solution.solution();

public class Solution
{

    public Dictionary<int, string> Numbers { get; set; } = new Dictionary<int, string>{
        { 3, "fizz" },
        { 5, "buzz" },
        { 7, "bang" },
    };

    [Benchmark]
    public void solution()
    {
        for (int i = 0; i < 100; i++)
        {
            var to_print = string.Empty;

            foreach (var key in Numbers.Keys)
                if (i % key == 0)
                    to_print += Numbers[key];

            if (to_print == string.Empty)
                Console.WriteLine(i);
            else Console.WriteLine(to_print);
        }
    }
}