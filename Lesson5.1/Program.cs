namespace Lesson5._1;

internal class Program
{

    /// <summary>
    /// Метод, который переводит строку в массив слов.
    /// <param name="Text"></param>
    /// <returns></returns>
    static string[] SplitText(string text)
    {
        string[] strings = text.Split();
        return strings;
    }

    /// <summary>
    /// Метод, который выводит каждое слово в отдельной строке.
    /// </summary>
    /// <returns></returns>
    static void Print(string[] strings)
    {
        Console.WriteLine();
        foreach (string i in strings)
        {
            Console.WriteLine(i);
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите предложение:");
        string inputText = Console.ReadLine();
        string[] splitedText = SplitText(inputText);
        Print(splitedText);
    }
}