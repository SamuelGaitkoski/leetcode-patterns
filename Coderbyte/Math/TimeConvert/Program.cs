namespace CodingPatterns.Coderbyte.Math.TimeConvert;

// Coderbyte example plus exact-hour and under-an-hour cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int Input, string Expected)[]
        {
            (63, "1:3"),    // Coderbyte example
            (120, "2:0"),   // exactly two hours
            (45, "0:45"),   // under an hour
            (0, "0:0"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.TimeConvert(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"TimeConvert({input}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
