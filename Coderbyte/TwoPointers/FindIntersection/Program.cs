namespace CodingPatterns.Coderbyte.TwoPointers.FindIntersection;

// Coderbyte example plus a no-overlap case.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string[] Input, string Expected)[]
        {
            (new[] { "1, 3, 4, 7, 13", "1, 2, 4, 13, 15" }, "1,4,13"),
            (new[] { "1,2,3", "2,3,4" }, "2,3"),
            (new[] { "1,2,3", "4,5,6" }, "false"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.FindIntersection(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"FindIntersection([\"{input[0]}\", \"{input[1]}\"]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
