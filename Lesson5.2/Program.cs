namespace Lesson5._2;
internal class Program
{
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

    static string[] Reverse(string text)
    {
        string[] strings= SplitText(text);
        Array.Reverse(strings);
        // TODO Здесь обрати внимание на то, что string подчеркивается
        // нужно разобраться и подправить
        string.Join(" ", strings);
        return strings;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите предложение:");
        string inputText = Console.ReadLine();
        string[] revText = Reverse(inputText);
        foreach (string rev in revText)
        {
            Console.Write($"{rev} ");
        }
    }
}