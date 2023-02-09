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
        // TODO не надо проверять логическое выражение на равенство true/false
        // логическое выражение само по себе имеет значение true или false
        // TODO из удобства чтения кода лучше сделать выход если true
        // тогда следующие операторы не будут иметь лишний отступ
        if (fileExistCheck == false)
        {
            // TODO здесь нужно использовать using, пока просто для информации
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

        // TODO название лучше более конкретное
        string[] workerLines = File.ReadAllLines(_workersFileName);

        Worker[] workers = new Worker[workerLines.Length];
        // TODO зачем этот ридер, он же не используется
        using StreamReader sr = new StreamReader(_workersFileName);
        for (int i = 0; i < workerLines.Length; i++)
        {
            workers[i] = WorkerFromString(workerLines[i]);
        }
        sr.Close();
        return workers;
    }

    public Worker WorkerFromString(string arrayData)
    {
        Worker worker = new();
        string[] splitedData = arrayData.Split(_separator);
        // TODO я же предлагал сделать инициализацию свойств
        // Worker worker = new()
        // {
        //      Id = ..,
        // }
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
        // TODO когда не нужно именно индекс иметь, лучше использовать
        // foreach вместо for - попробуй заменить везде, будет проще выглядеть
        for (int i = 0; i < workers.Length; i++)
        {
            // TODO нужно уменьшать количество передаваемых без необходимости данных
            // должен быть такой вызов:
            // sw.WriteLine(WorkerToString(workers[i]));
            // методу преобразования в строку не нужно знать, как потом эта строка используется
            // может не в файл данных нужно, а в лог-файл записать
            // 
            // Это проверяется критериями - единственное назначение метода и правильность названия
            // у тебя не единственное назначение: преобразует в строку и еще и записывает в файл
            // название не отражает то, что записывает в файл
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

    // TODO здесь хорошо придумал пропуски искать!
    //
    // но сбрасывать  i = 0  нехорошо - в целом с for так нельзя просто запомни :)
    // а в частности - ты же уже начальные элементы до какого-то индекса проверил
    // не очень оптимально их заново проверять, когда большой массив это будет очень медленно
    // если у тебя например нет пропусков, ты для каждого значения будешь проверять.
    //
    // Подсказка: проще не пропуски искать (для этого по хорошему упорядоченным держать по возрастанию Id)
    // а просто максимальный Id из всех найти - это гарантировано один цикл по всем
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

    // TODO а зачем это метод и здесь же Console...
    /// <summary>
    /// Чтение всех записей из из файла
    /// </summary>
    public Worker[] GetAllWorkers()
    {
        Console.WriteLine();
        Worker[] workers = ReadFromFile();
        return workers;
    }

    // TODO у тебя есть 2 метода GetWorkerById и DeleteWorker(добавь тоже ById)
    // сделай для них метод WorkerIndexById(int Id)
    // и переделать эти методы с его использованием
    // Это тоже к примеру единственности назначения метода и еще
    // повторного использования одинакового кода в разных местах
    // (если например ошибку в поиске обнаружишь, тебе только метод поиска исправить а не оба метода
    // в которых нужно по Id искать)
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
                // TODO убрать все Console!!!!
                // это у тебя сейчас ввод и вывод через консоль, а если
                // прикрутить к этому интерфейс, то прийдется переделывать репозиторий
                // а он же только за данные должен отвечать
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
        // TODO если сделать workerIndex = -1;
        // то если его значение и осталось -1, то значит не нашли
        // не нужно дополнительно bool переменную
        int workerIndex = 0;
        for (int i = 0; i < workers.Length; i++)
        {
            if (workers[i].Id == id)
            {
                existWorker = true;
                workerIndex = i;
                // TODO если значение найдено, то нужно прервать дальнейшее выполнение цикла
                // оператором break;
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
        // TODO научись пользоваться поиском, чтобы поискать все Console в файле
        Console.WriteLine();
        Worker[] workers = ReadFromFile();

        Worker[] workersByDates = new Worker[workers.Length];
        int counter = 0;
        for (int i = 0; i < workers.Length; i++)
        {
            // TODO здесь 2 вложенных if
            // объедини их в один испольуя логический оператор " && "
            if (workers[i].CreationDate <= dateTo)
            {
                if (dateFrom <= workers[i].CreationDate)
                {
                    workersByDates[counter] = workers[i];
                    counter++;
                }
            }
        }
        // TODO а подставь это выражение вместо emptyEllementsNumber в следующей строке
        // что получится?
        int emptyEllementsNumber = workersByDates.Length - counter;
        Array.Resize(ref workersByDates, workersByDates.Length - emptyEllementsNumber);
        return workersByDates;
    }
}