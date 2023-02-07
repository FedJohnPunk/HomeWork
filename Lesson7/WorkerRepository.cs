namespace Lesson7;

// TODO основная ошибка - не убрал из репозитория все, что связано с выводом на экран
// репозиторий только манипулирует данными из файла
// вывод результатов на экран - это отдельное назначение
// если например, вывод будет не на экран а отправкой на почту, ты заменишь
// класс который выводит, на другой, который отправляет по почте - а репозиторий никак не изменится
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
        // TODO если файл существует, нужно просто вернуться ничего не делая
        // иначе - создать файл
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
        // TODO ты же сам массив возвращаешь, если надо можно его длину определить
        // нет необходимости длину возвращать отдельным значением вместе с массивом
        int workersAmount = workers.Length;
        // TODO вообще кортежи используются в очень редких, специфичных случаях
        // я больше для знакомства показал - в большинстве ситуаций
        // думай, как использовать только одно возвращаемое значение. это может быть экземпляр класса,
        // если нужно много данных вернуть - это будут поля класса.
        // например, когда нужно ввести длину двумерного массива
        // делается класс: class ArrayDimension { int SizeA; int SizeB; } и его экземпляр возвращается 
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

    // TODO нужно, чтобы тип возвращаемого значени был Worker вместо передачи массива и индекса
    // а параметром должна быть строка для конкретного воркера
    // те нужно стремиться передать как можно меньше информации, если из нее можно что-то заранее выделить
    // Workers[i] = WorkerFromString(arrayData[i]);
    // и подсказка - можно создавать экземпляр класса и сразу инициировать свойства
    // var worker = new Worker
    // {
    //      Id = .,
    //      CreationDate = .,
    // }
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
        // TODO эта скобка и соответствующая закрывающая не нужны
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

    // TODO такой способ не подходит - нельзя изменять Id у уже записанных воркеров
    // допустим у тебя есть другой файл с данными, который запоминает Id
    // например, есть список задач, в задаче указан Id воркера, который ее выполняет
    // если перенумеруешь, то все перепутается
    //
    // Нужно, чтобы новый воркер имел Id, которого точно нет в списке Id
    // В базах данных обычно используется отдельное хранящееся значение, которое при добавлении
    // новой записи просто на 1 увеличивается
    //
    // Но тебе пока негде хранить, нужно выкрутиться имеющимся списком
    // Вот у тебя есть список Id: 1,2,15,29,3,10...
    // если их отметить на числовой прямой, какие можно общие наблюдения сделать о этом наборе?
    //
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

    // TODO этот метод должен в менеджере:
    // получает массив воркеров в репозитории и выводит массив с помющью
    // класса, который отвечает за вывод (например WorkerPrinter)
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

    // TODO этот метод должен быть в менеджере:
    // находит воркера или null и печатает в зависимости от результата
    // воркера или ошибку
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

    // TODO здесь id не используется
    // TODO нет смысла передавать массив и индекс, можно же сразу одного воркера передать
    // тогда это будет просто метод печати одного воркера
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
        // TODO сделать последовательно два действия
        // 1. сначала найди индекс элумента для удаления по Id
        // если не нашел, то дальше делать нечего
        // 2. потом перестрой массив
        // подумай как не копировать кучу элементов массива (это называется сдвиг в массиве, но
        // он в данном случае не нужен). подсказка - можно менять местами элементы массива
        Worker[] workers = ReadFromFile();
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == id)
            {
                // TODO этот ресайз на самом деле не нужен, просто цикл должен быть на один элемент меньше
                // тогда и ресайз на -2 будет корректных на -1 (ты же 1 элемент удаляешь)
                Array.Resize(ref workers, workers.Length + 1);
                // TODO здесь ошибка, id же это идентификатор, а не номер в массиве
                // просто ты схитрил и перенумеровал :-)
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

    // TODO этот метод должен вернуть массив, который является часть исходного
    // с учетом ограничения по датам
    // а печать полученного списка должна быть отдельно в менеджере
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
        // TODO посмотри, какое значение будет иметь j в этом месте (умеешь же брекпоинт ставить?)
        // это же и есть количество элементов, которые заполнены, можно сразу ресайз сделать
        workersByDates = ResizeForGetWorkersBetweenTwoDates(workersByDates);
        Print(workersByDates);
    }

    // TODO Нужно убрать из репозитория в отдельный класс (статический)
    // например public static class WorkerPrinter {}
    public void Print(Worker[] workers)
    {
        for (int i = 0; i < workers.Length; i++)
        {
            // TODO это нужно отдельным методом, который напечатает одного воркера
            string workerData = string.Empty;
            workerData += $"{_workerInfo[0]}: {workers[i].Id}, ";
            workerData += $"{_workerInfo[1]}: {workers[i].CreationDate}, ";
            workerData += $"{_workerInfo[2]}: {workers[i].Fio}, ";
            workerData += $"{_workerInfo[3]}: {workers[i].Age}, ";
            workerData += $"{_workerInfo[4]}: {workers[i].Height}, ";
            workerData += $"{_workerInfo[5]}: {workers[i].BirthDate}, ";
            workerData += $"{_workerInfo[6]}: {workers[i].BirthPlace}.";
            Console.WriteLine(workerData);
            // <<<
        }
    }

    public Worker[] ResizeForGetWorkersBetweenTwoDates(Worker[] workersByDates)
    {
        for (int i = 0; i < workersByDates.Length; i++)
        {
            if (workersByDates[i].Id == 0)
            {
                // TODO обрати внимание на неоптимальность
                // ты делаешь много ресайзов на один элемент, а можно один ресайз на заданное количество
                // элементов. ресайз очень большого массива - это очень долгая операция, которая
                // требует много памяти (нужно выделить место под новый массив и туда скопировать)
                // поэтому лучше один ресайз
                Array.Resize(ref workersByDates, workersByDates.Length - 1);
                i--;
            }
        }
        return workersByDates;
    }
}