namespace CodingPatterns.Coderbyte.Math.ArithGeo;

// Coderbyte — ArithGeo
// Return "Arithmetic" if the sequence has a constant difference between terms,
// "Geometric" if it has a constant ratio, or "-1" if neither. (No zeros appear,
// and the array is never all-equal.)
public class Solution
{
    // Test the two patterns in turn. Arithmetic uses a constant additive step;
    // geometric uses a constant multiplicative step (integer ratio here since the
    // inputs are clean integer sequences).
    // O(n) time, O(1) space.
    public string ArithGeo(int[] arr)
    {
        if (IsArithmetic(arr))
            return "Arithmetic";
        if (IsGeometric(arr))
            return "Geometric";
        return "-1";
    }

    private static bool IsArithmetic(int[] arr)
    {
        int diff = arr[1] - arr[0];
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] + diff != arr[i + 1])
                return false;
        }
        return true;
    }

    private static bool IsGeometric(int[] arr)
    {
        int ratio = arr[1] / arr[0];
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] * ratio != arr[i + 1])
                return false;
        }
        return true;
    }
}
