namespace Lesson4._1;

internal class Program
{
    static void Main(string[] args)
    {
        // Программа генерации случайной матрицы
        Console.WriteLine("Введите количество строк в матрице:");
        int matrixRow = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов в матрице:");
        int matrixCol = int.Parse(Console.ReadLine());

        int[,] matrix = new int[matrixRow, matrixCol];
        Random r = new Random();
        int sum = 0;

        // TODO Сейчас вывод матрицы и подсчет суммы выполняется одновременно с генерацией
        // матрицы. Нужно сначала сгенерировать матрицу. Потом посчитать сумму и потом вывести.
        // TODO И можно уже выделить отдельными методами, в которые передается матрица
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = r.Next(10);
                sum += matrix[i, j];
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine($"Сумма всех элементов матрицы: {sum}");
        Console.ReadLine();

    }
}