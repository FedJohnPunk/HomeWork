namespace Lesson7
{
    internal class WorkerManager
    {
        readonly WorkerRepository workerRepository = new WorkerRepository();
        readonly WorkerPrinter workerPrinter = new WorkerPrinter();


        /// <summary>
        /// Пользователь выбирает операцию
        /// </summary>
        public void MainOperation()
        {
            bool repeat = true;
            while (repeat == true)
            {
                char key = InputChar();
                switch (key)
                {
                    case '1':
                        AddWorker();
                        break;
                    case '2':
                        PrintAllWorkers();
                        break;
                    case '3':
                        PrintWorkerById();
                        break;
                    case '4':
                        DeleteWorker();
                        break;
                    case '5':
                        PrintWorkersByDate();
                        break;
                    default:
                        Console.WriteLine("\nНекоректный ввод, попробуйте ещё раз:");
                        break;
                }
                repeat = RepeatOperationOrNot();
            }
        }

        public static char InputChar()
        {
            Console.WriteLine(
                "Введите [1], чтобы добавить нового сотрудника, " +
                "\nВведите [2], чтобы вывести данные всех сотрудников," +
                "\nВведите [3], чтобы вывести данные конктретного сотрудника," +
                "\nВведите [4], чтобы удалить данные сотрудника," +
                "\nВведите [5], чтобы вывести данные сотрудников за заданый промежуток времени.");
            char key = Console.ReadKey(true).KeyChar;
            return key;
        }

        private void AddWorker()
        {
            Worker worker = new Worker();
            worker.CreationDate = DateTime.Now;
            Console.WriteLine("\nВведите Ф.И.О. сотрудника: ");
            worker.Fio = InputStringCheck();
            Console.WriteLine("\nВведите возраст сотрудника: ");
            worker.Age = int.Parse(InputStringCheck());
            Console.WriteLine("\nВведите рост сотрудника: ");
            worker.Height = int.Parse(InputStringCheck());
            Console.WriteLine("\nВведите дату рождения сотрудника в виде 'xx.xx.xx': ");
            worker.BirthDate = DateTime.Parse(InputStringCheck());
            Console.WriteLine("\nВведите место рождения сотрудника: ");
            worker.BirthPlace = InputStringCheck();

            workerRepository.AddWorker(worker);
            Console.WriteLine("\nДанные сотрудника добавлены.\n");
        }

        private void PrintAllWorkers()
        {
            workerPrinter.PrintArrayOfWorkers(workerRepository.GetAllWorkers());
        }

        private void PrintWorkerById()
        {
            Console.WriteLine("\nВведите ID сотрудника для отображения данных:");
            int id = int.Parse(InputStringCheck());
            workerPrinter.PrintWorker(workerRepository.GetWorkerById(id));
        }

        private void DeleteWorker()
        {
            Console.WriteLine("\nВведите ID сотрудника для удаления данных: ");
            int id = int.Parse(InputStringCheck());
            bool succes = workerRepository.DeleteWorker(id);
            if (succes == true)
            {
                Console.WriteLine("\nДанные удалены.\n");
            }
            else if (succes == false)
            {
                Console.WriteLine("\nДанные не найдены.\n");
            }
        }

        private void PrintWorkersByDate()
        {
            Console.WriteLine("Введите дату от: ");
            DateTime dateFrom = DateTime.Parse(InputStringCheck());
            Console.WriteLine("Введите дату до: ");
            DateTime dateTo = DateTime.Parse(InputStringCheck());
            workerPrinter.PrintArrayOfWorkers(workerRepository.GetWorkersByDate(dateFrom, dateTo));
        }

        public static bool RepeatOperationOrNot()
        {
            Console.WriteLine("\nВведите [1] для новой операции, \nДля выхода из программы нажмите любую клавишу:\n");
            bool newOperationNeeded;
            char key = Console.ReadKey(true).KeyChar;
            if (key == '1')
            {
                newOperationNeeded = true;
            }
            else
            {
                newOperationNeeded = false;
            }
            return newOperationNeeded;
        }

        public static string InputStringCheck()
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
    }
}
