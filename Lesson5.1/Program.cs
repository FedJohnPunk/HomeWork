namespace Lesson5._1;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Введите предложение:");
        string inputText = InputString();
        string[] splitedText = SplitText(inputText);
        PrintSplitedString(splitedText);
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
    static string[] SplitText(string text)
    {
        string[] strings = text.Split();
        return strings;
    }

    static void PrintSplitedString(string[] strings)
    {
        Console.WriteLine();
        foreach (string i in strings)
        {
            Console.WriteLine(i);
        }
    }
}