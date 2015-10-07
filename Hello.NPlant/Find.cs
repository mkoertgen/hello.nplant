using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Hello.NPlant
{
    internal static class Find
    {
        public static FindContext File(string fileName)
        {
            return new FindContext(fileName);
        }

        public static string GetPath(this Assembly assembly)
        {
            var codeBase = assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            return Uri.UnescapeDataString(uri.Path);
        }

        public static string GetDirectory(this Assembly assembly)
        {
            var path = assembly.GetPath();
            return Path.GetDirectoryName(path);
        }

        public class FindContext
        {
            private readonly string _fileName;

            public FindContext(string fileName)
            {
                if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));
                _fileName = fileName;
            }

            public string InPath()
            {
                if (System.IO.File.Exists(_fileName))
                    return Path.GetFullPath(_fileName);

                var values = Environment.GetEnvironmentVariable("PATH");
                foreach (var path in values.Split(';'))
                {
                    var fullPath = Path.Combine(path, _fileName);
                    if (System.IO.File.Exists(fullPath))
                        return fullPath;
                }
                return null;
            }

            public string BeneathEnv(string envVar)
            {
                var path = Environment.GetEnvironmentVariable(envVar);
                if (string.IsNullOrEmpty(path)) return string.Empty;
                var files = Directory.GetFiles(path, _fileName, SearchOption.AllDirectories);
                return files.SingleOrDefault();
            }

            public string InProgramFilesBeneath(string pattern)
            {
                var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                var programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

                return FindIn(programFiles, pattern, _fileName)
                       ?? FindIn(programFilesX86, pattern, _fileName);
            }

            private static string FindIn(string rootPath, string pathPattern, string fileName)
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
}