# Longest Word

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings

## The problem in my own words

Return the longest word in a sentence. Punctuation (`!`, `&`, `.`, …) should be
stripped before measuring length, and if two words tie, the first one wins.

## Key insight that unlocked it

"Longest" only needs a running maximum, not a full sort. Using a strict
greater-than when comparing lengths naturally keeps the **first** of any tie.

## Approach

Scan character by character, accumulating a "word" from runs of letters/digits.
Any other character (space **or** punctuation) ends the current word and is a
separator — so `"hello,world"` splits into two words rather than merging. Track
the longest word seen.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Split + scan | O(n) | O(n) |

## What tripped me up

- My first version split only on spaces and stripped punctuation *within* each
  token, which glued `"hello,world"` into `"helloworld"` — a "word" that never
  appeared. Treating punctuation as a separator fixes it.
- Digits still count as word characters, matching the challenge's "letters and
  numbers" wording.
- Using `>=` instead of `>` would return the *last* longest word instead of the
  first.

## Run it

```bash
cd Coderbyte/Strings/LongestWord
dotnet run
```
