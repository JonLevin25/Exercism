using System;
using System.Linq;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        char lastChar = input[0];
        int counter = 0;
        StringBuilder sb = new StringBuilder();

        foreach (var c in input)
        {
            if (c != lastChar)
            {
                AppendEncoded(sb, lastChar, counter);    
                lastChar = c;
                counter = 0;
            }

            counter++;
        }

        AppendEncoded(sb, lastChar, counter); // last char edge case
        return sb.ToString();
    }

    public static string Decode(string input)
    {
        string countStr = "";
        StringBuilder sb = new StringBuilder();

        foreach (var c in input)
        {
            if (char.IsDigit(c))
            {
                countStr += c;
            }
            else
            {
                int count = GetCount(countStr);
                AppendDecoded(sb, c, count);
                countStr = "";
            } 
        }

        return sb.ToString();
    }

    
    private static void AppendEncoded(StringBuilder sb, char c, int count)
    {
        if (count != 1) sb.Append(count);
        sb.Append(c);
    }

    private static void AppendDecoded(StringBuilder sb, char c, int count)
    {
        sb.Append(c, count);
    }

    private static int GetCount(string count)
    {
        if (string.IsNullOrEmpty(count)) return 1;
        else return int.Parse(count);
    }
}
