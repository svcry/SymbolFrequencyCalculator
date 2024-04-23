using System;
using System.IO;
using System.Text;

namespace FileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Генерация файла из одинаковых символов
            GenerateFile("D:\\same_characters.txt", 'a', 1000);

            // Генерация файла из случайных символов 0 и 1
            GenerateRandomFile("D:\\random_binary.txt", 0, 2, 1000);

            // Генерация файла из случайных символов от 0 до 255
            GenerateRandomFile("D:\\random_byte.txt",0, 256, 1000);

            Console.WriteLine("Files generated successfully.");
        }

        static void GenerateFile(string fileName, char character, int length)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < length; i++)
                {
                    writer.Write(character);
                }
            }
        }

        static void GenerateRandomFile(string fileName, int start, int end, int length)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < length; i++)
                {
                    int bit = random.Next(start, end);
                    writer.Write(bit);
                }
            }
        }

    }
}