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
            if (25 < list[i])
            {
                if (list[i] < 50)
                {
                    list.RemoveAt(i);
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
