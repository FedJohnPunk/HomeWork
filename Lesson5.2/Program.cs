namespace Lesson5._2;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите предложение:");
        string inputText = InputAndCheck();
        string revText = Reverse(inputText);
        Console.WriteLine(revText);
    }

    static string InputAndCheck()
    {
        string s = string.Empty;
        bool check;
        do
        {
            s = Console.ReadLine();

            check = string.IsNullOrEmpty(s);
            if (check == false)
            {
                break;
            }
            else
            {
                Console.WriteLine("Введите корректное предложение:");
                check = true;
            }
        } while (check == true);
        return s;
    }

    /// <summary>
    /// Метод, который разделяет стрку на отдельные слова.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
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