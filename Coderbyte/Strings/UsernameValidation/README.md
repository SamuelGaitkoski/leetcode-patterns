# Username Validation

- **Source:** Coderbyte (Easy)
- **Pattern:** Strings

## The problem in my own words

Validate a username against four rules and return `"true"`/`"false"`:

1. Length is between 4 and 25 characters.
2. It starts with a letter.
3. It contains only letters, digits and underscores.
4. It does not end with an underscore.

## Key insight that unlocked it

Each rule is an independent boolean test. Expressing them as four predicates
`AND`-ed together keeps the logic flat and readable, and `&&` short-circuits so a
cheap failing rule stops the rest.

## Approach

Combine the four checks with `&&`: length range, `IsLetter(str[0])`, an `All`
over the characters for the allowed set, and `str[^1] != '_'`.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Rule predicates | O(n) | O(1) |

## What tripped me up

- Rules 2 and 4 index the first and last characters, so the length check has to
  come first (short-circuit) to stay safe on very short inputs.
- `str[^1]` is the C# index-from-end operator — a concise way to read the last
  character.

## Run it

```bash
cd Coderbyte/Strings/UsernameValidation
dotnet run
```
