// using System.Globalization;
//
// Console.WriteLine("Задание 3. Самая длинная непрерывная последовательность положительных чисел");
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
// int bestStart = 0, bestLength = 0, currentStart = 0, currentLength = 0;
// for (int i = 0; i < numbers.Length; i++)
// {
//     if (numbers[i] > 0)
//     {
//         if (currentLength == 0) currentStart = i;
//         currentLength++;
//         if (currentLength > bestLength)
//         {
//             bestLength = currentLength;
//             bestStart = currentStart;
//         }
//     }
//     else currentLength = 0;
// }
//
// Console.WriteLine($"Максимальная длина: {bestLength}");
// Console.WriteLine(bestLength == 0
//     ? "Положительных последовательностей нет."
//     : "Последовательность: " + string.Join(" ", numbers.Skip(bestStart).Take(bestLength)));
