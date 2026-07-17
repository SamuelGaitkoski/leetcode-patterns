# Run Length

- **Source:** Coderbyte (Medium)
- **Pattern:** Strings

## The problem in my own words

Compress a string with run-length encoding: replace each run of a repeated
character with the run length followed by the character. `"wwwggopp"` →
`"3w2g1o2p"`. Even single characters get a count of `1`.

## Key insight that unlocked it

Process the string one **run** at a time rather than one character at a time.
From each starting index, extend while the next character matches, emit the
`count` + character, then jump the cursor past the whole run.

## Approach

Outer loop over run starts; inner loop counts identical following characters;
append `count` and `char`; advance `i` by `count`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Run scan | O(n) | O(n) |

## What tripped me up

- Advancing the outer index by the full run length (`i += count`) so each run is
  emitted exactly once.

## Run it

```bash
cd Coderbyte/Strings/RunLength
dotnet run
```
