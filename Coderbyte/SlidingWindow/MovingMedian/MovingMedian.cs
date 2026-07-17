namespace CodingPatterns.Coderbyte.SlidingWindow.MovingMedian;

using System.Collections.Generic;

// Coderbyte — Moving Median
// arr[0] is the window size; the rest form a stream. Emit the median of the
// current window after each new element (the window grows until it reaches the
// size, then slides). Medians are comma-joined.
public class Solution
{
    // Slide a fixed-size window across the stream, taking the median each step.
    // Even-sized windows average the two middle values (integer division).
    // O(n * k log k) time (a sort per step), O(k) space.
    public string MovingMedian(int[] arr)
    {
        int windowSize = arr[0];
        var window = new List<int>();
        var medians = new List<int>();

        for (int i = 1; i < arr.Length; i++)
        {
            window.Add(arr[i]);
            if (window.Count > windowSize)
                window.RemoveAt(0);          // drop the oldest element

            medians.Add(Median(window));
        }

        return string.Join(",", medians);
    }

    private static int Median(List<int> values)
    {
        var sorted = new List<int>(values);
        sorted.Sort();

        int half = sorted.Count / 2;
        return sorted.Count % 2 == 0
            ? (sorted[half - 1] + sorted[half]) / 2
            : sorted[half];
    }
}
