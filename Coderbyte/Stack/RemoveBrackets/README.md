# Remove Brackets

- **Source:** Coderbyte (Easy)
- **Pattern:** Stack

## The problem in my own words

Given a string of only `(` and `)`, return the minimum number of brackets to
remove so the rest is correctly matched. `"(()))"` needs `1` removal.

## Key insight that unlocked it

A stack is the natural model for matching: every `(` waits for a `)`. When a `)`
finds a `(` on top, they cancel; otherwise the `)` is unmatched. Whatever remains
on the stack at the end — stray `)`s and unclosed `(`s — is exactly the set that
must be removed, so the answer is the leftover count.

## Approach

Push `(`. On `)`, pop if the top is `(` (a match), else push the `)` as unmatched.
Return the stack size.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Stack matching | O(n) | O(n) |

Two counters (open-so-far and removals) achieve the same in O(1) space, but the
stack makes the "what's left unmatched" idea explicit.

## What tripped me up

- The leftovers include **both** kinds of unmatched bracket — a trailing unclosed
  `(` counts just like a stray `)`.

## Run it

```bash
cd Coderbyte/Stack/RemoveBrackets
dotnet run
```
