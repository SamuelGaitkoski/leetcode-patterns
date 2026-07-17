namespace CodingPatterns.Coderbyte.Tree.PreorderTraversal;

// Full and partial heap-encoded trees.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string[] Tree, string Expected)[]
        {
            (new[] { "1", "2", "3" }, "1 2 3"),
            (new[] { "1", "2", "3", "4", "5" }, "1 2 4 5 3"),
            (new[] { "1", "2", "3", "4", "5", "6", "7" }, "1 2 4 5 3 6 7"),
        };

        bool allPassed = true;
        foreach (var (tree, expected) in cases)
        {
            string actual = solution.PreorderTraversal(tree);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"PreorderTraversal([{string.Join(",", tree)}]) = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
