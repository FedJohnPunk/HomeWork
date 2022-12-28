namespace Lesson6;
internal class Progsram
{
    static void Main(string[] args)
    {
        bool existCheck = File.Exists(@"C:\UserData\Сотрудники.txt");
        string[] infoNames = { "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };
        //FileWriter(existCheck, infoNames);
        FileReader(infoNames);
    }
    static void FileWriter(bool fileExCheck, string[] info)
    {
        using (StreamWriter sw = new StreamWriter(@"C:\UserData\Сотрудники.txt", fileExCheck))
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
                Console.Write("Для продолжения введите '1', для завершения нажмите любую клавишу:");
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

                for (int i = 0; i < splitedData.Length; i++)
                {
                    string userData = string.Empty;
                    userData += $"{info[i]}: {splitedData[i]}";
                    Console.WriteLine(userData);
                    Console.ReadKey();
                }
            }
        }
    }
}