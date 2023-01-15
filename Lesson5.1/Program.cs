namespace Lesson5._1;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Введите предложение:");
        string inputText = InputAndCheck();
        string[] splitedText = SplitText(inputText);
        Print(splitedText);
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
}