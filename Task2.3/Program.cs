namespace Task2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Программа проверки простого числа

            Console.WriteLine("Введите число:");
            int value = int.Parse(Console.ReadLine());
            
            int counter = 2;
            bool check = false;
            while (counter <= value - 1)
            {
                if (value % counter == 0)
                {
                    check = true;
                }
                counter++;
            }    
            if (check == false)
            {
                Console.WriteLine("Число является простым.");
            }
            else
            {
                Console.WriteLine("Число не является простым");
            }
            Console.WriteLine("Нажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}
