namespace CodingPatterns.Coderbyte.Math.OtherProducts;

// Coderbyte example plus small arrays.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int[] Input, string Expected)[]
        {
            (new[] { 1, 2, 3, 4, 5 }, "120-60-40-30-24"),
            (new[] { 2, 3 }, "3-2"),
            (new[] { 5 }, "1"),   // product of no other elements is 1
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.OtherProducts(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"OtherProducts([{string.Join(",", input)}]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
