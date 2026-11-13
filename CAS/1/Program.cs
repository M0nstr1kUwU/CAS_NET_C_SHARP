using System.Globalization;

Console.WriteLine("Задание 1. Подсчёт уникальных чисел с помощью PLINQ");
string path = args.Length > 0 ? args[0] : Path.Combine(AppContext.BaseDirectory, "numbers.txt");

if (!File.Exists(path))
{
    Console.WriteLine($"Файл не найден: {path}");
    Console.WriteLine("Создайте numbers.txt или передайте путь к файлу аргументом.");
    return;
}

int[] numbers = File.ReadAllText(path)
    .Split(new[] { ' ', '\t', '\r', '\n', ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x, CultureInfo.InvariantCulture))
    .ToArray();

int uniqueCount = numbers.AsParallel().Distinct().Count();
Console.WriteLine($"Всего чисел: {numbers.Length}");
Console.WriteLine($"Уникальных чисел: {uniqueCount}");
Console.WriteLine("Уникальные значения: " + string.Join(", ", numbers.AsParallel().Distinct().OrderBy(x => x)));
