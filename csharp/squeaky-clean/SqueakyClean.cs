using System;
using System.Text;

public static class Identifier
{
 
    const char Alpha = 'α';
    const char Omega = 'ω';

    public static string Clean(string identifier)
    {
        // TODO: ' ' => '_' (everywhere)
        // TODO: ControChars => "CTRL"
        // TODO: kebab-case => camelCase
        // TODO: remove non-letter chars
        // TODO: Omit greek lower case ('α'-'ω')
        var i = 0;
        var sb = new StringBuilder();
        while (i < identifier.Length)
        {
            var c = identifier[i];
            if (c == ' ')
            {
                sb.Append('_');
            }
            else if (char.IsControl(c)){
                sb.Append("CTRL");
            }
            else if (c == '-')
            {
                sb.Append(char.ToUpper(identifier[i+1]));
            }
            else if (char.IsLetter(c) && !IsCharInRange(c, Alpha, Omega))
            {
                sb.Append(c);
            }

            i++;
        }

        return sb.ToString();
    }

    private static bool IsCharInRange(char c, char lowerLetter, char higherLetter)
    {
            var cVal = char.GetNumericValue(c);
            var lowVal = char.GetNumericValue(lowerLetter);
            var highVal = char.GetNumericValue(higherLetter);

            return lowVal <= cVal && cVal <= highVal;
    }
}
