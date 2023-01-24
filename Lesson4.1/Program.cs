namespace Lesson4._1;

internal class Program
{
    static void Main(string[] args)
    {
        (int matSizeA, int matSizeB) = InputSize();
        int[,] mat = GenerateMatrix(matSizeA, matSizeB);
        int sum = SumMatrixVal(mat);
        PrintMatrix(mat);
        Console.WriteLine($"\nСумма всех элементов матрицы: {sum}");
        Console.ReadKey();
    }

    static int InputInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                // TODO зачем ? value же есть уже для возврата
                int result = value;
                return result;
            }
            else
            {
                Console.WriteLine("Некоректный ввод, попробуйте ещё раз:");
            }
        }
    }

    static (int,int) InputSize()
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
        Random r = new Random();
        int indexSizeA = 0;
        int indexSizeB = 1;
        
        for (int i = 0; i < matrix.GetLength(indexSizeA); i++)
        {
            for (int j = 0; j < matrix.GetLength(indexSizeB); j++)
            {
                matrix[i, j] = r.Next(10);
            }
        }
        return matrix;
    }

    static int SumMatrixVal(int[,] matrix)
    {
        int indexSizeA = 0;
        int indexSizeB = 1;
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(indexSizeA); i++)
        {
            for (int j = 0; j < matrix.GetLength(indexSizeB); j++)
            {
                sum += matrix[i, j];
            }
        }
        return sum;
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
    }
}