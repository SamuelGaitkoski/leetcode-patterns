namespace CodingPatterns.Coderbyte.Matrix.VowelSquare;

// Coderbyte — Vowel Square
// The input is a grid of equal-length strings. Find a 2x2 block whose four cells
// are all vowels and return the top-left coordinate as "row-col" (scanning row by
// row). Return "not found" if there is no such block.
public class Solution
{
    // Slide a 2x2 window over the grid; the first block whose four corners are all
    // vowels wins. O(rows * cols) time, O(1) space.
    public string VowelSquare(string[] grid)
    {
        for (int r = 0; r + 1 < grid.Length; r++)
        {
            for (int c = 0; c + 1 < grid[r].Length && c + 1 < grid[r + 1].Length; c++)
            {
                if (IsVowel(grid[r][c]) && IsVowel(grid[r][c + 1]) &&
                    IsVowel(grid[r + 1][c]) && IsVowel(grid[r + 1][c + 1]))
                {
                    return $"{r}-{c}";
                }
            }
        }

        return "not found";
    }

    private static bool IsVowel(char c) => c is 'a' or 'e' or 'i' or 'o' or 'u';
}
