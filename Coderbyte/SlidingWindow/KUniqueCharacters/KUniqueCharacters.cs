namespace CodingPatterns.Coderbyte.SlidingWindow.KUniqueCharacters;

using System.Collections.Generic;

// Coderbyte — K Unique Characters
// The first character of the string is an integer k. Find the longest substring
// of the remainder that contains at most k distinct characters (returning the
// first such substring on a tie). e.g. "2aabbacbaa" -> "aabba".
public class Solution
{
    // Sliding window with a character-count map. Grow the window on the right;
    // when it holds more than k distinct characters, shrink from the left until
    // it's valid again. Track the longest valid window seen.
    // O(n) time, O(k) space.
    public string KUniqueCharacters(string str)
    {
        int k = str[0] - '0';
        string s = str.Substring(1);

        var counts = new Dictionary<char, int>();
        int left = 0, bestStart = 0, bestLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            counts[s[right]] = counts.GetValueOrDefault(s[right]) + 1;

            while (counts.Count > k)
            {
                char leftChar = s[left];
                if (--counts[leftChar] == 0)
                    counts.Remove(leftChar);
                left++;
            }

            if (right - left + 1 > bestLength)
            {
                bestLength = right - left + 1;
                bestStart = left;
            }
        }

        return s.Substring(bestStart, bestLength);
    }
}
