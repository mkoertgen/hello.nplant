using System.Reflection;

namespace Hello.NPlant;

internal static class Find
{
    public static FindContext File(string fileName)
    {
        return new FindContext(fileName);
    }

    public static string GetPath(this Assembly assembly)
    {
        var codeBase = assembly.Location;
        var uri = new UriBuilder(codeBase);
        return Uri.UnescapeDataString(uri.Path);
    }

    public static string GetDirectory(this Assembly assembly)
    {
        var path = assembly.GetPath();
        return Path.GetDirectoryName(path)!;
    }

    public class FindContext
    {
        private readonly string _fileName;

        public FindContext(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));
            _fileName = fileName;
        }

        public string? InPath()
        {
            if (System.IO.File.Exists(_fileName))
                return Path.GetFullPath(_fileName);

            var values = Environment.GetEnvironmentVariable("PATH")!.Split(';');
            return values
                .Select(path => Path.Combine(path, _fileName))
                .FirstOrDefault(System.IO.File.Exists);
        }

        public string? Above(string directory)
        {
            var files = Directory.GetFiles(directory, _fileName);
            if (files.Any())
                return files.FirstOrDefault();

            var dir = new DirectoryInfo(directory);
            var parent = dir.Parent;
            // ReSharper disable once TailRecursiveCall
            return parent != null ? Above(parent.FullName) : null;
        }

        public string? BeneathEnv(string envVar)
        {
            var path = Environment.GetEnvironmentVariable(envVar);
            return string.IsNullOrEmpty(path) ? string.Empty : Beneath(path);
        }

        public string? Beneath(string path)
        {
            var files = Directory.GetFiles(path, _fileName, SearchOption.AllDirectories);
            return files.SingleOrDefault();
        }

        public string? InProgramFilesBeneath(string pattern)
        {
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            return FindIn(programFiles, pattern, _fileName)
                   ?? FindIn(programFilesX86, pattern, _fileName);
        }

        private static string? FindIn(string rootPath, string pathPattern, string fileName)
        {
            var dirs = Directory.GetDirectories(rootPath, pathPattern);
            foreach (var dir in dirs)
            {
                var files = Directory.GetFiles(dir, fileName, SearchOption.AllDirectories);
                if (files.Any())
                    return files.FirstOrDefault();
            }
            return null;
        }
    }
}