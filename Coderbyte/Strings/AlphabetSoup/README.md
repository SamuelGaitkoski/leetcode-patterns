# Alphabet Soup

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings (secondary: Sorting)

## The problem in my own words

Take a string and return it with its letters reordered alphabetically —
`"hello"` becomes `"ehllo"`. Only letters appear in the input.

## Key insight that unlocked it

There's no clever trick: "alphabetical order" *is* a sort. Because the letters
are all the same case, an ordinary ordinal character sort already matches
alphabetical order.

## Approach

Copy the string into a `char[]`, `Array.Sort` it, and build a new string.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Sort characters | O(n log n) | O(n) |

## What tripped me up

- Strings are immutable in C#, so I sort a `char[]` and rebuild rather than
  sorting "in place".
- If mixed case were allowed, ordinal sorting would put all uppercase before
  lowercase — I'd need a case-insensitive comparison instead.

## Run it

```bash
cd Coderbyte/Strings/AlphabetSoup
dotnet run
```
