# 13. Roman to Integer

- **Link:** <https://leetcode.com/problems/roman-to-integer/>
- **Difficulty:** Easy
- **Pattern:** HashMap (symbol → value lookup)

## The problem in my own words

Given a valid Roman numeral string, return its integer value. Numerals are
normally written largest-to-smallest and added up, except for six subtractive
pairs (`IV`, `IX`, `XL`, `XC`, `CD`, `CM`) where a smaller numeral in front of a
larger one means "subtract."

## First-attempt notes

My first version had a separate `if` block for every symbol (`M`, `D`, `C`, `L`,
`X`, `V`, `I`), each checking neighbours by hand — and it crashed with:

```
System.IndexOutOfRangeException: Index was outside the bounds of the array.
```

**Why it crashed:** the code read `s[i + 1]` without first checking that
`i + 1` is still inside the string. On the last character there is no next one,
so for input `"III"` the loop reached `i = 2` and tried to read `s[3]` → out of
bounds. (Side note I confirmed: `'C'` is a `char` literal and `"C"` is a
`string`; since `s[i]` returns a `char`, comparing with `'C'` was correct — the
quotes were never the bug.)

## Key insight that unlocked it

All the special cases collapse into **one rule**:

> If a numeral is smaller than the numeral immediately after it, subtract it.
> Otherwise, add it.

That single comparison covers every subtractive pair, so the seven-way `if`
ladder isn't needed at all.

## Approach(es)

### Approach 1 — handle each subtractive pair explicitly (`RomanToIntExplicit`)

This is the shape of my original attempt, corrected. Scan left to right; when the
current symbol begins one of the six subtractive pairs (`IV IX XL XC CD CM`), add
that pair's value and skip the next character (`i++`); otherwise add the symbol
on its own. The fix vs. the crash is that every look-ahead is guarded — I read a
`next` char only when `i + 1 < s.Length`, using `'\0'` as a harmless sentinel
otherwise, so `s[i + 1]` is never read out of bounds. It's more verbose than the
rule-based version below, but it maps directly to how the numerals are described.

### Approach 2 — left-to-right, compare with next (`RomanToInt`)

Look up each numeral's value. If `value(s[i]) < value(s[i+1])`, subtract it;
otherwise add it. The **only** subtlety is guarding the look-ahead:

```csharp
if (i + 1 < s.Length && current < Values[s[i + 1]])
    total -= current;
else
    total += current;
```

The `i + 1 < s.Length` check must come **first** (C# `&&` short-circuits, so
`s[i + 1]` is never evaluated on the last character). That guard is exactly what
the crashing version was missing.

### Approach 3 — right-to-left, no look-ahead (`RomanToIntRightToLeft`)

This is **LeetCode's Hint 1** ("work the string from back to front and use a
map"). Walk from the end, remembering the largest value seen so far (`rightMax`).
If the current numeral is smaller than `rightMax`, it's a subtractive prefix →
subtract; otherwise add it and update `rightMax`. This avoids the bounds question
entirely because it never needs to peek at a neighbour.

## Complexity

| Approach                    | Time | Space |
| --------------------------- | ---- | ----- |
| Explicit subtractive pairs  | O(n) | O(1)  |
| Left-to-right + next        | O(n) | O(1)  |
| Right-to-left (Hint 1)      | O(n) | O(1)  |

The dictionary is fixed at 7 entries, so it counts as O(1) space. `n` is the
length of the string (≤ 15 by the constraints).

## What tripped me up

- **Reading `s[i + 1]` without a bounds check** — the whole cause of the
  runtime error. Always guard a look-ahead with `i + 1 < s.Length` *before*
  indexing.
- Over-engineering it with a branch per symbol. The subtract-if-smaller rule
  makes almost all of that code disappear.

## Run it

```bash
cd HashMap/RomanToInteger
dotnet run
```
