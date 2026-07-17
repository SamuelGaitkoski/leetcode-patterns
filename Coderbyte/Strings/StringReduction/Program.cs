namespace CodingPatterns.Coderbyte.Strings.StringReduction;

// Coderbyte examples plus single-letter and two-letter cases.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, int Expected)[]
        {
            ("cab", 2),    // counts 1,1,1 all odd -> 2
            ("bcab", 1),   // counts 2,1,1 mixed parity -> 1
            ("aa", 2),     // one distinct letter -> length
            ("ab", 1),     // "ab" -> "c"
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.StringReduction(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"StringReduction(\"{input}\") = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
