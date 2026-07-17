namespace CodingPatterns.Coderbyte.Math.SimpleAdding;

// A few known triangular numbers.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int Input, int Expected)[]
        {
            (4, 10),      // 1+2+3+4
            (12, 78),
            (1, 1),
            (100, 5050),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.SimpleAdding(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"SimpleAdding({input}) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
