namespace LeetCodePatterns.HashMap.RomanToInteger;

// LeetCode #13 — Roman to Integer
// Convert a valid Roman numeral string to its integer value.
public class Solution
{
    // Symbol -> value lookup. Static + readonly so it's built once, not per call.
    private static readonly Dictionary<char, int> Values = new()
    {
        ['I'] = 1,
        ['V'] = 5,
        ['X'] = 10,
        ['L'] = 50,
        ['C'] = 100,
        ['D'] = 500,
        ['M'] = 1000,
    };

    // Approach 1: handle each subtractive PAIR explicitly (the shape of the
    // original attempt, corrected). When the current symbol starts one of the
    // six special pairs, add the pair's value and skip the next char (i++);
    // otherwise add the symbol on its own. O(n) time, O(1) space.
    //
    // The fix vs. the crashing version: every look-ahead is guarded by
    // `hasNext`, so s[i + 1] is only touched when it actually exists.
    public int RomanToIntExplicit(string s)
    {
        int num = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            bool hasNext = i + 1 < s.Length;
            char next = hasNext ? s[i + 1] : '\0';

            if (c == 'I' && next == 'V') { num += 4; i++; }
            else if (c == 'I' && next == 'X') { num += 9; i++; }
            else if (c == 'X' && next == 'L') { num += 40; i++; }
            else if (c == 'X' && next == 'C') { num += 90; i++; }
            else if (c == 'C' && next == 'D') { num += 400; i++; }
            else if (c == 'C' && next == 'M') { num += 900; i++; }
            else { num += Values[c]; }
        }

        return num;
    }

    // Approach 2: left-to-right, compare each numeral with the NEXT one.
    // The single rule that replaces all the special cases: a numeral that is
    // smaller than the one after it is subtractive (IV, IX, XL, CM, ...).
    // O(n) time, O(1) space.
    public int RomanToInt(string s)
    {
        int total = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int current = Values[s[i]];

            // Guard the look-ahead: only read s[i + 1] when it exists. Skipping
            // this check is what throws IndexOutOfRangeException on the last
            // character (e.g. the final 'I' in "III").
            if (i + 1 < s.Length && current < Values[s[i + 1]])
                total -= current;
            else
                total += current;
        }

        return total;
    }

    // Approach 3: right-to-left, no look-ahead needed at all (LeetCode's Hint 1).
    // Walk from the end tracking the largest value seen so far. Anything smaller
    // than that maximum is a subtractive prefix. O(n) time, O(1) space.
    public int RomanToIntRightToLeft(string s)
    {
        int total = 0;
        int rightMax = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int current = Values[s[i]];

            if (current < rightMax)
            {
                total -= current;
            }
            else
            {
                total += current;
                rightMax = current;
            }
        }

        return total;
    }
}
