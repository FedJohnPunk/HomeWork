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
            }
            else
            {
                Console.WriteLine("Данное число является нечётным.");
            }
            Console.WriteLine("Нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}
