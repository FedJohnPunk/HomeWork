namespace Lesson8._1;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = GenerateList();
        PrintList(list);
        DeleteFromList(list);
        Console.WriteLine("\n");
        PrintList(list);
    }

    static List<int> GenerateList()
    {
        List<int> list = new List<int>();

        Random random = new Random();

        for (int i = 0; i < 100; i++)
        {
            list.Add(random.Next(100));
        }
        return list;
    }

    static void DeleteFromList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            // TODO сделай вместо этого отдельный метод проверки того, что
            // элемент списка подлежит удалению: bool NeedDelete(int item)
            // только без if а используя логический оператор &&
            if (25 < list[i])
            {
                if (list[i] < 50)
                {
                    list.RemoveAt(i);
                    // TODO не хорошо модифицировать счетчик цикла, это не очень прозрачное действие
                    // нужно переводить в голове. Код должен просто читаться
                    // Вместо этого начни цикл с конца списка.
                    i--;
                }
            }
        }
    }

    static void PrintList(List<int> list)
    {
        foreach (var item in list)
        {
            Console.Write($"{item} ");
        }
    }
} 
