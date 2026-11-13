// using System.Globalization;
//
// Console.OutputEncoding = System.Text.Encoding.UTF8;
// Console.WriteLine("Задание 4. Параллельный анализ резюме");
// Console.WriteLine("Формат каждого файла: ФИО;Город;СтажЛет;ЖелаемаяЗарплата");
// Console.WriteLine("Можно указать несколько путей через пробел или папку. Enter — использовать папку Resumes.");
//
// string input = Console.ReadLine()?.Trim() ?? "";
// string defaultFolder = Path.Combine(AppContext.BaseDirectory, "Resumes");
// List<string> files;
//
// if (string.IsNullOrWhiteSpace(input))
// {
//     files = Directory.Exists(defaultFolder) ? Directory.GetFiles(defaultFolder, "*.txt").ToList() : new();
// }
// else if (Directory.Exists(input))
// {
//     files = Directory.GetFiles(input, "*.txt").ToList();
// }
// else
// {
//     files = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
//         .Select(Path.GetFullPath).Where(File.Exists).ToList();
// }
//
// if (files.Count == 0)
// {
//     Console.WriteLine("Файлы резюме не найдены.");
//     return;
// }
//
// var resumes = files.AsParallel()
//     .Select(ReadResume)
//     .Where(r => r is not null)
//     .Cast<Resume>()
//     .ToList();
//
// if (resumes.Count == 0)
// {
//     Console.WriteLine("Не удалось прочитать ни одного корректного резюме.");
//     return;
// }
//
// var reports = new[]
// {
//     Task.Run(() => $"Самый опытный: {resumes.AsParallel().OrderByDescending(r => r.Experience).First()}"),
//     Task.Run(() => $"Наименее опытный: {resumes.AsParallel().OrderBy(r => r.Experience).First()}"),
//     Task.Run(() => "Кандидаты из одинаковых городов:\n" +
//         string.Join("\n", resumes.AsParallel().GroupBy(r => r.City)
//             .Where(g => g.Count() > 1)
//             .Select(g => $"{g.Key}: {string.Join(", ", g.Select(x => x.FullName))}"))),
//     Task.Run(() => $"Минимальные зарплатные ожидания: {string.Join("; ", resumes.AsParallel().Where(r => r.Salary == resumes.Min(x => x.Salary)))}"),
//     Task.Run(() => $"Максимальные зарплатные ожидания: {string.Join("; ", resumes.AsParallel().Where(r => r.Salary == resumes.Max(x => x.Salary)))}")
// };
//
// Task.WaitAll(reports);
// Console.WriteLine($"\nОбработано резюме: {resumes.Count}\n");
// foreach (var report in reports)
//     Console.WriteLine(report.Result + "\n");
//
// static Resume? ReadResume(string path)
// {
//     try
//     {
//         string[] parts = File.ReadAllText(path).Trim().Split(';');
//         if (parts.Length != 4) throw new FormatException("Ожидалось 4 поля.");
//         return new Resume(parts[0].Trim(), parts[1].Trim(),
//             int.Parse(parts[2], CultureInfo.InvariantCulture),
//             decimal.Parse(parts[3], CultureInfo.InvariantCulture));
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Пропущен файл {Path.GetFileName(path)}: {ex.Message}");
//         return null;
//     }
// }
//
// record Resume(string FullName, string City, int Experience, decimal Salary)
// {
//     public override string ToString() => $"{FullName} — {City}, стаж: {Experience} лет, зарплата: {Salary:N0}";
// }
