namespace Lesson6;
internal class Progsram
{
    string path = @"C:\UserData\Сотрудники.txt";
    string[] infoNames = { "ID", "Дата записи", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };

    static void Main(string path, string[] infoNames)
    {

        WriteOrRead(path, infoNames);
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

    static char ChooseOperation()
    {
        Console.WriteLine("Для чтения нажмите [1], для записи нажмите [2]:");
        char key = Console.ReadKey(true).KeyChar;
        return key;
    }

    static void WriteOrRead(string path, string[] info)
    {
        bool check;
        do
        {
            char key = ChooseOperation();
            if (char.ToLower(key) == '1')
            {
                FileReader(path, info);
                break;
            }
            else if (char.ToLower(key) == '2')
            {
                FileWriter(path, info);
                break;
            }
            else
            {
                Console.WriteLine("Некоректный ввод.");
                check = false;
            }
        } while (check == false);
    }

    static void RepeatOperationOrNot(string path, string[] info)
    {
        Console.WriteLine("Для новой операции нажмите [1], для завершения работы програмы нажмите любую клавишу:");
        char key = Console.ReadKey(true).KeyChar;
        if (char.ToLower(key) == '1')
        {
            WriteOrRead(path, info);
        }
    }

    static void FileWriter(string path, string[] info)
    {
        bool existCheck = File.Exists(path);
        using StreamWriter sw = new StreamWriter(path, existCheck);
        {
            char separator = '#';
            string userData = string.Empty;
            Console.WriteLine("Введите ID:");
            userData += $"{Console.ReadLine()}";
            userData += $"{separator}{DateTime.Now}";
            for (int i = 2; i < info.Length; i++)
            {
                Console.WriteLine($"Введите значение параметра {info[i]}:");
                string par = InputString();
                userData += $"{separator}{par}";
            }
            sw.WriteLine(userData);
            sw.Close();
        }
        RepeatOperationOrNot(path, info);
    }

    static void FileReader(string path, string[] info)
    {
        using StreamReader sr = new StreamReader(path);
        {
            string[] data = File.ReadAllLines(path);
            Console.WriteLine();

            foreach (var line in data)
            {
                char separator = '#';
                string[] splitedData = line.Split(separator);
                string userData = string.Empty;

                for (int i = 0; i < splitedData.Length; i++)
                {
                    userData += $"{info[i]}: {splitedData[i]}, ";
                }
                Console.WriteLine(userData);
            }
            sr.Close();
        }
        RepeatOperationOrNot(path, info);
    }
}