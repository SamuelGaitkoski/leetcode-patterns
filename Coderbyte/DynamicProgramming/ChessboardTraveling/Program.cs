namespace CodingPatterns.Coderbyte.DynamicProgramming.ChessboardTraveling;

// Coderbyte example plus larger grids.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, int Expected)[]
        {
            ("(1 1)(2 2)", 2),   // Coderbyte example
            ("(1 1)(3 3)", 6),   // C(4,2)
            ("(2 3)(5 7)", 35),  // rows 3, cols 4 -> C(7,3)
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            int actual = solution.ChessboardTraveling(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"ChessboardTraveling(\"{input}\") = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
