# LeetCode Patterns 🧩

A personal practice repository for mastering data structures and algorithms in **C#**, organized **by pattern** rather than by problem number.

## Why organize by pattern?

Most LeetCode problems are variations on a small set of recurring techniques. Once you recognize the *pattern* behind a problem, the solution often follows naturally. Grouping solutions this way trains pattern-recognition — the single most useful skill for interviews and real engineering work — instead of memorizing one-off answers.

## How it's organized

Each pattern lives in its own folder. Inside, every problem gets its own subfolder containing:

- **`<Problem>.cs`** — the solution(s), with educational inline comments. When a problem has more than one instructive approach (e.g. brute force vs. optimal), each is a separate method.
- **`README.md`** — a write-up filled out from [`TEMPLATE.md`](TEMPLATE.md): the approach, key insight, complexity, and what tripped me up.
- **`Program.cs`** — a small runnable test harness so each solution can be verified independently.

Every problem is a self-contained subfolder (its own .NET project) inside its pattern folder:

```
leetcode-patterns/
├── README.md            ← you are here
├── TEMPLATE.md          ← copy this for every new problem
├── HashMap/
│   └── TwoSum/
│       ├── TwoSum.csproj
│       ├── TwoSum.cs
│       ├── Program.cs
│       └── README.md
├── Math/
│   └── PalindromeNumber/
│       ├── PalindromeNumber.csproj
│       ├── PalindromeNumber.cs
│       ├── Program.cs
│       └── README.md
├── TwoPointers/         ← (coming soon)
├── SlidingWindow/       ← (coming soon)
├── BinarySearch/        ← (coming soon)
└── LinkedList/          ← (coming soon)
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

## Progress

| Problem | Pattern | Difficulty | Solution |
| ------- | ------- | ---------- | -------- |
| [1. Two Sum](https://leetcode.com/problems/two-sum/) | HashMap | Easy | [HashMap/TwoSum/](HashMap/TwoSum/) |
| [9. Palindrome Number](https://leetcode.com/problems/palindrome-number/) | Math | Easy | [Math/PalindromeNumber/](Math/PalindromeNumber/) |

## Running a solution

Each problem folder is a self-contained .NET console project:

```bash
cd HashMap/TwoSum
dotnet run
```

> Requires the [.NET SDK](https://dotnet.microsoft.com/download).
