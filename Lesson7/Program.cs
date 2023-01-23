using System.IO;

namespace Lesson7;

internal partial class Program
{
    static void Main()
    {
        WorkerRepository rep = new WorkerRepository();
        Console.WriteLine(
            "Введите '1', чтобы добавить нового сотрудника, " +
            "\nВведите '2', чтобы вывести данные всех сотрудников," +
            "\nВведите '3', чтобы вывести данные конктретного сотрудника," +
            "\nВведите '4', чтобы удалить данные сотрудника," +
            "\nВведите '5', чтобы вывести данные сотрудников за заданый промежуток времени.");
        char key = Console.ReadKey(true).KeyChar;
        if (char.ToLower(key) == '1')
        {
            Worker worker = new Worker();
            Console.WriteLine("Введите Ф.И.О. сотрудника: ");
            worker.Fio = InputStringCheck();
            Console.WriteLine("Введите возраст сотрудника: ");
            worker.Age = int.Parse(InputStringCheck());
            Console.WriteLine("Введите рост сотрудника: ");
            worker.Height = int.Parse(InputStringCheck());
            Console.WriteLine("Введите дату рождения сотрудника в виде 'xx.xx.xx': ");
            worker.BirthDate = DateTime.Parse(InputStringCheck());
            Console.WriteLine("Введите место рождения сотрудника: ");
            worker.BirthPlace = InputStringCheck();

            rep.AddWorker(worker);
        }
        else if (char.ToLower(key) == '2')
        {
            rep.PrintAllWorkers();
        }
        else if (char.ToLower(key) == '3')
        {
            Console.WriteLine("Введите ID сотрудника для отображения данных: ");
            int id = int.Parse(InputStringCheck());
            rep.PrintWorkerById(id);
        }
        else if (char.ToLower(key) == '4')
        {
            Console.WriteLine("Введите ID сотрудника для удаления данных: ");
            int id = int.Parse(InputStringCheck());
            rep.DeleteWorker(id);
        }
        else if (char.ToLower(key) == '5')
        {
            Console.WriteLine("Введите дату 1 ");
            DateTime dateFrom = DateTime.Parse(InputStringCheck());
            Console.WriteLine("Введите дату 2 ");
            DateTime dateTo = DateTime.Parse(InputStringCheck());
            rep.PrintWorkersBetweenTwoDates(dateFrom, dateTo);
        }
        else
        {
            Console.WriteLine("Error");
        }
    }

    static string InputStringCheck()
    {
        string s = string.Empty;
        bool check;
        do
        {
            s = Console.ReadLine();

            check = string.IsNullOrEmpty(s);
            if (check == false)
            {
                break;
            }
            else
            {
                Console.WriteLine("не введено:");
                check = true;
            }
        } while (check == true);
        return s;
    }
}