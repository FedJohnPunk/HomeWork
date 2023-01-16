namespace Lesson4._1;

internal class Program
{
    static void Main(string[] args)
    {
        (int matSizeA, int matSizeB) = InputSize();
        int[,] mat = GenerateMatrix(matSizeA, matSizeB);
        int sum = SumMatrixVal(mat);
        Print(mat);
        Console.WriteLine($"\nСумма всех элементов матрицы: {sum}");
        Console.ReadKey();
    }

    // TODO лучше InputInt, проверка скрыта внутри и не очевидна для вызывающего кода
    // нужно упомянуть Int, а то у тебя потом и string так-же назван
    static int InputAndCheck()
    {
        // TODO не экономь буквы val - value
        // TODO нужно смотреть всегда, как код упростить.
        // Как правило, не нужно объявлять отдельно переменные не присваивая значения.
        // Попробуй сделать без check и без отдельного объявления val.
        // Подсказки: конструкция "while (true) {}" называется "бесконечный цикл";
        // out-переменная может быть объявлена в вызове метода, но она имеет ограниченную
        // область видимости if (int.TryParse(..., out int val)) { val ... }
        int val;
        bool check;
        do
        {
            check = int.TryParse(Console.ReadLine(), out val);
            // TODO нет необходимости bool сравнивать со значением
            // это и так bool. Здесь check можно использовать
            if (check == true)
            {
                break;
            }
            else
            {
                Console.WriteLine("Введите корректное значение");
                // TODO здесь же check и так false )
                check = false;
            }
        } while (check == false); // TODO а здесь "!check"
        return val;
    }

    static (int,int) InputSize()
    {
        Console.WriteLine("Введите количество строк в матрице:");
        int matSizeA = InputAndCheck();
        Console.WriteLine("Введите количество столбцов в матрице:");
        int matSizeB = InputAndCheck();
        Console.WriteLine();
        return (matSizeA, matSizeB);
    }

    static int[,] GenerateMatrix(int matSizeA, int matSizeB)
    {
        int[,] matrix = new int[matSizeA, matSizeB];
        Random r = new Random();

        // TODO ты ввел понятия размер A и размер B
        // после этого, хорошо бы ввести константы для
        // нумерации этого размера int const IndexSizeA = 0... IndexSizeB = 1
        // и использовать их matrix.GetLength(IndexSizeA)
        // сейчас числа 0 и 1 - это тоже "магические строки", тк не понятно
        // что они означают в целом в коде (для того, кто видит код первый раз)
        // и есть риск ошибиться, где 0 а где 1 нужно
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = r.Next(10);
            }
        }
        return matrix;
    }

    // TODO не экономь буквы Val - Values
    static int SumMatrixVal(int[,] matrix)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
        }
        return sum;
    }

    // TODO PrintMatrix - важно правильно называть, не экономь буквы
    static void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}