namespace TextLibrary;

public static class TextTools
{
    public static bool IsPalindrome(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        string normalized = new(text.Where(char.IsLetterOrDigit).Select(char.ToLowerInvariant).ToArray());
        return normalized.SequenceEqual(normalized.Reverse());
    }

    public static int CountSentences(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
            .Count(part => !string.IsNullOrWhiteSpace(part));
    }

    public static string Reverse(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return new string(text.Reverse().ToArray());
    }
}
