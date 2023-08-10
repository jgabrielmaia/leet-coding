var solution = new Solution();

Console.WriteLine(
    solution.EraseOverlapIntervals(new int[][]
    {
        new int[] { 1, 2 },
        new int[] { 2, 3 },
        new int[] { 3, 4 },
        new int[] { 1, 3 },
    }) == 1
);
Console.WriteLine(
    solution.EraseOverlapIntervals(new int[][]
    {
        new int[] { 1, 2 },
        new int[] { 1, 2 },
        new int[] { 1, 2 },
    }) == 2
);
Console.WriteLine(
    solution.EraseOverlapIntervals(new int[][]
    {
        new int[] { 1, 2 },
        new int[] { 2, 3 },
    }) == 0
);
Console.WriteLine(
    solution.EraseOverlapIntervals(new int[][]
    {
        new int[] { 1, 2 },
        new int[] { 1, 3 },
        new int[] { 1, 4 },
    }) == 2
);

public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) 
    {
        if (intervals.Length <= 1)
            return 0;

        // Sort by ends
        Array.Sort(intervals, (a,b) => a[1].CompareTo(b[1]));

        var overlaps = 0;
        var end = intervals[0][1];
        
        for (var i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] < end)
            {
                overlaps++;
                continue;
            }

            end = intervals[i][1];
        }

        return overlaps;
    }
}