namespace LeetCodePatterns.HashMap.TwoSum;

// LeetCode #1 — Two Sum
// Return the indices of the two numbers that add up to target.
public class Solution
{
    // O(n²) time, O(1) space: test every pair.
    public int[] TwoSumBruteForce(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            // Start at i + 1 so we never reuse an element or retest a pair.
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return new[] { i, j };
            }
        }

        return Array.Empty<int>();
    }

    // O(n) time, O(n) space: remember seen values for O(1) complement lookups.
    public int[] TwoSumHashMap(int[] nums, int target)
    {
        // value -> index, so we can look up by the value we still need.
        var seen = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            // Check before inserting: this guarantees the match is an earlier
            // element, which is what makes the [3, 3] case return two distinct
            // indices instead of pairing an element with itself.
            if (seen.TryGetValue(complement, out int complementIndex))
                return new[] { complementIndex, i };

            seen[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}
