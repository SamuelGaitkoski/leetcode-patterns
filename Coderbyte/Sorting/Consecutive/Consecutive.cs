namespace CodingPatterns.Coderbyte.Sorting.Consecutive;

// Coderbyte — Consecutive
// Return the minimum count of integers to add so the array becomes consecutive
// from its lowest to its highest value. e.g. [4, 8, 6] -> 2 (add 5 and 7).
public class Solution
{
    // Sort, then sum the gaps between neighbours: each pair contributes
    // (difference - 1) missing numbers. O(n log n) time, O(n) space (the copy).
    public int Consecutive(int[] arr)
    {
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted);

        int missing = 0;
        for (int i = 0; i < sorted.Length - 1; i++)
            missing += Math.Max(0, sorted[i + 1] - sorted[i] - 1);  // clamp so duplicates (gap -1) don't subtract

        return missing;
    }
}
