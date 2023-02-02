namespace Lesson7;

public class WorkerRepository
{
    private readonly string _workersFileName = @"C:\UserData\Сотрудники.txt";
    private readonly string[] _workerInfo = { "ID", "Дата записи", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };
    readonly char _separator = '#';

    /// <summary>
    /// Проверка существования файла, создание файла если файл не существует
    /// </summary>
    public void ExistOrCreateFile()
    {
        bool fileExistCheck = File.Exists(_workersFileName);
        StreamWriter streamWriter = new StreamWriter(_workersFileName, fileExistCheck);
        streamWriter.Close();
    }

    /// <summary>
    /// Подсчёт кол-ва записей в файле, и считывание всех строк из файла в массив
    /// </summary>
    /// <returns>Кол-во записей сотрудников в файле, и массив записей из файла</returns>
    public (int, string[]) ReadAndCountWorkers()
    {
        ExistOrCreateFile();
        
        string[] workers = File.ReadAllLines(_workersFileName);
        int workersAmount = workers.Length;
        return (workersAmount, workers);
    }

    /// <summary>
    /// Чтение данных из файла, и запись их в массив
    /// </summary>
    /// <returns>Массив с данными из файла</returns>
    public Worker[] ReadFromFile()
    {
        (int arraySize, string[] arrayData) = ReadAndCountWorkers();
        Worker[] workers = new Worker[arraySize];
        using StreamReader sr = new StreamReader(_workersFileName);
        for (int i = 0; i < arrayData.Length; i++)
        {
            WorkerFromString(arrayData, workers, i);
        }
        sr.Close();
        return workers;
    }

    public void WorkerFromString(string[] arrayData, Worker[] workers, int index)
    {
        string[] splitedData = arrayData[index].Split(_separator);
        workers[index].Id = int.Parse(splitedData[0]);
        workers[index].CreationDate = DateTime.Parse(splitedData[1]);
        workers[index].Fio = splitedData[2];
        workers[index].Age = int.Parse(splitedData[3]);
        workers[index].Height = int.Parse(splitedData[4]);
        workers[index].BirthDate = DateTime.Parse(splitedData[5]);
        workers[index].BirthPlace = splitedData[6];
    }

    /// <summary>
    /// Запись массива в файл в нужном формате
    /// </summary>
    /// <param name="workers">Массив с данными сотрудников</param>
    public void SaveToFile(Worker[] workers)
    {
        using StreamWriter sw = new StreamWriter(_workersFileName);
        {
            for (int i = 0; i < workers.Length; i++)
            {
                WorkerToString(workers, i, sw);
            }
            sw.Close();
        }

    }

    public void WorkerToString(Worker[] workers, int index, StreamWriter sw)
    {
        string workerInfo = string.Empty;
        workerInfo += $"{workers[index].Id}{_separator}";
        workerInfo += $"{workers[index].CreationDate}{_separator}";
        workerInfo += $"{workers[index].Fio}{_separator}";
        workerInfo += $"{workers[index].Age}{_separator}";
        workerInfo += $"{workers[index].Height}{_separator}";
        workerInfo += $"{workers[index].BirthDate}{_separator}";
        workerInfo += $"{workers[index].BirthPlace}";
        sw.WriteLine(workerInfo);
    }

    /// <summary>
    /// Задаёт корректное ID всем записям в файле
    /// </summary>
    /// <param name="workers"></param>
    public void IndexAllWorkers(Worker[] workers)
    {
        for (int i = 0; i < workers.Length; i++)
        {
            workers[i].Id = i + 1;
        }
    }

    /// <summary>
    /// Добавление данных нового сотрудника
    /// </summary>
    /// <param name="newWorker">Данные нового сотрудника</param>
    public void AddWorker(Worker newWorker)
    {
        Worker[] workers = ReadFromFile();
        (int index, _) = ReadAndCountWorkers();
        Array.Resize(ref workers, workers.Length + 1);
        workers[index] = newWorker;
        IndexAllWorkers(workers);
        SaveToFile(workers);
    }

    /// <summary>
    /// Чтение всех записей из из файла
    /// </summary>
    public void GetAllWorkers()
    {
        Console.WriteLine();
        Worker[] workers = ReadFromFile();
        Print(workers);
        Console.WriteLine();
    }

    /// <summary>
    /// Чтение данных по ID
    /// </summary>
    /// <param name="id">ID сотрудника, данные которого нужно вывести</param>
    public void GetWorkerById(int id)
    {
        Worker[] workers = ReadFromFile();
        bool check = false;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == id)
            {
                PrintWorkerById(id, workers, i);
                check = true;
                break;
            }
        }
        if (check == false)
        {
            Console.WriteLine("\nСотрудник с таким ID не найден.\n");
        }
    }

    public void PrintWorkerById(int id, Worker[] workers, int index)
    {
        string workerData = string.Empty;
        workerData += $"{_workerInfo[0]}: {workers[index].Id}, ";
        workerData += $"{_workerInfo[1]}: {workers[index].CreationDate}, ";
        workerData += $"{_workerInfo[2]}: {workers[index].Fio}, ";
        workerData += $"{_workerInfo[3]}: {workers[index].Age}, ";
        workerData += $"{_workerInfo[4]}: {workers[index].Height}, ";
        workerData += $"{_workerInfo[5]}: {workers[index].BirthDate}, ";
        workerData += $"{_workerInfo[6]}: {workers[index].BirthPlace}.";
        Console.WriteLine($"\n{workerData}\n");
    }

    /// <summary>
    /// Метод для удаления записи из файла
    /// </summary>
    /// <param name="id">ID сотрудника, запись которого нужно удалить</param>
    public void DeleteWorker(int id)
    {
        Worker[] workers = ReadFromFile();
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == id)
            {
                Array.Resize(ref workers, workers.Length + 1);
                for (i = id - 1; i < workers.Length - 1; i++)
                {
                    workers[i] = workers[i + 1];
                }
                Array.Resize(ref workers, workers.Length - 2);
                IndexAllWorkers(workers);
            }
        }
        SaveToFile(workers);
    }

    public void GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
    {
        Console.WriteLine();
        Worker[] workers = ReadFromFile();
        Worker[] workersByDates = new Worker[workers.Length];
        int j = 0;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].CreationDate <= dateTo)
            {
                if (dateFrom <= workers[i].CreationDate)
                {
                    workersByDates[j] = workers[i];
                    j++;
                }
            }
        }
        workersByDates = ResizeForGetWorkersBetweenTwoDates(workersByDates);
        Print(workersByDates);
    }

    public void Print(Worker[] workers)
    {
        for (int i = 0; i < workers.Length; i++)
        {
            string workerData = string.Empty;
            workerData += $"{_workerInfo[0]}: {workers[i].Id}, ";
            workerData += $"{_workerInfo[1]}: {workers[i].CreationDate}, ";
            workerData += $"{_workerInfo[2]}: {workers[i].Fio}, ";
            workerData += $"{_workerInfo[3]}: {workers[i].Age}, ";
            workerData += $"{_workerInfo[4]}: {workers[i].Height}, ";
            workerData += $"{_workerInfo[5]}: {workers[i].BirthDate}, ";
            workerData += $"{_workerInfo[6]}: {workers[i].BirthPlace}.";
            Console.WriteLine(workerData);
        }
    }

    public Worker[] ResizeForGetWorkersBetweenTwoDates(Worker[] workersByDates)
    {
        for (int i = 0; i < workersByDates.Length; i++)
        {
            if (workersByDates[i].Id == 0)
            {
                Array.Resize(ref workersByDates, workersByDates.Length - 1);
                i--;
            }
        }
        return workersByDates;
    }
}