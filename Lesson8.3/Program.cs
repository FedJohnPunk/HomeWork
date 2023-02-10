namespace Lesson8._3;

class Program
{
    static void Main(string[] args)
    {
        HashSet<int> _set = new HashSet<int>() {1, 3, 4, 6, 8};
        AddToCollection(_set);
    }

    public static void AddToCollection(HashSet<int> set)
    {
        Console.WriteLine("Введите число для добавления:");
        while (true)
        {
            int value = InputInt();
            if (set.Contains(value))
            {
                Console.WriteLine("Такой элемент уже есть в коллекции. Введите другой:");
            }
            else
            {
                set.Add(value);
                break;
            }
        }
    }

    static int InputInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Некоректный ввод, попробуйте ещё раз:");
            }
        }
    }
}