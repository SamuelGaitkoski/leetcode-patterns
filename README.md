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

## Progress

| Problem | Source | Pattern | Difficulty | Solution |
| ------- | ------ | ------- | ---------- | -------- |
| [1. Two Sum](https://leetcode.com/problems/two-sum/) | LeetCode | HashMap | Easy | [LeetCode/HashMap/TwoSum/](LeetCode/HashMap/TwoSum/) |
| [9. Palindrome Number](https://leetcode.com/problems/palindrome-number/) | LeetCode | Math | Easy | [LeetCode/Math/PalindromeNumber/](LeetCode/Math/PalindromeNumber/) |
| [13. Roman to Integer](https://leetcode.com/problems/roman-to-integer/) | LeetCode | HashMap | Easy | [LeetCode/HashMap/RomanToInteger/](LeetCode/HashMap/RomanToInteger/) |
| [14. Longest Common Prefix](https://leetcode.com/problems/longest-common-prefix/) | LeetCode | Strings | Easy | [LeetCode/Strings/LongestCommonPrefix/](LeetCode/Strings/LongestCommonPrefix/) |

## Running a solution

Each problem folder is a self-contained .NET console project:

```bash
cd LeetCode/HashMap/TwoSum
dotnet run
```

> Requires the [.NET SDK](https://dotnet.microsoft.com/download).
