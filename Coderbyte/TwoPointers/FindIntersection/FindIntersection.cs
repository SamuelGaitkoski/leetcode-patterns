namespace CodingPatterns.Coderbyte.TwoPointers.FindIntersection;

using System.Collections.Generic;
using System.Linq;

// Coderbyte — Find Intersection
// strArr holds two comma-separated lists of numbers, each sorted ascending.
// Return the numbers common to both, comma-separated and sorted; "false" if the
// intersection is empty.
public class Solution
{
    // Because both lists are already sorted, a two-pointer merge finds the shared
    // values in one linear pass: advance whichever pointer trails, record a match
    // when they're equal. O(n + m) time, O(1) auxiliary (beyond the output).
    // (The imported version used a nested loop — O(n * m).)
    public string FindIntersection(string[] strArr)
    {
        int[] first = Parse(strArr[0]);
        int[] second = Parse(strArr[1]);

        var matches = new List<int>();
        int i = 0, j = 0;
        while (i < first.Length && j < second.Length)
        {
            if (first[i] == second[j])
            {
                matches.Add(first[i]);
                i++;
                j++;
            }
            else if (first[i] < second[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return matches.Count == 0 ? "false" : string.Join(",", matches);
    }

    // "1, 3, 4" -> [1, 3, 4]. Trims the spaces that follow each comma.
    private static int[] Parse(string list) =>
        list.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
}
