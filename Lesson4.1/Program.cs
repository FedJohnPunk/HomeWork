namespace Lesson4._1;

internal class Program
{
    static void Main(string[] args)
    {
        int[,] mat = GenerateMatrix(SetSize());
        int sum = SumMatrix(mat);
        Print(mat, sum);
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
    static int[,] GenerateMatrix(int[] matSize)
    {
        int[,] matrix = new int[matSize[0], matSize[1]];
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
    static int SumMatrix(int[,] matrix)
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
    static void Print(int[,] matrix, int sum)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Сумма всех элементов матрицы: {sum}");
        Console.ReadKey();
    }
}