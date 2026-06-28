using LeetCodePatterns.HashMap;

// Small harness to verify both Two Sum approaches against the three LeetCode
// examples. Run with `dotnet run` from inside the HashMap/ folder.

var solution = new Solution();

// Each test case: the input array, the target, and the expected indices.
var cases = new (int[] Nums, int Target, int[] Expected)[]
{
    (new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 }),
    (new[] { 3, 2, 4 },      6, new[] { 1, 2 }),
    (new[] { 3, 3 },         6, new[] { 0, 1 }),
};

Console.WriteLine("Two Sum — verifying both approaches\n");

bool allPassed = true;

foreach (var (nums, target, expected) in cases)
{
    int[] brute = solution.TwoSumBruteForce(nums, target);
    int[] hash = solution.TwoSumHashMap(nums, target);

    bool brutePass = brute.SequenceEqual(expected);
    bool hashPass = hash.SequenceEqual(expected);
    allPassed &= brutePass && hashPass;

    Console.WriteLine($"nums = [{string.Join(", ", nums)}], target = {target}");
    Console.WriteLine($"  expected   : [{string.Join(", ", expected)}]");
    Console.WriteLine($"  brute force: [{string.Join(", ", brute)}]  {(brutePass ? "PASS" : "FAIL")}");
    Console.WriteLine($"  hash map   : [{string.Join(", ", hash)}]  {(hashPass ? "PASS" : "FAIL")}");
    Console.WriteLine();
}

Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");

// Make the result usable as a CI exit code if needed.
return allPassed ? 0 : 1;
