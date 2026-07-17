# Number Encoding

- **Source:** Coderbyte (Medium)
- **Pattern:** Strings (secondary: HashMap)

## The problem in my own words

Encode a message by replacing each letter with its position in the alphabet
(`a`→1, …, `z`→26). Spaces, symbols and digits stay as they are. `"af5c a#!"`
becomes `"1653 1#!"`.

## Key insight that unlocked it

A letter's alphabet position is pure arithmetic: `c - 'a' + 1`. That removes the
need for the 26-entry lookup map the imported version built — although a
`Dictionary<char,int>` is the equivalent HashMap framing.

## Approach

Walk the string; append `char.ToLower(c) - 'a' + 1` for letters, and the raw
character otherwise.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Single pass | O(n) | O(n) |

## What tripped me up

- Numbers concatenate, they don't sum: `"af"` → `"16"`, not `"7"`. Appending each
  encoded value to a `StringBuilder` handles this naturally.
- Lower-casing first so uppercase letters map to the same positions.

## Run it

```bash
cd Coderbyte/Strings/NumberEncoding
dotnet run
```
