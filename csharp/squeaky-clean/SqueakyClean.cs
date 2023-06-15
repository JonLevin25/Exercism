using System;
using System.Text;

public static class Identifier
{
 
    const int AlphaInt = (int)'α';
    const int OmegaInt = (int)'ω';

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
            var cInt = (int)c;

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
                i++;
            }
            else if (char.IsLetter(c) && !IsInRange(cInt, AlphaInt, OmegaInt))
            {
                sb.Append(c);
            }

            i++;
        }

        return sb.ToString();
    }

    private static bool IsInRange(int x, int min, int max) => min <= x && x <= max;
}
