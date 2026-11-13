namespace FileSystemLibrary;

public static class FileManager
{
    public static void CopyFile(string source, string destination, bool overwrite = true)
    {
        EnsureFileExists(source);
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(destination))!);
        File.Copy(source, destination, overwrite);
    }

    public static void CopyDirectory(string sourceDirectory, string destinationDirectory, bool recursive = true)
    {
        if (!Directory.Exists(sourceDirectory))
            throw new DirectoryNotFoundException(sourceDirectory);

        var source = new DirectoryInfo(sourceDirectory);
        Directory.CreateDirectory(destinationDirectory);

        foreach (FileInfo file in source.GetFiles())
            file.CopyTo(Path.Combine(destinationDirectory, file.Name), true);

        if (recursive)
        {
            foreach (DirectoryInfo directory in source.GetDirectories())
                CopyDirectory(directory.FullName, Path.Combine(destinationDirectory, directory.Name), true);
        }
    }

    public static bool DeleteFile(string directory, string fileName)
    {
        string path = Path.Combine(directory, fileName);
        if (!File.Exists(path)) return false;
        File.Delete(path);
        return true;
    }

    public static int DeleteFiles(string directory, IEnumerable<string> fileNames)
    {
        int deleted = 0;
        foreach (string name in fileNames)
            if (DeleteFile(directory, name)) deleted++;
        return deleted;
    }

    public static int DeleteFilesByMask(string directory, string searchPattern)
    {
        if (!Directory.Exists(directory)) throw new DirectoryNotFoundException(directory);
        string[] files = Directory.GetFiles(directory, searchPattern, SearchOption.TopDirectoryOnly);
        foreach (string file in files) File.Delete(file);
        return files.Length;
    }

    public static void MoveFile(string source, string destination, bool overwrite = false)
    {
        EnsureFileExists(source);
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(destination))!);
        File.Move(source, destination, overwrite);
    }

    private static void EnsureFileExists(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException("Исходный файл не найден.", path);
    }
}
