// using FileSystemLibrary;
//
// string root = Path.Combine(Path.GetTempPath(), "FileSystemDllDemo");
// if (Directory.Exists(root)) Directory.Delete(root, true);
// Directory.CreateDirectory(root);
// File.WriteAllText(Path.Combine(root, "one.txt"), "Первый файл");
// File.WriteAllText(Path.Combine(root, "two.log"), "Второй файл");
//
// FileManager.CopyFile(Path.Combine(root, "one.txt"), Path.Combine(root, "copy.txt"));
// FileManager.CopyDirectory(root, Path.Combine(root, "backup"), recursive: false);
// Console.WriteLine("Скопирован файл и каталог.");
// Console.WriteLine($"Удалено по маске *.log: {FileManager.DeleteFilesByMask(root, "*.log")}");
// FileManager.MoveFile(Path.Combine(root, "copy.txt"), Path.Combine(root, "moved.txt"));
// Console.WriteLine($"Удалён one.txt: {FileManager.DeleteFile(root, "one.txt")}");
// Console.WriteLine($"Тестовые файлы находятся в: {root}");
