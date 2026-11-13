namespace SearchReportLibrary;

public static class SearchReporter
{
    private sealed record Match(string File, int Number, string Line);

    public static string SearchInFile(string filePath, string word, string reportPath)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException("Файл не найден.", filePath);
        ArgumentException.ThrowIfNullOrWhiteSpace(word);

        var matches = File.ReadAllLines(filePath)
            .Select((line, index) => new Match(filePath, index + 1, line))
            .Where(x => x.Line.Contains(word, StringComparison.OrdinalIgnoreCase))
            .ToArray();

        string report = BuildReport(filePath, word, matches);
        WriteReport(reportPath, report);
        return report;
    }

    public static string SearchInFolder(string folderPath, string word, string reportPath, string searchPattern = "*.txt")
    {
        if (!Directory.Exists(folderPath)) throw new DirectoryNotFoundException(folderPath);
        ArgumentException.ThrowIfNullOrWhiteSpace(word);

        var files = Directory.GetFiles(folderPath, searchPattern, SearchOption.AllDirectories);
        var matches = files.AsParallel()
            .SelectMany(file =>
            {
                try
                {
                    return File.ReadAllLines(file)
                        .Select((line, index) => new Match(file, index + 1, line))
                        .Where(x => x.Line.Contains(word, StringComparison.OrdinalIgnoreCase));
                }
                catch (IOException)
                {
                    return Enumerable.Empty<Match>();
                }
            })
            .ToArray();

        string report = BuildReport(folderPath, word, matches);
        WriteReport(reportPath, report);
        return report;
    }

    private static string BuildReport(string source, string word, IEnumerable<Match> matches)
    {
        Match[] found = matches.ToArray();
        string details = found.Length == 0
            ? "Совпадений не найдено."
            : string.Join(Environment.NewLine, found.Select(x => $"{x.File} — строка {x.Number}: {x.Line}"));
        return $"Отчёт поиска\nИсточник: {source}\nИскомое слово: {word}\nСовпадений: {found.Length}\n\n{details}";
    }

    private static void WriteReport(string reportPath, string report)
    {
        string fullPath = Path.GetFullPath(reportPath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, report);
    }
}
