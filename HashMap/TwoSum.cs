namespace LeetCodePatterns.HashMap;

/// <summary>
/// LeetCode #1 — Two Sum.
///
/// Given an array of integers and a target, return the indices of the two
/// numbers that add up to the target. Exactly one valid answer is guaranteed,
/// and the same element may not be used twice.
/// </summary>
public class Solution
{
    /// <summary>
    /// Brute-force approach: try every pair of indices.
    ///
    /// Time:  O(n²) — for each element we scan the rest of the array.
    /// Space: O(1)  — no extra data structures, just a couple of loop counters.
    ///
    /// This is the "obvious" first solution. It's correct and easy to reason
    /// about, but it re-examines the same elements over and over.
    /// </summary>
    public int[] TwoSumBruteForce(int[] nums, int target)
    {
        // Outer loop fixes the first number of the pair.
        for (int i = 0; i < nums.Length; i++)
        {
            // Inner loop starts at i + 1 so we (a) never pair an element with
            // itself and (b) never test the same unordered pair twice.
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    // Found the pair — return their indices immediately.
                    return new[] { i, j };
                }
            }
        }

        // The problem guarantees a solution, so we only reach here on bad input.
        return Array.Empty<int>();
    }

    /// <summary>
    /// Hash-map approach: remember numbers we've already seen.
    ///
    /// Time:  O(n) — a single pass; each dictionary lookup/insert is O(1) average.
    /// Space: O(n) — in the worst case we store every element before finding a match.
    ///
    /// The insight: instead of searching the array for a partner each time
    /// (the slow inner loop), we store each value as we go and ask the map
    /// "have I already seen the number I still need?"
    /// </summary>
    public int[] TwoSumHashMap(int[] nums, int target)
    {
        // Maps a value we've seen -> the index where we saw it.
        // value → index is the right direction because, given the current
        // number, we want to look up *by value* (the complement) and get back
        // an *index* to return.
        var seen = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // The complement is the exact partner the current number needs:
            // current + complement == target  ⇒  complement = target - current.
            int complement = target - nums[i];

            // Check for the complement BEFORE inserting the current number.
            // This ordering is what makes the duplicate case (e.g. [3, 3], target 6)
            // work correctly:
            //   - i = 0: complement = 3, map is empty → no match → store {3: 0}.
            //   - i = 1: complement = 3, map already has 3 at index 0 → match!
            //     We return [0, 1] — two *distinct* indices.
            // If we inserted first, the second 3 would overwrite the first and
            // we'd risk matching an element with itself.
            if (seen.TryGetValue(complement, out int complementIndex))
            {
                // complementIndex is guaranteed to be an earlier index than i,
                // so the pair uses two different elements.
                return new[] { complementIndex, i };
            }

            // Current number wasn't anyone's partner yet — record it so a
            // future element can find it. (Indexer assignment also handles the
            // case of repeated values by keeping the most recent index, which
            // is fine since we always check before inserting.)
            seen[nums[i]] = i;
        }

        // Unreachable given the problem's guarantee of exactly one solution.
        return Array.Empty<int>();
    }
}
