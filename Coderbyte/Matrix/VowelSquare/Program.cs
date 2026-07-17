namespace CodingPatterns.Coderbyte.Matrix.VowelSquare;

// A block at the origin, a block offset into the grid, and a no-block grid.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string[] Grid, string Expected)[]
        {
            (new[] { "aexx", "aexx", "xxxx" }, "0-0"),
            (new[] { "xxxx", "xaex", "xaex" }, "1-1"),
            (new[] { "abcd", "efgh", "ijkl" }, "not found"),
        };

        bool allPassed = true;
        foreach (var (grid, expected) in cases)
        {
            string actual = solution.VowelSquare(grid);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"VowelSquare([{string.Join(",", grid)}]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
