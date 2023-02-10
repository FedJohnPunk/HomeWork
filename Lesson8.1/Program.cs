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
        List<int> list = new();

        Random random = new();

        for (int i = 0; i < 100; i++)
        {
            list.Add(random.Next(100));
        }
        return list;
    }

    static void DeleteFromList(List<int> list)
    {
        for (int i = list.Count; i > 0; i--)
        {
            if (NeedToDelete(list[i]))
            {
                list.RemoveAt(i);
            }
        }
    }

    static bool NeedToDelete(int value)
    {
        if (25 < value && value < 50)
            return true;
        else
            return false;
    }

    static void PrintList(List<int> list)
    {
        foreach (var item in list)
        {
            Console.Write($"{item} ");
        }
    }
} 
