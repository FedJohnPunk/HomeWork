namespace Lesson6;
internal class Progsram
{
    // TODO константы должны быть здесь: название файла и список полей

    static void Main(string[] args)
    {
        string fileLocation = @"C:\UserData\Сотрудники.txt";
        string[] infoNames = {"ID", "Дата записи", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };

        WriteOrRead(fileLocation, infoNames);
    }

    static string InputAndCheck()
    {
        //
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
    static void WriteOrRead(string fileLocation, string[] info)
    {
        bool check;
        do
        {
            // TODO метод определения действия должен быть отдельно
            Console.WriteLine("Для чтения нажмите [1], для записи нажмите [2]:");
            char key = Console.ReadKey(true).KeyChar;
            if (char.ToLower(key) == '1')
            {
                FileReader(fileLocation, info);
                break;
            }
            else if (char.ToLower(key) == '2')
            {
                FileWriter(fileLocation, info);
                break;
            }
            else
            {
                Console.WriteLine("Некоректный ввод.");
                check = false;
            }
        } while (check == false);
        
    }

    static void FileWriter(string fileLocation, string[] info)
    {
        bool existCheck = File.Exists(fileLocation);
        using StreamWriter sw = new StreamWriter(fileLocation, existCheck);
        {
            char separator = '#';
            string userData = string.Empty;
            Console.WriteLine("Введите ID:");
            userData += $"{Console.ReadLine()}";
            userData += $"{separator}{DateTime.Now}";
            for (int i = 2; i < info.Length; i++)
            {
                Console.WriteLine($"Введите значение параметра {info[i]}:");
                string par = InputAndCheck();
                userData += $"{separator}{par}";
            }
            sw.WriteLine(userData);
            sw.Close();
            // TODO похожий код в FileRead должен вызывать желание сделать общий метод))
            Console.WriteLine("Для новой операции нажмите [1], для завершения работы програмы нажмите любую клавишу:");
            char key = Console.ReadKey(true).KeyChar;
            if (char.ToLower(key) == '1')
            {
                // TODO метод, который вызвает данный метод, не должен
                // вызываться внутри вызываемого метода
                // Определение того, что делать дальше должно быть вне метода, который что-то делает с файлом
                WriteOrRead(fileLocation, info);
            }
        }
        
    }

    static void FileReader(string fileLocation, string[] info)
    {
        using StreamReader sr = new StreamReader(fileLocation);
        {
            string[] data = File.ReadAllLines(fileLocation);
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
            Console.WriteLine("Для новой операции нажмите [1], для завершения работы програмы нажмите любую клавишу:");
            char key = Console.ReadKey(true).KeyChar;
            if (char.ToLower(key) == '1')
            {
                WriteOrRead(fileLocation, info);
            }
        }
    }
}