using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    // |As Soon As Possible|ASAP|
    // |Liquid-crystal display|LCD|
    // |Thank George It's Friday!|TGIF|
    public static string Abbreviate(string phrase)
    {
        var cleanedPhrase = '_' + phrase // if phrase does not start with letter, it removes special 'string start' case from regex.
            .Replace("'", "") // apostraphies are problematic, clean them first
            .ToUpper();       // The result will be all uppercase anyway

        var regexPattern = @"[^A-Z]([A-Z])"; // match any non-letter followed by a letter.

        var matches = Regex.Matches(cleanedPhrase, regexPattern);
        var letters = matches.Select(match => match.Groups[1].Value); // Get the group (actual letter we want)
        return string.Join("", letters);
    }
}