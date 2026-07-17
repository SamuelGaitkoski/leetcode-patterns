namespace CodingPatterns.LeetCode.Strings.LongestCommonPrefix;

// LeetCode #14 — Longest Common Prefix
// Find the longest string that is a prefix of every string in the array.
// Return "" when there is no common prefix.
public class Solution
{
    // Approach 1: vertical scanning — my approach.
    // Walk character POSITIONS (using the first string as the reference), and at
    // each position check that every other string has the same character there.
    // A prefix must match at every position, so the moment a position fails in any
    // string, everything before it is the answer. The `pos >= strs[i].Length` guard
    // handles a string that is shorter than the current reference (and the empty-
    // string case, where its length is 0, stops us at position 0 -> "").
    // O(S) time where S is the total number of characters, O(1) extra space.
    public string LongestCommonPrefix(string[] strs)
    {
        // strs.Length >= 1 by the constraints, so strs[0] is a safe reference.
        for (int pos = 0; pos < strs[0].Length; pos++)
        {
            char c = strs[0][pos];

            for (int i = 1; i < strs.Length; i++)
            {
                // This string ran out, or it differs here: stop before this position.
                if (pos >= strs[i].Length || strs[i][pos] != c)
                    return strs[0].Substring(0, pos);
            }
        }

        // Never mismatched: the whole first string is the common prefix.
        return strs[0];
    }

    // Approach 2: horizontal scanning.
    // Start by assuming the whole first string is the prefix, then shrink it against
    // each subsequent string until that string starts with the running prefix. If the
    // prefix ever shrinks to "", no common prefix exists and we can stop early.
    // O(S) time, O(1) extra space (Substring aside).
    public string LongestCommonPrefixHorizontal(string[] strs)
    {
        string prefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            // Trim the prefix one char at a time until strs[i] starts with it.
            while (!strs[i].StartsWith(prefix))
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (prefix.Length == 0)
                    return "";
            }
        }

        return prefix;
    }

    // Approach 3: sort trick.
    // After sorting alphabetically, the two strings that differ the most sit at the
    // ends of the array, so the common prefix of ALL strings equals the common
    // prefix of just the first and last. Compare only those two.
    // O(n·log n · m) time (sort dominates; m = max string length), O(1) extra space.
    public string LongestCommonPrefixSort(string[] strs)
    {
        Array.Sort(strs);

        string first = strs[0];
        string last = strs[^1];  // ^1 == strs[strs.Length - 1]
        int i = 0;

        while (i < first.Length && i < last.Length && first[i] == last[i])
            i++;

        return first.Substring(0, i);
    }

    // Approach 4: divide and conquer.
    // The common prefix of the whole array is the common prefix of its two halves:
    // LCP(a..b) = LCP( LCP(a..mid), LCP(mid+1..b) ). Recurse down to single strings
    // (whose "prefix" is themselves), then merge pairwise back up.
    // O(S) time, O(m · log n) space for the recursion / intermediate prefixes.
    public string LongestCommonPrefixDivideConquer(string[] strs)
    {
        return Lcp(strs, 0, strs.Length - 1);
    }

    private string Lcp(string[] strs, int lo, int hi)
    {
        if (lo == hi)
            return strs[lo];

        int mid = lo + (hi - lo) / 2;
        string left = Lcp(strs, lo, mid);
        string right = Lcp(strs, mid + 1, hi);
        return CommonPrefix(left, right);
    }

    private static string CommonPrefix(string a, string b)
    {
        int i = 0;
        while (i < a.Length && i < b.Length && a[i] == b[i])
            i++;
        return a.Substring(0, i);
    }

    // Approach 5: binary search on the prefix length.
    // The answer length lives somewhere in [0, shortest string length]. If a prefix
    // of length L is shared by all strings, so is every shorter prefix — a monotone
    // property, which is exactly what binary search needs. Search for the largest L
    // that all strings agree on.
    // O(S · log m) time, O(1) extra space.
    public string LongestCommonPrefixBinarySearch(string[] strs)
    {
        int minLen = strs[0].Length;
        foreach (string s in strs)
            minLen = Math.Min(minLen, s.Length);

        int lo = 0, hi = minLen;
        while (lo < hi)
        {
            // Round the midpoint UP so the loop makes progress when hi == lo + 1.
            int mid = lo + (hi - lo + 1) / 2;
            if (AllSharePrefixOfLength(strs, mid))
                lo = mid;   // length `mid` works — try longer
            else
                hi = mid - 1;
        }

        return strs[0].Substring(0, lo);
    }

    private static bool AllSharePrefixOfLength(string[] strs, int len)
    {
        for (int pos = 0; pos < len; pos++)
        {
            char c = strs[0][pos];
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i][pos] != c)
                    return false;
            }
        }
        return true;
    }
}
