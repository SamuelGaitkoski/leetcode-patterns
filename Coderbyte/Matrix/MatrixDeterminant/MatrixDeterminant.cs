namespace CodingPatterns.Coderbyte.Matrix.MatrixDeterminant;

using System.Collections.Generic;

// Coderbyte — Matrix Determinant
// strArr is a flat list of integer strings with "<>" markers separating rows.
// Build the matrix and return its determinant; return -1 if it isn't square.
// e.g. ["1","2","<>","3","4"] is [[1,2],[3,4]] with determinant -2.
public class Solution
{
    // Parse the rows, verify squareness, then compute the determinant by cofactor
    // (Laplace) expansion along the first row. O(n!) in the worst case, which is
    // fine for the 6x6 cap. O(n^2) space for the submatrices.
    public int MatrixDeterminant(string[] strArr)
    {
        List<List<int>> matrix = Parse(strArr);

        if (!IsSquare(matrix))
            return -1;

        return Determinant(matrix);
    }

    private static List<List<int>> Parse(string[] strArr)
    {
        var matrix = new List<List<int>>();
        var row = new List<int>();

        foreach (string token in strArr)
        {
            if (token == "<>")
            {
                matrix.Add(row);            // "<>" ends the current row
                row = new List<int>();
            }
            else
            {
                row.Add(int.Parse(token));
            }
        }
        matrix.Add(row);                     // the final row has no trailing marker

        return matrix;
    }

    private static bool IsSquare(List<List<int>> matrix)
    {
        foreach (var row in matrix)
            if (row.Count != matrix.Count)
                return false;
        return true;
    }

    private static int Determinant(List<List<int>> m)
    {
        int n = m.Count;

        if (n == 1)
            return m[0][0];
        if (n == 2)
            return m[0][0] * m[1][1] - m[0][1] * m[1][0];

        int determinant = 0;
        int sign = 1;
        for (int col = 0; col < n; col++)
        {
            // Cofactor: expand along row 0, removing row 0 and the current column.
            determinant += sign * m[0][col] * Determinant(Minor(m, col));
            sign = -sign;
        }
        return determinant;
    }

    // The submatrix with row 0 and column `skipCol` removed.
    private static List<List<int>> Minor(List<List<int>> m, int skipCol)
    {
        var minor = new List<List<int>>();
        for (int i = 1; i < m.Count; i++)
        {
            var row = new List<int>();
            for (int j = 0; j < m.Count; j++)
            {
                if (j != skipCol)
                    row.Add(m[i][j]);
            }
            minor.Add(row);
        }
        return minor;
    }
}
