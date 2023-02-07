namespace Lesson7
{
    internal class WorkerManager
    {
        readonly WorkerRepository workerRepository = new WorkerRepository();

        /// <summary>
        /// Пользователь выбирает операцию
        /// </summary>
        public void ChooseOperation()
        {
            // TODO предложение ввода и возврат символа нужно отдельным методом
            Console.WriteLine(
                "Введите [1], чтобы добавить нового сотрудника, " +
                "\nВведите [2], чтобы вывести данные всех сотрудников," +
                "\nВведите [3], чтобы вывести данные конктретного сотрудника," +
                "\nВведите [4], чтобы удалить данные сотрудника," +
                "\nВведите [5], чтобы вывести данные сотрудников за заданый промежуток времени.");
            char key = Console.ReadKey(true).KeyChar;

            // TODO содержимое каждого блока if должно быть отдельным методом
            // например
            //      private void AddWirker() { ... }
            //      private void PrintAllWorkers() { ... }
            // после этого тебе будет проще читать код и понять, как другие исправления внести
            // TODO После того, как остальное поправишь, переделай много if на один swith
            if (char.ToLower(key) == '1')
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
                RepeatOperationOrNot();
            }
            // TODO везде ToLower - во первых это же цифра, она одинаковая в врехнем и нижнем регистре
            // во вторых можно же при вводе сразу сделать один раз ToLower
            else if (char.ToLower(key) == '2')
            {
                workerRepository.GetAllWorkers();
                RepeatOperationOrNot();
            }
            else if (char.ToLower(key) == '3')
            {
                Console.WriteLine("\nВведите ID сотрудника для отображения данных:");
                int id = int.Parse(InputStringCheck());
                workerRepository.GetWorkerById(id);
                RepeatOperationOrNot();
            }
            else if (char.ToLower(key) == '4')
            {
                Console.WriteLine("\nВведите ID сотрудника для удаления данных: ");
                int id = int.Parse(InputStringCheck());
                workerRepository.DeleteWorker(id);
                Console.WriteLine("\nДанные удалены.\n");
                RepeatOperationOrNot();
            }
            else if (char.ToLower(key) == '5')
            {
                Console.WriteLine("Введите дату от: ");
                DateTime dateFrom = DateTime.Parse(InputStringCheck());
                Console.WriteLine("Введите дату до: ");
                DateTime dateTo = DateTime.Parse(InputStringCheck());
                workerRepository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                RepeatOperationOrNot();
            }
            else
            {
                Console.WriteLine("\nНекоректный ввод, попробуйте ещё раз:");
                // TODO так не очень хорошо, чтобы метод сам себя вызывал
                // (есть только один допустимый вариант - рекурсия, но это отдельно изучается)
                // каждый вызов помещает блок программы в стек и этот стек может переполниться
                // переделай на бесконечный цикл
                ChooseOperation();
            }
        }

        // TODO этот медод должен возвращать bool = true, если нужно продолжить
        // а остальное, должен сделать вызывающий метод
        // TODO у тебя этот вызов в каждом блоке if
        // подумай, как сделать его общим для всех
        public void RepeatOperationOrNot()
        {
            Console.WriteLine("Введите [1] для новой операции, \nДля выхода из программы нажмите любую клавишу:\n");
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
    }
}
