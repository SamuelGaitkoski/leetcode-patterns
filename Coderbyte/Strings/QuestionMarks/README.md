# Question Marks

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings

## The problem in my own words

The string mixes single digits, letters and `?`. Return `"true"` when every pair
of **consecutive** digits that adds up to 10 has exactly three `?` between them,
and there is at least one such pair. Otherwise `"false"`.

## Key insight that unlocked it

I don't need to find and index pairs explicitly. Walking left to right, I only
ever compare each digit with the **previous** digit, counting the `?` seen in
between. Resetting that counter at each digit keeps "between this digit and the
last one" correct automatically.

## Approach

Track `previousDigit` and a running `questionMarks` counter. On each digit: if
`previousDigit + digit == 10`, the counter must be exactly 3 (else fail). Then
reset the counter and update `previousDigit`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Single pass | O(n) | O(1) |

## What tripped me up

- "At least one pair" — a string with no two consecutive digits summing to 10
  returns `"false"`, not `"true"`.
- Resetting the `?` counter on **every** digit (not just matching pairs) is what
  keeps the count scoped to the gap between the two digits in question.

## Run it

```bash
cd Coderbyte/Strings/QuestionMarks
dotnet run
```
