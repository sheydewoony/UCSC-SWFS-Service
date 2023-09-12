using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Solution
{
    static public void Main(String[] args)
    {
        Console.WriteLine(GetRecipient("Hey @Joe_Bloggs what time are we meeting @FredBlogg ?", 2));
    }
    public static string GetRecipient(string message, int position)
    {
        string[] words = message.Split(' ');
        List<string> recipients = new List<string>();

        foreach (string word in words)
        {
            if (word.StartsWith("@") && IsValidUserName(word.Substring(1)))
            {
                recipients.Add(word.Substring(1));
            }
        }

        if (position <= recipients.Count)
        {
            return recipients[position - 1];
        }
        return string.Empty;
    }

    public static bool IsValidUserName(string username)
    {
        string pattern = @"^[A-Za-z0-9_-]+$";
        return Regex.IsMatch(username, pattern);
    }
}