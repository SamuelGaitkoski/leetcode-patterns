namespace CodingPatterns.Coderbyte.SlidingWindow.MinimumWindowSubstring;

using System.Collections.Generic;

// Coderbyte — Minimum Window Substring
// strArr = [N, K]. Return the smallest substring of N that contains all of K's
// characters (including duplicates). e.g. ["aaabaaddae","aed"] -> "dae".
public class Solution
{
    // Classic min-window sliding window. Expand right to satisfy the requirement,
    // then contract left as far as possible while still valid, tracking the
    // smallest valid window. O(|N| + |K|) time, O(|K|) space.
    public string MinWindowSubstring(string[] strArr)
    {
        string text = strArr[0];
        string pattern = strArr[1];

        var need = new Dictionary<char, int>();
        foreach (char c in pattern)
            need[c] = need.GetValueOrDefault(c) + 1;

        int required = need.Count;   // distinct chars still to satisfy
        var window = new Dictionary<char, int>();
        int formed = 0;

        int left = 0, bestStart = 0, bestLength = int.MaxValue;

        for (int right = 0; right < text.Length; right++)
        {
            char c = text[right];
            window[c] = window.GetValueOrDefault(c) + 1;
            if (need.ContainsKey(c) && window[c] == need[c])
                formed++;

            // Once every required char is met, shrink from the left.
            while (formed == required)
            {
                if (right - left + 1 < bestLength)
                {
                    bestLength = right - left + 1;
                    bestStart = left;
                }

                char leftChar = text[left];
                window[leftChar]--;
                if (need.ContainsKey(leftChar) && window[leftChar] < need[leftChar])
                    formed--;
                left++;
            }
        }

        return bestLength == int.MaxValue ? string.Empty : text.Substring(bestStart, bestLength);
    }
}
