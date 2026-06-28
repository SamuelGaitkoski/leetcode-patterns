namespace LeetCodePatterns.HashMap.TwoSum;

// Verifies both approaches against the three LeetCode examples.
// Run with `dotnet run` from this folder.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int[] Nums, int Target, int[] Expected)[]
        {
            (new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 }),
            (new[] { 3, 2, 4 },      6, new[] { 1, 2 }),
            (new[] { 3, 3 },         6, new[] { 0, 1 }),
        };

        bool allPassed = true;

        foreach (var (nums, target, expected) in cases)
        {
            int[] brute = solution.TwoSumBruteForce(nums, target);
            int[] hash = solution.TwoSumHashMap(nums, target);
            bool pass = brute.SequenceEqual(expected) && hash.SequenceEqual(expected);
            allPassed &= pass;

            Console.WriteLine($"nums=[{string.Join(",", nums)}] target={target} " +
                              $"-> brute=[{string.Join(",", brute)}] hash=[{string.Join(",", hash)}] " +
                              $"{(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
