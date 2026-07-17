# Time Convert

- **Source:** Coderbyte (Easy)
- **Pattern:** Math

## The problem in my own words

Given a number of minutes, return it as `"hours:minutes"`. For `63` the answer is
`"1:3"` (1 hour and 3 minutes).

## Key insight that unlocked it

Dividing by 60 splits total minutes into whole hours (`num / 60`) and the leftover
minutes (`num % 60`) — the classic quotient/remainder pair.

## Approach

`hours = num / 60`, `minutes = num % 60`, formatted as `"{hours}:{minutes}"`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Divide + mod | O(1) | O(1) |

## What tripped me up

- The expected format is unpadded (`"1:3"`, not `"1:03"`), so plain interpolation
  is exactly right — no zero-padding.

## Run it

```bash
cd Coderbyte/Math/TimeConvert
dotnet run
```
