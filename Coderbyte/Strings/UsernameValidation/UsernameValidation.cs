namespace CodingPatterns.Coderbyte.Strings.UsernameValidation;

using System.Linq;

// Coderbyte — Username Validation (CodelandUsernameValidation)
// A username is valid when: (1) it is 4–25 characters long, (2) it starts with a
// letter, (3) it contains only letters, digits and underscores, and (4) it does
// not end with an underscore. Return "true" or "false".
public class Solution
{
    // Each rule is an independent predicate; the username is valid only if all
    // four hold. O(n) time, O(1) space.
    public string CodelandUsernameValidation(string str)
    {
        bool valid =
            str.Length is >= 4 and <= 25 &&              // rule 1: length
            char.IsLetter(str[0]) &&                     // rule 2: starts with a letter
            str.All(c => char.IsLetterOrDigit(c) || c == '_') && // rule 3: allowed chars
            str[^1] != '_';                              // rule 4: no trailing underscore

        return valid ? "true" : "false";
    }
}
