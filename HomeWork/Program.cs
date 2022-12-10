using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ф.И.О.
            string fullName = "Иван Дмитриевич";
            // Электронная почта
            string email = "ivan.fedyun@gmail.com";
            // Возраст
            byte age = 17;
            // Баллы по физике
            int physicsPoints = 85;
            // Баллы по математике
            int mathPoints = 76;
            // Баллы по програмированию
            int progPoints = 97;

            #region 
            // Неудобный вариант
            // string output = $"Ф.И.О.: {fullName} \nВозраст: {age} \nEmail: {email} \nБаллы по физике: {physics} \nБаллы по математике: {math} \nБаллы по програмированию: {programming}";
            // Console.WriteLine(output);
            // Console.ReadKey();
            #endregion

            Console.WriteLine($"Ф.И.О.: {fullName}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Баллы по физике: {physicsPoints}");
            Console.WriteLine($"Баллы по математике: {mathPoints}");
            Console.WriteLine($"Баллы по програмированию: {progPoints}");
            Console.ReadKey();

            // Сумма баллов по всем предметам
            int sum = physicsPoints + mathPoints + progPoints;
            Console.WriteLine($"Сумма баллов: {sum}");

            //Средний балл
            double average = (physicsPoints + mathPoints + progPoints) / 3;
            Console.WriteLine($"Средний балл: {average}");
            Console.ReadLine();
        }
    }
}
