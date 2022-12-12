// TODO нужно чистить using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO снова блочный неймспейс - нужно убрать кавычки
namespace Task2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Программа определения чётности или нечётности числа

            // Пользователь вводит число для проверки
            Console.WriteLine("Введите целое число: ");
            int value = int.Parse(Console.ReadLine());

            // Проверка числа с помощью деления с остатком
            int valueCheck = value % 2;

            if (valueCheck == 0)
            {
                Console.WriteLine("Данное число является чётным.");
                Console.WriteLine("Нажмите Enter для выхода.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Данное число является нечётным.");
                // TODO Здесь повторяет часть кода ветки с четностью - нужно замечать
                // и делать их общим кодом
                Console.WriteLine("Нажмите Enter для выхода.");
                Console.ReadLine();
            }

            // TODO Хорошо бы во всех заданиях в конце не просто выход, а предлагать
            // или выход или повторить
        }
    }
}
