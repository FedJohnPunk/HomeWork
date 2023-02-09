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
        if (fileExistCheck == false)
        {
            StreamWriter streamWriter = new StreamWriter(_workersFileName, fileExistCheck);
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

        string[] arrayData = File.ReadAllLines(_workersFileName);

        Worker[] workers = new Worker[arrayData.Length];
        using StreamReader sr = new StreamReader(_workersFileName);
        for (int i = 0; i < arrayData.Length; i++)
        {
            workers[i] = WorkerFromString(arrayData[i]);
        }
        sr.Close();
        return workers;
    }

    public Worker WorkerFromString(string arrayData)
    {
        Worker worker = new();
        string[] splitedData = arrayData.Split(_separator);
        worker.Id = int.Parse(splitedData[0]);
        worker.CreationDate = DateTime.Parse(splitedData[1]);
        worker.Fio = splitedData[2];
        worker.Age = int.Parse(splitedData[3]);
        worker.Height = int.Parse(splitedData[4]);
        worker.BirthDate = DateTime.Parse(splitedData[5]);
        worker.BirthPlace = splitedData[6];
        return worker;
    }

    /// <summary>
    /// Запись массива в файл в нужном формате
    /// </summary>
    /// <param name="workers">Массив с данными сотрудников</param>
    public void SaveToFile(Worker[] workers)
    {
        using StreamWriter sw = new StreamWriter(_workersFileName);
        for (int i = 0; i < workers.Length; i++)
        {
            WorkerToString(workers, i, sw);
        }
        sw.Close();
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

    public int IndexWorker(Worker[] workers)
    {
        int index = 1;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == index)
            {
                index++;
                i = 0;
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

    /// <summary>
    /// Чтение всех записей из из файла
    /// </summary>
    public Worker[] GetAllWorkers()
    {
        Console.WriteLine();
        Worker[] workers = ReadFromFile();
        return workers;
    }

    /// <summary>
    /// Чтение данных по ID
    /// </summary>
    /// <param name="id">ID сотрудника, данные которого нужно вывести</param>
    public Worker GetWorkerById(int id)
    {
        Worker[] workers = ReadFromFile();
        bool check = false;
        while (true)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].Id == id)
                {
                    Worker worker = workers[i];
                    return worker;
                }
            }
            if (check == false)
            {
                Console.WriteLine("\nСотрудник с таким ID не найден. Повторите ввод:\n");
            }
        }
    }

    /// <summary>
    /// Метод для удаления записи из файла
    /// </summary>
    /// <param name="id">ID сотрудника, запись которого нужно удалить</param>
    public bool DeleteWorker(int id)
    {
        Worker[] workers = ReadFromFile();
        bool existWorker = false;
        int workerIndex = 0;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == id)
            {
                existWorker = true;
                workerIndex = i;
            }
        }
        bool succes = false;
        if (existWorker == true)
        {
            workers[workerIndex] = workers[workers.Length - 1];
            Array.Resize(ref workers, workers.Length - 1);
            SaveToFile(workers);
            succes = true;
        }
        return succes;
    }

    public Worker[] GetWorkersByDate(DateTime dateFrom, DateTime dateTo)
    {
        Console.WriteLine();
        Worker[] workers = ReadFromFile();
        Worker[] workersByDates = new Worker[workers.Length];
        int counter = 0;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].CreationDate <= dateTo)
            {
                if (dateFrom <= workers[i].CreationDate)
                {
                    workersByDates[counter] = workers[i];
                    counter++;
                }
            }
        }
        int emptyEllementsNumber = workersByDates.Length - counter;
        Array.Resize(ref workersByDates, workersByDates.Length - emptyEllementsNumber);
        return workersByDates;
    }
}