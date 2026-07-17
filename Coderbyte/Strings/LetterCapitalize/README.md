# Letter Capitalize

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings

## The problem in my own words

Uppercase the first letter of every word. Words are separated by exactly one
space, so "the start of a word" is simply "the first character, or the character
immediately after a space".

## Key insight that unlocked it

I don't need to split into words at all. A single left-to-right pass can decide,
for each character, whether it begins a word by looking at its left neighbour.

## Approach

Walk the char buffer. Uppercase a character when its index is `0` or the
previous character is a space.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Single pass | O(n) | O(n) |

## What tripped me up

- The "single space between words" guarantee is what lets the neighbour check be
  this simple; multiple/leading spaces would need a little more care.

## Run it

```bash
cd Coderbyte/Strings/LetterCapitalize
dotnet run
```
