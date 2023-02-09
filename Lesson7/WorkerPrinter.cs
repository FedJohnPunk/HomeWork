namespace Lesson7;

public class WorkerPrinter
{
    private readonly string[] _workerInfo = { "ID", "Дата записи", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };

    public void PrintArrayOfWorkers(Worker[] workers)
    {
        foreach (Worker worker in workers)
        {
            PrintWorker(worker);
        }
    }

    public void PrintWorker(Worker worker)
    {
        string workerData = string.Empty;
        workerData += $"{_workerInfo[0]}: {worker.Id}, ";
        workerData += $"{_workerInfo[1]}: {worker.CreationDate}, ";
        workerData += $"{_workerInfo[2]}: {worker.Fio}, ";
        workerData += $"{_workerInfo[3]}: {worker.Age}, ";
        workerData += $"{_workerInfo[4]}: {worker.Height}, ";
        workerData += $"{_workerInfo[5]}: {worker.BirthDate}, ";
        workerData += $"{_workerInfo[6]}: {worker.BirthPlace}.";
        Console.WriteLine(workerData);
    }
}
