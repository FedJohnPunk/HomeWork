namespace Lesson7;

internal partial class Program
{
    struct Repository
    {
        public Worker[] GetAllWorkers()
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров
        }

        public Worker GetWorkerById(int id)
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
        }

        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
        }

        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
        }
    }
}