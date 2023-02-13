namespace Lesson8._2;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> phoneBook = InputData();
        FindAndPrintFromList(phoneBook);
    }

    static Dictionary<string, string> InputData()
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        while (true)
        {
            Console.WriteLine("Введите ФИО:");
            string fio = Console.ReadLine();
            if (string.IsNullOrEmpty(fio))
            {
                break;
            }

            Console.WriteLine("Введите номер телефона:");
            string phoneNumber = InputString();

            phoneBook.Add(phoneNumber, fio);
        }
        return phoneBook;
    }

    static void FindAndPrintFromList(Dictionary<string, string> phoneBook)
    {
        Console.WriteLine("Введите номер телефона для поиска:");
        if (phoneBook.TryGetValue(InputString(), out string fio))
        {
            Console.WriteLine($"{fio}");
        }
        else
        {
            Console.WriteLine("Номер не найден.");
        }
    }

    static string InputString()
    {
        while (true)
        {
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Введите корректное значение:");
            }
            else
            {
                return s;
            }
        }
    }
}