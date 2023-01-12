namespace Lesson4._2;

internal class Program
{
    static void Main(string[] args)
    {
        int[] matSize = SetSize();
        Console.WriteLine("Матрица A:");
        int[,] matrixA = GenMatrix(matSize);
        Print(matrixA);
        Console.WriteLine("Матрица B:");
        int[,] matrixB = GenMatrix(matSize);
        Print(matrixB);
        Console.WriteLine("Матрица C:");
        int[,] matrixC = SumMartix(matSize, matrixA, matrixB);
        Print(matrixC);
    }
    static int[] SetSize()
    {
        int[] matSize = new int[2];
        Console.WriteLine("Введите количество строк в матрице:");
        matSize[0] = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов в матрице:");
        matSize[1] = int.Parse(Console.ReadLine());
        return matSize;
    }
    static int[,] GenMatrix(int[] matSize)
    {
        int[,] matrix = new int[matSize[0], matSize[1]];
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
    static int[,] SumMartix(int[] matSize, int[,] matrixA, int[,] matrixB)
    {
        int[,] matrix = new int[matSize[0], matSize[1]];
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