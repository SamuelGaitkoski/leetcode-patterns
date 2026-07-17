namespace CodingPatterns.Coderbyte.Matrix.MatrixDeterminant;

// 2x2 example, a singular 3x3, a diagonal 3x3, and a non-square input.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string[] Input, int Expected)[]
        {
            (new[] { "1", "2", "<>", "3", "4" }, -2),                                  // [[1,2],[3,4]]
            (new[] { "1", "2", "3", "<>", "4", "5", "6", "<>", "7", "8", "9" }, 0),     // singular
            (new[] { "2", "0", "0", "<>", "0", "3", "0", "<>", "0", "0", "4" }, 24),    // diagonal 2*3*4
            (new[] { "1", "2", "3", "<>", "4", "5" }, -1),                              // not square
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.MatrixDeterminant(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"MatrixDeterminant([{string.Join(",", input)}]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
