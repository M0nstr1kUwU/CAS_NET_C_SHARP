// using System.Globalization;
//
// Console.WriteLine("Задание 2. Самая длинная строго возрастающая непрерывная последовательность");
// string path = args.Length > 0 ? args[0] : Path.Combine(AppContext.BaseDirectory, "numbers.txt");
// if (!File.Exists(path))
// {
//     Console.WriteLine($"Файл не найден: {path}");
//     return;
// }
//
// int[] numbers = File.ReadAllText(path)
//     .Split(new[] { ' ', '\t', '\r', '\n', ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
//     .Select(x => int.Parse(x, CultureInfo.InvariantCulture))
//     .ToArray();
//
// if (numbers.Length == 0)
// {
//     Console.WriteLine("Файл не содержит чисел.");
//     return;
// }
//
// int bestStart = 0, bestLength = 1, currentStart = 0, currentLength = 1;
// for (int i = 1; i < numbers.Length; i++)
// {
//     if (numbers[i] > numbers[i - 1])
//         currentLength++;
//     else
//     {
//         currentStart = i;
//         currentLength = 1;
//     }
//
//     if (currentLength > bestLength)
//     {
//         bestLength = currentLength;
//         bestStart = currentStart;
//     }
// }
//
// Console.WriteLine($"Максимальная длина: {bestLength}");
// Console.WriteLine("Последовательность: " + string.Join(" ", numbers.Skip(bestStart).Take(bestLength)));
