// using SearchReportLibrary;
//
// string root = Path.Combine(Path.GetTempPath(), "SearchReportDemo");
// Directory.CreateDirectory(root);
// File.WriteAllText(Path.Combine(root, "first.txt"), "C# — язык программирования.\nЯ изучаю C# в Rider.");
// File.WriteAllText(Path.Combine(root, "second.txt"), "Здесь нет нужного слова.\nC# удобен для разработки.");
//
// Console.WriteLine("Поиск в файле:");
// Console.WriteLine(SearchReporter.SearchInFile(
//     Path.Combine(root, "first.txt"), "C#", Path.Combine(root, "single-report.txt")));
//
// Console.WriteLine("\nПоиск во всей папке:");
// Console.WriteLine(SearchReporter.SearchInFolder(
//     root, "C#", Path.Combine(root, "folder-report.txt")));
//
// Console.WriteLine($"\nОтчёты сохранены в: {root}");
