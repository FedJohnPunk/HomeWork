namespace Lesson6;
internal class Progsram
{
    static void Main(string[] args)
    {
        // TODO Зачем ЗДЕСЬ проверять наличие файла, если
        // это значение будет где-то там когда-то использоваться и то не факт (FileRead)
        // TODO Есть несколько причин, чтобы сделать имя файла общей константой
        // - не ошибильтся (в FileWriter ошибся),
        // - чтобы знать назначение этой строки - это хорошо, что ты по русски понимаешь, что
        //   написано, а если на китайском будет? а имя констаны EmployeeFileName - гарантирует,
        //   что будет понятно везде назначение этой "магической строки" (почитай про магические строки)
        // - в системах нескольких языков содержимое строки каким-то способом подменяется на заданный язык
        //   а идентификатор остается неизменным
        bool existCheck = File.Exists(@"C:\UserData\Сотрудники.txt");
        string[] infoNames = { "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };

        WriteOrRead(existCheck, infoNames);
    }

    static void WriteOrRead(bool existCheck, string[] info)
    {
        // TODO Обычно нажатия обозначают [1] [2]
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
        using (StreamWriter sw = new StreamWriter(@"C:\UserData\Сотрудники.txt", fileExCheck))
        {
            char key = '1';

            do
            {
                // TODO У Игоря списывал? я ему кучу замечаний дал
                // а он тебе первый вариант - попроси тогда уж последний
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