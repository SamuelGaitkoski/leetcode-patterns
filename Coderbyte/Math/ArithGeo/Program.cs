namespace CodingPatterns.Coderbyte.Math.ArithGeo;

// Runs the Coderbyte examples plus a "neither" case.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int[] Input, string Expected)[]
        {
            (new[] { 2, 4, 6, 8 }, "Arithmetic"),
            (new[] { 2, 6, 18, 54 }, "Geometric"),
            (new[] { 1, 2, 4, 8 }, "Geometric"),
            (new[] { 1, 2, 3, 5 }, "-1"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.ArithGeo(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"ArithGeo([{string.Join(",", input)}]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
