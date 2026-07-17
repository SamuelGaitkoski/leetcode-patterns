# Project conventions — coding-questions-patterns

Instructions for working in this repository. These are project-specific and
apply on top of any global config.

## Sources

Solutions come from more than one platform, kept in **separate top-level source
folders** so they never mix:

- `LeetCode/` — LeetCode problems.
- `Coderbyte/` — Coderbyte challenges.

Inside **each** source folder the layout is identical and organized **by
pattern** (see below). The same pattern name may appear under both sources
(e.g. `LeetCode/Strings/` and `Coderbyte/Strings/`).

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

- Under each source folder, solutions are organized **by pattern** (e.g.
  `HashMap/`, `Math/`, `Strings/`, `TwoPointers/`).
- Every problem is a **self-contained subfolder** inside its pattern folder,
  and is its own .NET console project:
  ```
  <Source>/<Pattern>/<ProblemName>/
    ├── <ProblemName>.csproj   # Exe, net8.0, RootNamespace CodingPatterns.<Source>.<Pattern>.<ProblemName>
    ├── <ProblemName>.cs       # public class Solution — one method per approach
    ├── Program.cs             # public static class Program with Main — runnable tests
    └── README.md              # filled out from /TEMPLATE.md
  ```
- The root namespace is `CodingPatterns.<Source>.<Pattern>.<ProblemName>`, where
  `<Source>` is `LeetCode` or `Coderbyte` (e.g.
  `CodingPatterns.Coderbyte.Strings.FirstReverse`).
- Multiple approaches to a problem live as **separate methods** on `Solution`
  (e.g. brute force vs. optimal), each with a short comment stating the approach
  and its time/space complexity.
- Keep `Solution` methods as **instance methods** (not `static`) to mirror
  LeetCode's submission signature, even when the IDE suggests making them static.

## Adding a new problem

1. Create `<Source>/<Pattern>/<ProblemName>/` (create the pattern folder if new).
2. Copy `TEMPLATE.md` → the problem's `README.md` and fill every section.
3. Write `Solution` with one method per approach; add a `Program.cs` harness that
   runs the examples plus any edge cases and prints PASS/FAIL. Put the problem
   statement in a short `//` comment block at the top of the solution `.cs`
   (`// Coderbyte — <Name>` / `// LeetCode #<n> — <Name>`), with the full
   description in `README.md`.
4. Verify with `dotnet run` from the problem folder — it must print all-passed.
5. Update the root `README.md` (structure diagram, patterns table if new
   pattern, progress table row) and `LEVELS.md` (the difficulty index).
6. If a challenge fits more than one pattern, file it under the **primary** one
   and note the secondary in a comment on the solution. If it fits no existing
   pattern, create a new, clearly named pattern folder.

## Style

- Idiomatic, clear C#. Comments should be **educational** — explain *why*, not
  restate the code — but kept concise.
