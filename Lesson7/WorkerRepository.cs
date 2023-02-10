namespace Lesson7;

public class WorkerRepository
{
    private readonly string _workersFileName = @"C:\UserData\Сотрудники.txt";
    readonly char _separator = '#';

    /// <summary>
    /// Проверка существования файла, создание файла если файл не существует
    /// </summary>
    public void ExistOrCreateFile()
    {
        bool fileExistCheck = File.Exists(_workersFileName);
        if (fileExistCheck)
        {
            return;
        }
        if (!fileExistCheck)
        {
            using StreamWriter streamWriter = new StreamWriter(_workersFileName, fileExistCheck);
            streamWriter.Close();
        }
    }

    /// <summary>
    /// Чтение данных из файла, и запись их в массив
    /// </summary>
    /// <returns>Массив с данными из файла</returns>
    public Worker[] ReadFromFile()
    {
        ExistOrCreateFile();

        string[] workersData = File.ReadAllLines(_workersFileName);

        Worker[] workers = new Worker[workersData.Length];
        for (int i = 0; i < workersData.Length; i++)
        {
            workers[i] = WorkerFromString(workersData[i]);
        }
        return workers;
    }

    public Worker WorkerFromString(string arrayData)
    {
        string[] splitedData = arrayData.Split(_separator);
        Worker worker = new()
        {
            Id = int.Parse(splitedData[0]),
            CreationDate = DateTime.Parse(splitedData[1]),
            Fio = splitedData[2],
            Age = int.Parse(splitedData[3]),
            Height = int.Parse(splitedData[4]),
            BirthDate = DateTime.Parse(splitedData[5]),
            BirthPlace = splitedData[6]
        };
        return worker;
    }

    /// <summary>
    /// Запись массива в файл в нужном формате
    /// </summary>
    /// <param name="workers">Массив с данными сотрудников</param>
    public void SaveToFile(Worker[] workers)
    {
        using StreamWriter sw = new StreamWriter(_workersFileName);
        foreach (var worker in workers)
        {
            sw.WriteLine(WorkerToString(worker));
        }
        sw.Close();
    }

    public string WorkerToString(Worker worker)
    {
        string workerInfo = string.Empty;
        workerInfo += $"{worker.Id}{_separator}";
        workerInfo += $"{worker.CreationDate}{_separator}";
        workerInfo += $"{worker.Fio}{_separator}";
        workerInfo += $"{worker.Age}{_separator}";
        workerInfo += $"{worker.Height}{_separator}";
        workerInfo += $"{worker.BirthDate}{_separator}";
        workerInfo += $"{worker.BirthPlace}";
        return workerInfo;
    }

    public static int IndexWorker(Worker[] workers)
    {
        int index = 1;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id >= index)
            {
                index = workers[i].Id + 1;
            }
        }
        return index;
    }

    /// <summary>
    /// Добавление данных нового сотрудника
    /// </summary>
    /// <param name="newWorker">Данные нового сотрудника</param>
    public void AddWorker(Worker newWorker)
    {
        Worker[] workers = ReadFromFile();
        newWorker.Id = IndexWorker(workers);
        Array.Resize(ref workers, workers.Length + 1);
        workers[workers.Length - 1] = newWorker;
        SaveToFile(workers);
    }

    public int FindWorkerIndexById(int id)
    {
        Worker[] workers = ReadFromFile();
        int workerIndex = -1;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == id)
            {
                workerIndex = i;
                break;
            }
        }
        return workerIndex;
    }
    
    /// <summary>
    /// Чтение данных по ID
    /// </summary>
    /// <param name="id">ID сотрудника, данные которого нужно вывести</param>
    public Worker GetWorkerByIndex(int workerIndex)
    {
        Worker[] workers = ReadFromFile();
        return workers[workerIndex];
    }

    /// <summary>
    /// Метод для удаления записи из файла
    /// </summary>
    /// <param name="id">ID сотрудника, запись которого нужно удалить</param>
    public void DeleteWorkerByIndex(int workerIndex)
    {
        Worker[] workers = ReadFromFile();
        workers[workerIndex] = workers[workers.Length - 1];
        Array.Resize(ref workers, workers.Length - 1);
        SaveToFile(workers);
    }

    public Worker[] GetWorkersByDate(DateTime dateFrom, DateTime dateTo)
    {
        Worker[] workers = ReadFromFile();

        Worker[] workersByDates = new Worker[workers.Length];
        int counter = 0;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].CreationDate <= dateTo && dateFrom <= workers[i].CreationDate)
            {
                workersByDates[counter] = workers[i];
                counter++;
            }
        }
        Array.Resize(ref workersByDates, workersByDates.Length - (workersByDates.Length - counter));
        return workersByDates;
    }
}