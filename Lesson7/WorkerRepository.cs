using System;

namespace Lesson7;

public class WorkerRepository
{
    private string _workersFileName = @"C:\UserData\Сотрудники.txt";
    private string[] _workerInfo = { "ID", "Дата записи", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };

    char _separator = '#';

    /// <summary>
    /// Пользователь выбирает операцию
    /// </summary>
    public void ChooseOperation()
    {
        Console.WriteLine(
            "Введите [1], чтобы добавить нового сотрудника, " +
            "\nВведите [2], чтобы вывести данные всех сотрудников," +
            "\nВведите [3], чтобы вывести данные конктретного сотрудника," +
            "\nВведите [4], чтобы удалить данные сотрудника," +
            "\nВведите [5], чтобы вывести данные сотрудников за заданый промежуток времени.");
        char key = Console.ReadKey(true).KeyChar;
        if (char.ToLower(key) == '1')
        {
            Worker worker = new Worker();
            Console.WriteLine("Введите Ф.И.О. сотрудника: ");
            worker.Fio = InputStringCheck();
            Console.WriteLine("Введите возраст сотрудника: ");
            worker.Age = int.Parse(InputStringCheck());
            Console.WriteLine("Введите рост сотрудника: ");
            worker.Height = int.Parse(InputStringCheck());
            Console.WriteLine("Введите дату рождения сотрудника в виде 'xx.xx.xx': ");
            worker.BirthDate = DateTime.Parse(InputStringCheck());
            Console.WriteLine("Введите место рождения сотрудника: ");
            worker.BirthPlace = InputStringCheck();

            AddWorker(worker);
            RepeatOperationOrNot();
        }
        else if (char.ToLower(key) == '2')
        {
            PrintAllWorkers();
            RepeatOperationOrNot();
        }
        else if (char.ToLower(key) == '3')
        {
            Console.WriteLine("Введите ID сотрудника для отображения данных: ");
            int id = int.Parse(InputStringCheck());
            PrintWorkerById(id);
            RepeatOperationOrNot();
        }
        else if (char.ToLower(key) == '4')
        {
            Console.WriteLine("Введите ID сотрудника для удаления данных: ");
            int id = int.Parse(InputStringCheck());
            DeleteWorker(id);
            RepeatOperationOrNot();
        }
        else if (char.ToLower(key) == '5')
        {
            Console.WriteLine("Введите дату 1 ");
            DateTime dateFrom = DateTime.Parse(InputStringCheck());
            Console.WriteLine("Введите дату 2 ");
            DateTime dateTo = DateTime.Parse(InputStringCheck());
            PrintWorkersBetweenTwoDates(dateFrom, dateTo);
            RepeatOperationOrNot();
        }
        else
        {
            Console.WriteLine("Некоректный ввод, попробуйте ещё раз:");
            ChooseOperation();
        }
    }

    public void RepeatOperationOrNot()
    {
        Console.WriteLine("Введите [1] для новой операции, \nДля выхода из программы нажмите любую клавишу:");
        char key = Console.ReadKey(true).KeyChar;
        if (key == '1')
        {
            ChooseOperation();
        }
    }

    public string InputStringCheck()
    {
        while (true)
        {
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Введите корректное значение:");
            }
            else
            {
                return s;
            }
        }
    }

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
    /// Подсчёт кол-ва записей в файле
    /// </summary>
    /// <returns>Кол-во записей сотрудников в файле</returns>
    public int CountWorkersAmount()
    {
        ExistOrCreateFile();
        
        string[] workers = File.ReadAllLines(_workersFileName);
        int workersAmount = workers.Length;
        return workersAmount;
    }

    /// <summary>
    /// Чтение данных из файла, и запись их в массив
    /// </summary>
    /// <returns>Массив с данными из файла</returns>
    public Worker[] ReadFile()
    {
        Worker[] workers = new Worker[CountWorkersAmount()];
        using (StreamReader sr = new StreamReader(_workersFileName))
        {
            string[] data = File.ReadAllLines(_workersFileName);
            for (int i = 0; i < data.Length; i++)
            {
                string[] splitedData = data[i].Split(_separator);
                workers[i].Id = int.Parse(splitedData[0]);
                workers[i].CreationDate = DateTime.Parse(splitedData[1]);
                workers[i].Fio = splitedData[2];
                workers[i].Age = int.Parse(splitedData[3]);
                workers[i].Height = int.Parse(splitedData[4]);
                workers[i].BirthDate = DateTime.Parse(splitedData[5]);
                workers[i].BirthPlace = splitedData[6];
            }
            sr.Close();
            return workers;
        }
    }

    /// <summary>
    /// Запись массива в файл в нужном формате
    /// </summary>
    /// <param name="workers">Массив с данными сотрудников</param>
    public void SaveFile(Worker[] workers)
    {
        using StreamWriter sw = new StreamWriter(_workersFileName);
        {
            for (int i = 0; i < workers.Length; i++)
            {
                string workerInfo = string.Empty;
                workerInfo += $"{workers[i].Id}{_separator}";
                workerInfo += $"{workers[i].CreationDate}{_separator}";
                workerInfo += $"{workers[i].Fio}{_separator}";
                workerInfo += $"{workers[i].Age}{_separator}";
                workerInfo += $"{workers[i].Height}{_separator}";
                workerInfo += $"{workers[i].BirthDate}{_separator}";
                workerInfo += $"{workers[i].BirthPlace}";
                sw.WriteLine(workerInfo);
            }
            sw.Close();
        }

    }

    /// <summary>
    /// Добавление данных нового сотрудника
    /// </summary>
    /// <param name="newWorker">Данные нового сотрудника</param>
    public void AddWorker(Worker newWorker)
    {
        Worker[] workers = ReadFile();
        int index = CountWorkersAmount();
        newWorker.Id = index + 1;
        Array.Resize(ref workers, workers.Length + 1);
        workers[index] = newWorker;
        SaveFile(workers);
        Console.WriteLine();
        Console.WriteLine("Данные сотрудника добавлены.");
        Console.WriteLine();
    }

    /// <summary>
    /// Чтение всех записей из из файла
    /// </summary>
    public void PrintAllWorkers()
    {
        Console.WriteLine();
        Worker[] workers = ReadFile();
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
        Console.WriteLine();
    }

    /// <summary>
    /// Чтение данных по ID
    /// </summary>
    /// <param name="id">ID сотрудника, данные которого нужно вывести</param>
    public void PrintWorkerById(int id)
    {
        Console.WriteLine();
        Worker[] workers = ReadFile();
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == id)
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
                break;
            }
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Метод для удаления записи из файла
    /// </summary>
    /// <param name="id">ID сотрудника, запись которого нужно удалить</param>
    public void DeleteWorker(int id)
    {
        Worker[] workers = ReadFile();
        using StreamWriter sw = new StreamWriter(_workersFileName);
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id != id)
            {
                string workerInfo = string.Empty;
                workerInfo += $"{workers[i].Id}{_separator}";
                workerInfo += $"{workers[i].CreationDate}{_separator}";
                workerInfo += $"{workers[i].Fio}{_separator}";
                workerInfo += $"{workers[i].Age}{_separator}";
                workerInfo += $"{workers[i].Height}{_separator}";
                workerInfo += $"{workers[i].BirthDate}{_separator}";
                workerInfo += $"{workers[i].BirthPlace}";
                sw.WriteLine(workerInfo);
            }
        }
        sw.Close();
        Console.WriteLine();
        Console.WriteLine("Данные удалены.");
        Console.WriteLine();
    }

    public void PrintWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
    {
        Console.WriteLine();
        Worker[] workers = ReadFile();
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].CreationDate < dateTo)
            {
                if (dateFrom < workers[i].CreationDate)
                {
                    Console.WriteLine(workers[i]);
                }
            }
        }
        Console.WriteLine();
    }
}