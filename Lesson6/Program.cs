namespace Lesson6;
internal class Progsram
{
    static void Main(string[] args)
    {
        bool existCheck = File.Exists(@"C:\UserData\Сотрудники.txt");
        string[] infoNames = { "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };

        WriteOrRead(existCheck, infoNames);
    }
    static void WriteOrRead(bool existCheck, string[] info)
    {
        Console.WriteLine("Для чтения нажмите 1, для записи нажмите 2:");
        char key = Console.ReadKey(true).KeyChar;
        if (char.ToLower(key) == '1')
        {
            FileReader(info);
        }
        else if (char.ToLower(key) == '2')
        {
            FileWriter(existCheck, info);
        }
        else
        {
            Console.WriteLine("Некоректный ввод.");
        }
    }

    static void FileWriter(bool fileExCheck, string[] info)
    {
        using (StreamWriter sw = new StreamWriter(@"C:\UserData\Сотрудники.txt5", fileExCheck))
        {
            char key = '1';

            do
            {
                string userData = string.Empty;
                Console.WriteLine("Введите ID:");
                userData += $"{Console.ReadLine()}";

                string now = DateTime.Now.ToString();
                userData += $"#{now}";

                for (int i = 0; i < info.Length; i++)
                {
                    Console.WriteLine($"Введите значение параметра {info[i]}:");
                    string par  = Console.ReadLine();
                    userData += $"#{par}";
                }

                sw.WriteLine(userData);
                Console.WriteLine("Для новой записи нажмите один '1', для завершения нажмите любую клавишу:");
                key = Console.ReadKey(true).KeyChar;
            } while (char.ToLower(key) == '1');
        }
    }

    static void FileReader(string[] info)
    {
        using (StreamReader sr = new StreamReader(@"C:\UserData\Сотрудники.txt"))
        {
            string[] data = File.ReadAllLines(@"C:\UserData\Сотрудники.txt");
            Console.WriteLine();

            foreach (var line in data)
            {
                string[] splitedData = line.Split('#');
                string userData = string.Empty;

                userData += $"ID: {splitedData[0]}, ";
                userData += $"Дата записи: {splitedData[1]}, ";
                int j = 0;
                for (int i = 2; i < splitedData.Length; i++)
                {
                    userData += $"{info[j]}: {splitedData[i]}, ";
                    j++;
                }
                Console.WriteLine(userData);

            }
            Console.ReadLine();
        }
    }
}