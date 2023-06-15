using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        // Only rotate relevant characters (letters). otherwise pass through as-is
        char[] resultChars = text.Select(c => Rotate(c, shiftKey)).ToArray();
        return new string(resultChars);
    }

    public static char Rotate(char c, int shiftKey)
    {
        const int NumOfLetters = 26;

        // don't rotate spaces/numbers/non-ascii letters, etc.
        if (!c.IsAsciiLetter())
        {
            return c;
        }

        // Normalize case, but remember it for later.
        // Then convert letters a-z to the numbers 0-26, so we can do math on them
        bool isUpper = char.IsUpper(c);
        int normalizedInput = c.ToLower() - 'a';
        
        // advance by shiftKey, but use modulo (%) to wrap around to 0.
        int normalizedResult = (normalizedInput + shiftKey) % NumOfLetters;
        
        // move the result from the range (0-26) back to ('a' - 'z')
        char lowercaseResult = (char)('a' + normalizedResult);

        // if it was uppercase: make sure to convert case back.
        return isUpper
            ? lowercaseResult.ToUpper()
            : lowercaseResult;
    }


    // Helper extensions
    public static bool IsAsciiLetter(this char c) => char.IsAsciiLetter(c);
    public static char ToUpper(this char c) => char.ToUpper(c);
    public static char ToLower(this char c) => char.ToLower(c);
    public static bool IsUpper(this char c) => char.IsUpper(c);
}