namespace CodingPatterns.Coderbyte.Strings.LetterChanges;

// Runs the Coderbyte examples plus the alphabet-wrap edge case.
public static class Program
{
    public static int Main()
    {
        var solution = new Solution();

        var cases = new (string Input, string Expected)[]
        {
            ("hello", "Ifmmp"),  // h->i(I) e->f l->m l->m o->p
            ("abcd", "bcdE"),    // e is a vowel -> E
            ("cool", "dppm"),    // no vowels after shifting
            ("zzz", "AAA"),      // z wraps to a, then a -> A
        };

        bool allPassed = true;
        foreach (var (input, expected) in cases)
        {
            string actual = solution.LetterChanges(input);
            bool pass = actual == expected;
            allPassed &= pass;
            Console.WriteLine($"LetterChanges(\"{input}\") = \"{actual}\" (expected \"{expected}\") {(pass ? "PASS" : "FAIL")}");
        }

        Console.WriteLine(allPassed ? "All cases passed ✅" : "Some cases failed ❌");
        return allPassed ? 0 : 1;
    }
}
