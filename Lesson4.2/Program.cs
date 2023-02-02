namespace Lesson4._2;

internal class Program
{
    static void Main()
    {
        (int matSizeA, int matSizeB) = InputSize();

        Console.WriteLine("Матрица A:");
        int[,] matrixA = GenerateMatrix(matSizeA, matSizeB);
        PrintMatrix(matrixA);

        Console.WriteLine("Матрица B:");
        int[,] matrixB = GenerateMatrix(matSizeA, matSizeB);
        PrintMatrix(matrixB);

        Console.WriteLine("Матрица C:");
        int[,] matrixC = SumMartix(matrixA, matrixB);
        PrintMatrix(matrixC);
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

    static (int, int) InputSize()
    {
        Console.WriteLine("Введите количество строк в матрице:");
        int matSizeA = InputInt();
        Console.WriteLine("Введите количество столбцов в матрице:");
        int matSizeB = InputInt();
        Console.WriteLine();
        return (matSizeA, matSizeB);
    }

    static int[,] GenerateMatrix(int matSizeA, int matSizeB)
    {
        int[,] matrix = new int[matSizeA, matSizeB];
        Random random = new Random();
        int indexSizeA = 0;
        int indexSizeB = 1;

        for (int i = 0; i < matrix.GetLength(indexSizeA); i++)
        {
            for (int j = 0; j < matrix.GetLength(indexSizeB); j++)
            {
                matrix[i, j] = random.Next(10);
            }
        }
        return matrix;
    }

    static int[,] SumMartix(int[,] matrixA, int[,] matrixB)
    {
        int indexSizeA = 0;
        int indexSizeB = 1;
        int[,] matrix = new int[matrixA.GetLength(indexSizeA), matrixB.GetLength(indexSizeB)];
        for (int i = 0; i < matrix.GetLength(indexSizeA); i++)
        {
            for (int j = 0; j < matrix.GetLength(indexSizeB); j++)
            {
                matrix[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int indexSizeA = 0;
        int indexSizeB = 1;
        for (int i = 0; i < matrix.GetLength(indexSizeA); i++)
        {
            for (int j = 0; j < matrix.GetLength(indexSizeB); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}