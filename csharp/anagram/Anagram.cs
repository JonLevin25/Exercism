using System;
using System.Linq;
using System.Collections.Generic;

public class Anagram
{
    private string _baseWord;
    public Anagram(string baseWord)
    {
        _baseWord = baseWord.ToLower();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> potentials = potentialMatches.ToList();
        
        return potentialMatches
            .Where(word => IsAnagram(word.ToLower(), _baseWord))
            .ToArray();
    }

    private static bool IsAnagram(string word, string baseWord)
    {
        if (word == baseWord) return false;
        return word.OrderBy(c => c).SequenceEqual(baseWord.OrderBy(c => c));
    }
}