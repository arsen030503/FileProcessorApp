using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Определяем путь к файлу с текстом
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "test.txt");

        // Проверяем, существует ли файл
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден: " + filePath);
            return;
        }

        // Читаем оригинальный текст
        string content = File.ReadAllText(filePath);
        Console.WriteLine("Оригинальный текст:");
        Console.WriteLine(content);

        // Создаем папку Data, если её нет
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Шифруем текст
        string encryptedText = CryptoUtils.Encrypt(content);
        string encryptedFilePath = Path.Combine(outputDir, "encrypted.txt");
        File.WriteAllText(encryptedFilePath, encryptedText);
        Console.WriteLine("\nЗашифрованный текст:");
        Console.WriteLine(encryptedText);

        // Дешифруем текст
        string decryptedText = CryptoUtils.Decrypt(encryptedText);
        string decryptedFilePath = Path.Combine(outputDir, "decrypted.txt");
        File.WriteAllText(decryptedFilePath, decryptedText);
        Console.WriteLine("\nРасшифрованный текст:");
        Console.WriteLine(decryptedText);
    }
}
