# Letter Changes

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings

## The problem in my own words

Two transformations, in order: (1) shift every letter to the next one in the
alphabet, wrapping `z` back to `a`; (2) uppercase every vowel in the shifted
string.

## Key insight that unlocked it

Order matters — the vowels to capitalize are the vowels in the **shifted**
string, not the original. So each character has to be shifted first, then tested
for being a vowel.

## Approach

Single pass over the char buffer:

1. If the character is a letter, advance it (`z` wraps to `a`).
2. If the (now shifted) character is a vowel, uppercase it.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Single pass | O(n) | O(n) |

## What tripped me up

- Forgetting the wrap: `(char)('z' + 1)` is `'{'`, not `'a'`. The `z -> a` case
  needs its own branch.
- Capitalizing vowels from the *original* string instead of the shifted one —
  that gives the wrong answer whenever a shift creates or removes a vowel.

## Run it

```bash
cd Coderbyte/Strings/LetterChanges
dotnet run
```
