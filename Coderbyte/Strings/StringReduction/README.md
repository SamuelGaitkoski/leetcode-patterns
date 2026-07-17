# String Reduction

- **Source:** Coderbyte (Medium)
- **Pattern:** Strings (secondary: Math / invariants)

## The problem in my own words

The string is made of only `a`, `b`, `c`. Any two **different** adjacent
characters can be replaced by the third (`ac` → `b`). Apply this as many times as
possible and return the length of the shortest string you can reach.

## Key insight that unlocked it

Simulating the reductions works but is fiddly. The elegant observation is that a
reduction changes the counts of all three letters by ±1, which flips each count's
parity together — so the **parities** of the counts of `a`, `b`, `c` are the
invariant that decides the outcome:

- Only one distinct letter → nothing can reduce → answer is the length.
- Otherwise the string collapses to length **1**, *unless* all three counts have
  the same parity, in which case it bottoms out at **2**.

## Approach

Count `a`, `b`, `c`. Apply the rule above — no simulation needed.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Imported (repeated simulation) | O(n²) or worse | O(n) |
| Parity closed form | O(n) | O(1) |

## What tripped me up

- The "only one distinct character" case is special — `"aaa"` can't reduce at all,
  so it returns its full length rather than 1 or 2.

## Run it

```bash
cd Coderbyte/Strings/StringReduction
dotnet run
```
