namespace CodingPatterns.Coderbyte.SlidingWindow.MovingMedian;

// arr[0] is the window size; the rest is the stream.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (int[] Input, string Expected)[]
        {
            (new[] { 3, 1, 2, 3, 4, 5 }, "1,1,2,3,4"),
            (new[] { 2, 10, 20, 30 }, "10,15,25"),
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.MovingMedian(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"MovingMedian([{string.Join(",", input)}]) = {actual} (expected {expected}) {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
