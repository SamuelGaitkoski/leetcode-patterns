# Simple Symbols

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings

## The problem in my own words

A string of `+`, `=` and letters is "acceptable" only if **every** letter is
directly flanked by `+` on both sides. Return `"true"` or `"false"`.

## Key insight that unlocked it

The rule is universally quantified — *every* letter must pass — so the moment a
single letter fails, the whole string is `"false"`. That makes it a short-circuit
scan rather than a search.

## Approach

For each letter, verify it isn't at a boundary and that both neighbours are `+`.
The first failure returns `"false"`; surviving the whole string returns `"true"`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Single pass | O(n) | O(1) |

## What tripped me up

- The imported version stopped at the **first** `+`-wrapped letter and returned
  `"true"`, which passes strings whose *other* letters are unguarded. The rule is
  "all letters", so the corrected version fails on the first unguarded letter
  instead.
- A letter at index `0` or the last index can't have two neighbours, so it always
  fails.

## Run it

```bash
cd Coderbyte/Strings/SimpleSymbols
dotnet run
```
