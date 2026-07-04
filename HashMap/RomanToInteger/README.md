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

### Approach 1 — "look both ways" (`RomanToInt`) — my original attempt, corrected

This keeps the exact idea from my first attempt: one `if` per symbol, using
**both** neighbours.

- Look at the **previous** char to decide whether a larger numeral is reduced —
  e.g. an `M` preceded by `C` is `900` (CM), otherwise `1000`.
- Look at the **next** char to *skip* a smaller numeral that is only a
  subtractive prefix — e.g. the `C` in `CM` is already counted when we reach the
  `M`, so the `C` adds nothing on its own.

Two corrections vs. the crashing version:

1. **The bounds bug.** `s[i + 1]` was read with no guard, so the last character
   blew up with `IndexOutOfRangeException`. The fix is `hasNext = i + 1 < s.Length`
   and treating "no next char" as "not a larger numeral":
   `(!hasNext || (s[i + 1] != 'D' && s[i + 1] != 'M'))`.
2. **Dead variables removed.** The original declared `prevI`, `prevX`, `prevC`
   and set them to `false`, but never read them — so they did nothing and are
   gone.

It's the most verbose of the three, but it maps one-to-one onto how the numerals
are described in the prompt, which is why it was a natural first instinct.

### Approach 2 — left-to-right, compare with next (`RomanToIntCompareNext`)

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
| Look both ways (my attempt) | O(n) | O(1)  |
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
