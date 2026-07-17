namespace CodingPatterns.Coderbyte.DynamicProgramming.ChessboardTraveling;

// Coderbyte — Chessboard Traveling
// str is "(x y)(a b)" giving a start (x,y) and destination (a,b) with a > x and
// b > y. Moving only up and to the right, count the number of distinct paths from
// (x,y) to (a,b). e.g. "(1 1)(2 2)" -> 2.
public class Solution
{
    // Classic grid-paths DP. The ways to reach a cell equal the ways to reach the
    // cell below it plus the cell to its left, with the edges seeded to 1 (only
    // one straight-line path along a border). O(rows * cols) time and space.
    // (Equivalently this is the binomial coefficient C(rows + cols, rows).)
    public int ChessboardTraveling(string str)
    {
        var (x, y, a, b) = Parse(str);
        int rows = a - x;
        int cols = b - y;

        // dp over a (rows+1) x (cols+1) grid of lattice points.
        int[,] dp = new int[rows + 1, cols + 1];
        for (int i = 0; i <= rows; i++)
        {
            for (int j = 0; j <= cols; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 1;                        // only one path along an edge
                else
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[rows, cols];
    }

    // "(1 1)(2 2)" -> (1, 1, 2, 2).
    private static (int X, int Y, int A, int B) Parse(string str)
    {
        string[] points = str.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        int[] start = points[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] end = points[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        return (start[0], start[1], end[0], end[1]);
    }
}
