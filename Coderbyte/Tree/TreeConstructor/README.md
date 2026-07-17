# Tree Constructor

- **Source:** Coderbyte (Medium)
- **Pattern:** Tree (secondary: HashMap)

> Split out of the source repo's shared `TreeGraphs.cs`, alongside
> [Preorder Traversal](../PreorderTraversal/) and [Symmetric Tree](../SymmetricTree/).

## The problem in my own words

Given a list of `"(child,parent)"` pairs, decide whether they describe a valid
binary tree and return `"true"`/`"false"`. Valid means: no node has more than two
children, no node has more than one parent, and there is exactly one root.

## Key insight that unlocked it

The three rules map directly onto two maps built from the pairs:

- **parent set per child** → catches a node with more than one parent.
- **child count per parent** → catches a node with more than two children.
- a node that never appears as a child is a **root** → there must be exactly one.

## Approach

Parse each pair; accumulate the parent-set and child-count maps; then run the
three checks.

## Complexity

| Approach | Time | Space |
| -------- | ---- | ----- |
| Two maps + checks | O(n) | O(n) |

## What tripped me up

- Parsing multi-digit numbers: splitting `"(12,34)"` on the comma (after trimming
  the parentheses) handles values beyond a single digit, which a character-index
  approach would miss.
- "Exactly one root" — zero roots (a cycle) or more than one (a forest) are both
  invalid.

## Run it

```bash
cd Coderbyte/Tree/TreeConstructor
dotnet run
```
