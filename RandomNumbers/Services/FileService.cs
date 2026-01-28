using System;
using System.Collections.Generic;
using System.Text;

namespace RandomNumbers.Services
{
    public static class FileService
    {
        public static string GetClassFilePath(string className)
        {
            return Path.Combine(FileSystem.AppDataDirectory, $"{className}.txt");
        }

        public static List<string> LoadStudents(string className)
        {
            var path = GetClassFilePath(className);

            if (!File.Exists(path))
                return new List<string>();

            return File.ReadAllLines(path).ToList();
        }

        public static void SaveStudents(string className, List<string> students)
        {
            var path = GetClassFilePath(className);
            File.WriteAllLines(path, students, Encoding.UTF8);
        }
    }
}
