using System;
using System.IO;

namespace FileProcessorApp
{
    public static class FileHandler
    {
        public static void SaveToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"Файл сохранён: {filePath}");
        }

        public static string ReadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine($"Чтение файла: {filePath}");
                return File.ReadAllText(filePath);
            }
            Console.WriteLine("Файл не найден!");
            return string.Empty;
        }
    }
}