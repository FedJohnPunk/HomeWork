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

    static int InputAndCheck()
    {
        int val;
        bool check;
        do
        {
            check = int.TryParse(Console.ReadLine(), out val);
            if (check == true)
            {
                break;
            }
            else
            {
                Console.WriteLine("Введите корректное значение");
                check = false;
            }
        } while (check == false);
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

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = r.Next(10);
            }
        }
        return matrix;
    }

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