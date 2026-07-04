# Project conventions — leetcode-patterns

Instructions for working in this repository. These are project-specific and
apply on top of any global config.

## Commits

- **One file per commit.** Each commit changes exactly one file. Never bundle
  multiple files into a single commit, even when they belong to the same change.
- **Conventional Commits.** Every commit message follows
  `type(scope): summary`, where:
  - `type` is one of: `feat`, `fix`, `docs`, `test`, `refactor`, `chore`.
  - `scope` is the problem folder in kebab-case (e.g. `two-sum`,
    `roman-to-integer`, `palindrome-number`), or `repo` for root-level files
    (README, TEMPLATE, .gitignore, this file).
  - `summary` is imperative and lowercase, no trailing period.
- Map file types to commit types:
  - solution `.cs` file → `feat` (new problem/approach) or `fix` (bug fix)
  - `Program.cs` test harness → `test`
  - `README.md` write-up → `docs`
  - `.csproj` / structural / config → `chore`
- Examples:
  - `feat(roman-to-integer): add look-both-ways solution`
  - `test(roman-to-integer): cover all four approaches`
  - `docs(roman-to-integer): explain the index bounds bug`
  - `chore(repo): add math pattern to structure diagram`
- Always `git push` after committing.

## Repository structure

- Solutions are organized **by pattern** (e.g. `HashMap/`, `Math/`,
  `TwoPointers/`).
- Every problem is a **self-contained subfolder** inside its pattern folder,
  and is its own .NET console project:
  ```
  <Pattern>/<ProblemName>/
    ├── <ProblemName>.csproj   # Exe, net8.0, RootNamespace LeetCodePatterns.<Pattern>.<ProblemName>
    ├── <ProblemName>.cs       # public class Solution — one method per approach
    ├── Program.cs             # public static class Program with Main — runnable tests
    └── README.md              # filled out from /TEMPLATE.md
  ```
- Multiple approaches to a problem live as **separate methods** on `Solution`
  (e.g. brute force vs. optimal), each with a short comment stating the approach
  and its time/space complexity.
- Keep `Solution` methods as **instance methods** (not `static`) to mirror
  LeetCode's submission signature, even when the IDE suggests making them static.

## Adding a new problem

1. Create `<Pattern>/<ProblemName>/` (create the pattern folder if new).
2. Copy `TEMPLATE.md` → the problem's `README.md` and fill every section.
3. Write `Solution` with one method per approach; add a `Program.cs` harness that
   runs the LeetCode examples plus any edge cases and prints PASS/FAIL.
4. Verify with `dotnet run` from the problem folder — it must print all-passed.
5. Update the root `README.md`: structure diagram, patterns table (if new
   pattern), and the progress table row.

## Style

- Idiomatic, clear C#. Comments should be **educational** — explain *why*, not
  restate the code — but kept concise.
