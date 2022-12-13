using System;

namespace Task2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Программа для определения минимального элемента в последовательности

            // Пользователь задаёт длинну последовательности
            Console.WriteLine("Введите количество числел в последовательности:");
            int lenght = int.Parse(Console.ReadLine());
            // Задаём переменную для миниммального элемента, с которым мы будем сравнивать вводимие значения
            int minValue = int.MaxValue;
            int counter = 0;
            // С помощью цикла сравниваем введённые числа с minValue
            // Если число меньше, обновляем значение переменной
            while (lenght > counter)
            {
                Console.WriteLine($"Введите {counter + 1} число:");
                int value = int.Parse(Console.ReadLine());
                minValue = (value < minValue) ? value : minValue;
                counter++;
            }
            Console.WriteLine($"Минимальное число: {minValue}");
            Console.WriteLine("\nНажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}
