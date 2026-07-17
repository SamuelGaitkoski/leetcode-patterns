namespace CodingPatterns.Coderbyte.Tree.TreeConstructor;

// A valid tree, a two-parents violation, and a too-many-children violation.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string[] Pairs, string Expected)[]
        {
            (new[] { "(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)" }, "true"),
            (new[] { "(1,2)", "(1,3)" }, "false"),            // node 1 has two parents
            (new[] { "(1,2)", "(3,2)", "(5,2)" }, "false"),   // node 2 has three children
            (new[] { "(1,2)", "(2,1)", "(3,4)" }, "false"),   // disconnected cycle 1<->2, root 4
        };

        bool allPassed = true;
        foreach (var (pairs, expected) in cases)
        {
            string actual = solution.TreeConstructor(pairs);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"TreeConstructor([{string.Join(",", pairs)}]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
