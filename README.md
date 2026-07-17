# Coding Questions Patterns 🧩

A personal practice repository for mastering data structures and algorithms in **C#**, organized **by pattern** rather than by problem number. Solutions come from multiple platforms (**LeetCode**, **Coderbyte**), each kept in its own top-level folder so the sources never mix.

> Looking for problems by difficulty instead of by pattern? See [`LEVELS.md`](LEVELS.md).

## Why organize by pattern?

Most LeetCode problems are variations on a small set of recurring techniques. Once you recognize the *pattern* behind a problem, the solution often follows naturally. Grouping solutions this way trains pattern-recognition — the single most useful skill for interviews and real engineering work — instead of memorizing one-off answers.

## How it's organized

Each pattern lives in its own folder. Inside, every problem gets its own subfolder containing:

- **`<Problem>.cs`** — the solution(s), with educational inline comments. When a problem has more than one instructive approach (e.g. brute force vs. optimal), each is a separate method.
- **`README.md`** — a write-up filled out from [`TEMPLATE.md`](TEMPLATE.md): the approach, key insight, complexity, and what tripped me up.
- **`Program.cs`** — a small runnable test harness so each solution can be verified independently.

The top level splits by **source**; inside each source, problems are grouped **by pattern**, and every problem is a self-contained subfolder (its own .NET project):

```
coding-questions-patterns/
├── README.md            ← you are here (pattern index)
├── LEVELS.md            ← the same problems indexed by difficulty
├── TEMPLATE.md          ← copy this for every new problem
├── LeetCode/
│   ├── HashMap/
│   │   ├── TwoSum/
│   │   │   ├── TwoSum.csproj
│   │   │   ├── TwoSum.cs
│   │   │   ├── Program.cs
│   │   │   └── README.md
│   │   └── RomanToInteger/
│   ├── Math/
│   │   └── PalindromeNumber/
│   └── Strings/
│       └── LongestCommonPrefix/
└── Coderbyte/
    ├── Strings/
    ├── Math/
    └── ...               ← same pattern folders, mirrored per source
```

## Patterns

| Pattern        | Idea in one line                                                        |
| -------------- | ---------------------------------------------------------------------- |
| HashMap        | Trade space for time — remember what you've seen for O(1) lookups.      |
| Two Pointers   | Walk two indices toward each other (or in tandem) over sorted data.     |
| Sliding Window | Maintain a moving range and update it incrementally instead of redoing work. |
| Binary Search  | Halve the search space each step on monotonic / sorted data.           |
| Linked List    | Pointer manipulation — fast/slow pointers, reversal, dummy heads.       |
| Math           | Digit/number manipulation — modulo, integer division, overflow care.   |
| Strings        | Character-level scanning — compare positions across strings, prefixes/suffixes. |
| Stack          | Last-in-first-out matching — brackets, spans, nearest-smaller/greater.  |
| Tree           | Binary-tree traversal and structure — preorder, symmetry, construction. |
| Matrix         | 2-D grid scanning — sliding blocks, row/column walks, determinants.     |
| Sorting        | Order the data first, then a single linear pass solves it.             |
| Dynamic Programming | Build answers from overlapping subproblems (or a combinatorial shortcut). |

## Progress

| Problem | Source | Pattern | Difficulty | Solution |
| ------- | ------ | ------- | ---------- | -------- |
| [1. Two Sum](https://leetcode.com/problems/two-sum/) | LeetCode | HashMap | Easy | [LeetCode/HashMap/TwoSum/](LeetCode/HashMap/TwoSum/) |
| [9. Palindrome Number](https://leetcode.com/problems/palindrome-number/) | LeetCode | Math | Easy | [LeetCode/Math/PalindromeNumber/](LeetCode/Math/PalindromeNumber/) |
| [13. Roman to Integer](https://leetcode.com/problems/roman-to-integer/) | LeetCode | HashMap | Easy | [LeetCode/HashMap/RomanToInteger/](LeetCode/HashMap/RomanToInteger/) |
| [14. Longest Common Prefix](https://leetcode.com/problems/longest-common-prefix/) | LeetCode | Strings | Easy | [LeetCode/Strings/LongestCommonPrefix/](LeetCode/Strings/LongestCommonPrefix/) |
| Alphabet Soup | Coderbyte | Strings | Easy | [Coderbyte/Strings/AlphabetSoup/](Coderbyte/Strings/AlphabetSoup/) |
| ArithGeo | Coderbyte | Math | Easy | [Coderbyte/Math/ArithGeo/](Coderbyte/Math/ArithGeo/) |
| Check Numbers | Coderbyte | Math | Easy | [Coderbyte/Math/CheckNumbers/](Coderbyte/Math/CheckNumbers/) |
| Fibonacci Checker | Coderbyte | Math | Easy | [Coderbyte/Math/FibonacciChecker/](Coderbyte/Math/FibonacciChecker/) |
| Find Intersection | Coderbyte | Two Pointers | Easy | [Coderbyte/TwoPointers/FindIntersection/](Coderbyte/TwoPointers/FindIntersection/) |
| First Factorial | Coderbyte | Math | Easy | [Coderbyte/Math/FirstFactorial/](Coderbyte/Math/FirstFactorial/) |
| First Reverse | Coderbyte | Strings | Easy | [Coderbyte/Strings/FirstReverse/](Coderbyte/Strings/FirstReverse/) |
| Letter Capitalize | Coderbyte | Strings | Easy | [Coderbyte/Strings/LetterCapitalize/](Coderbyte/Strings/LetterCapitalize/) |
| Letter Changes | Coderbyte | Strings | Easy | [Coderbyte/Strings/LetterChanges/](Coderbyte/Strings/LetterChanges/) |
| Longest Word | Coderbyte | Strings | Easy | [Coderbyte/Strings/LongestWord/](Coderbyte/Strings/LongestWord/) |
| Moving Median | Coderbyte | Sliding Window | Easy | [Coderbyte/SlidingWindow/MovingMedian/](Coderbyte/SlidingWindow/MovingMedian/) |
| Other Products | Coderbyte | Math | Easy | [Coderbyte/Math/OtherProducts/](Coderbyte/Math/OtherProducts/) |
| Palindrome | Coderbyte | Strings | Easy | [Coderbyte/Strings/Palindrome/](Coderbyte/Strings/Palindrome/) |
| Power of 2 | Coderbyte | Math | Easy | [Coderbyte/Math/PowerOfTwo/](Coderbyte/Math/PowerOfTwo/) |
| Product Digits | Coderbyte | Math | Easy | [Coderbyte/Math/ProductDigits/](Coderbyte/Math/ProductDigits/) |
| Question Marks | Coderbyte | Strings | Easy | [Coderbyte/Strings/QuestionMarks/](Coderbyte/Strings/QuestionMarks/) |
| Remove Brackets | Coderbyte | Stack | Easy | [Coderbyte/Stack/RemoveBrackets/](Coderbyte/Stack/RemoveBrackets/) |
| Simple Adding | Coderbyte | Math | Easy | [Coderbyte/Math/SimpleAdding/](Coderbyte/Math/SimpleAdding/) |
| Simple Symbols | Coderbyte | Strings | Easy | [Coderbyte/Strings/SimpleSymbols/](Coderbyte/Strings/SimpleSymbols/) |
| String Periods | Coderbyte | Strings | Easy | [Coderbyte/Strings/StringPeriods/](Coderbyte/Strings/StringPeriods/) |
| Time Convert | Coderbyte | Math | Easy | [Coderbyte/Math/TimeConvert/](Coderbyte/Math/TimeConvert/) |
| Username Validation | Coderbyte | Strings | Easy | [Coderbyte/Strings/UsernameValidation/](Coderbyte/Strings/UsernameValidation/) |
| Vowel Square | Coderbyte | Matrix | Easy | [Coderbyte/Matrix/VowelSquare/](Coderbyte/Matrix/VowelSquare/) |

## Running a solution

Each problem folder is a self-contained .NET console project:

```bash
cd LeetCode/HashMap/TwoSum
dotnet run
```

> Requires the [.NET SDK](https://dotnet.microsoft.com/download).
