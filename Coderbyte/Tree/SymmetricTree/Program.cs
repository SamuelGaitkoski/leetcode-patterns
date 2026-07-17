namespace CodingPatterns.Coderbyte.Tree.SymmetricTree;

// A symmetric tree, an asymmetric tree, and a single node.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string[] Tree, string Expected)[]
        {
            (new[] { "1", "2", "2", "3", "#", "#", "3" }, "true"),
            (new[] { "1", "2", "2", "#", "3", "#", "3" }, "false"),
            (new[] { "1" }, "true"),
        };

        bool allPassed = true;
        foreach (var (tree, expected) in cases)
        {
            string actual = solution.SymmetricTree(tree);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"SymmetricTree([{string.Join(",", tree)}]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
