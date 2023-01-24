namespace Lesson5._2;
internal class Program
{
    static void Main()
    {
        Console.WriteLine("Введите предложение:");
        string inputText = InputString();
        string revText = Reverse(inputText);
        Console.WriteLine(revText);
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
        string[] splitedText = text.Split();
        return splitedText;
    }

    static string Reverse(string text)
    {
        string[] strings = SplitText(text);
        Array.Reverse(strings);
        string result = string.Join(" ", strings);
        return result;
    }
}