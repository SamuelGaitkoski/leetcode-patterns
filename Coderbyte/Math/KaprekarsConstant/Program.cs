namespace CodingPatterns.Coderbyte.Math.KaprekarsConstant;

// Coderbyte example plus the fixed point itself.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int Input, int Expected)[]
        {
            (3524, 3),   // Coderbyte example
            (6174, 0),   // already the constant
            (1234, 3),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.KaprekarsConstant(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"KaprekarsConstant({input}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
