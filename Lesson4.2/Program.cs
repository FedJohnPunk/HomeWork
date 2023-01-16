namespace Lesson4._2;

internal class Program
{
    // TODO аналогично замечаниям для 4.1
    static void Main()
    {
        (int matSizeA, int matSizeB) = InputSize();

        Console.WriteLine("Матрица A:");
        int[,] matrixA = GenMatrix(matSizeA, matSizeB);
        Print(matrixA);

        Console.WriteLine("Матрица B:");
        int[,] matrixB = GenMatrix(matSizeA, matSizeB);
        Print(matrixB);

        Console.WriteLine("Матрица C:");
        int[,] matrixC = SumMartix(matrixA, matrixB);
        Print(matrixC);
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

    static (int, int) InputSize()
    {
        Console.WriteLine("Введите количество строк в матрице:");
        int matSizeA = InputAndCheck();
        Console.WriteLine("Введите количество столбцов в матрице:");
        int matSizeB = InputAndCheck();
        Console.WriteLine();
        return (matSizeA, matSizeB);
    }

    static int[,] GenMatrix(int matSizeA, int matSizeB)
    {
        int[,] matrix = new int[matSizeA, matSizeB];
        Random random = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(10);
            }
        }
        return matrix;
    }

    static int[,] SumMartix(int[,] matrixA, int[,] matrixB)
    {
        int[,] matrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }
        return matrix;
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
        Console.WriteLine();
    }
}