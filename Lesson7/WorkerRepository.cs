using System;

namespace Lesson7;

public class WorkerRepository
{
    private string _workersFileName = @"C:\UserData\Сотрудники.txt";
    private string[] _workerInfo = { "ID", "Дата записи", "Ф.И.О.", "Возраст", "Рост", "Дата рождения", "Место рождения" };

    char _separator = '#';

    public int CountWorkersAmount(string fileName)
    {
        string[] workers = File.ReadAllLines(fileName);
        int workersAmount = workers.Length;
        return workersAmount;
    }

    private void Resize(bool check, Worker[] workers)
    {
        if (check)
        {
            Array.Resize(ref workers, workers.Length + 1);
        }
    }

    public Worker[] ReadFile()
    {
        Worker[] workers = new Worker[CountWorkersAmount(_workersFileName)];

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

    public void SaveFile(Worker[] workers)
    {
        bool fileExistCheck = File.Exists(_workersFileName);
        StreamWriter sw = new StreamWriter(_workersFileName, fileExistCheck);
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
        }

    }

    /// <summary>
    /// Добавление данных нового сотрудника
    /// </summary>
    /// <param name="worker"></param>
    public void AddWorker(Worker worker)
    {
        // присваиваем worker уникальный ID,
        int index = CountWorkersAmount(_workersFileName);
        index++;
        worker.Id = index;
        // дописываем нового worker в файл
        Worker[] workers = ReadFile();
        Resize(index >= workers.Length, workers);
        workers[index] = worker;
        SaveFile(workers);
    }

    /// <summary>
    /// Чтение всех записей из из файла
    /// </summary>
    /// <returns>Данные всех сотрудников</returns>
    public void PrintAllWorkers()
    {
        // здесь происходит чтение из файла
        // и возврат массива считанных экземпляров
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
        Console.ReadLine();
    }

    /// <summary>
    /// Чтение данных по ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void PrintWorkerById(int id)
    {
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
        Console.ReadLine();
    }

    /// <summary>
    /// Удаление записи
    /// </summary>
    /// <param name="id"></param>
    public void DeleteWorker(int id)
    {
        Worker[] workers = ReadFile();
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == id)
            {
                Array.Clear(workers, i, 1);
            }
        }
    }

    public void PrintWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
    {
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
        Console.ReadLine();
    }
}