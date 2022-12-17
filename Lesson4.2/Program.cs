namespace Lesson4._2;

internal class Program
{
    static void Main(string[] args)
    {
        // Сложение матриц
        Console.WriteLine("Введите количество строк в матрице:");
        int matrixRow = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов в матрице:");
        int matrixCol = int.Parse(Console.ReadLine());

        int[,] matrixA = new int[matrixRow, matrixCol];
        int[,] matrixB = new int[matrixRow, matrixCol];
        int[,] matrixC = new int[matrixRow, matrixCol];

        Random r = new Random();
        // Создаём случайную матрицу A
        Console.WriteLine();
        Console.WriteLine("Матрица A");
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.GetLength(1); j++)
            {
                matrixA[i, j] = r.Next(10);
                Console.Write($"{matrixA[i, j]} ");
            }
            Console.WriteLine();
        }
        // Создаём случайную матрицу B
        Console.WriteLine();
        Console.WriteLine("Матрица B");
        for (int i = 0; i < matrixB.GetLength(0); i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                matrixB[i, j] = r.Next(10);
                Console.Write($"{matrixB[i, j]} ");
            }
            Console.WriteLine();
        }
        // Создаём матрицу C путём сложения матриц
        Console.WriteLine();
        Console.WriteLine("Матрица C");
        for (int i = 0; i < matrixC.GetLength(0); i++)
        {
            for (int j = 0; j < matrixC.GetLength(1); j++)
            {
                matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                Console.Write($"{matrixC[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}