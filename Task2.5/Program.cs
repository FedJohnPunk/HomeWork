using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите максимальное целое число диапазона:");
            int maxValue = int.Parse(Console.ReadLine());
            Random randomize = new Random();
            int randomValue = randomize.Next(0, maxValue);
            Console.WriteLine("Вводите числа:");
            while (true)
            {
                int value = int.Parse(Console.ReadLine());
                if (value > randomValue)
                {
                    Console.WriteLine("Меньше");
                }
                else if (value < randomValue)
                {
                    Console.WriteLine("Больше");
                }
                else if (value == randomValue)
                {
                    Console.WriteLine($"Вы угадали! Загаданое число {randomValue}");
                    break;
                }
            }
            Console.WriteLine("Нажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}
