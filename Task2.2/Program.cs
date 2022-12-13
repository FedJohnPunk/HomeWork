// TODO Еще раз можно почистить using: в .NET7 используется специальный механизм
// в котором общие using скрываются из отдельных файлов
using System;

// TODO снова блочный неймспейс - нужно убрать кавычки
namespace Task2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Программа подсчёта суммы карт в игре «21»

            // Программа приветствует пользователя и спрашивает, сколько у него на руках карт.
            Console.WriteLine("Здравствуйте, укажите количество карт у вас в руках:");
            // Введённое число преобразуем в счётчик для цикла.
            int cardsAmount = int.Parse(Console.ReadLine());
            // Задаем переменную "Веса" всех карт.
            int sum = 0;
            // Просим пользователя ввести по очереди номинал каждой карты.
            Console.WriteLine("По очереди введите номинал каждой карты.(Возможные номиналы: 5, 6, 7, 8, 9, J, Q, K, T.)");
            Console.WriteLine();
            // С помощью цикла for получаем вес каждой карты и добавляем его в переменную sum.
            for (int counter = 0; counter < cardsAmount; counter++)
            {
                Console.WriteLine($"Введите номинал {counter + 1}-й карты, и нажмите Enter:");
                var cardValue = Console.ReadLine();

                // TODO Не нужно сотавлять старый закомментаированный код
                // всегда можно в Fork посмотреть историю

                #region Способ if-else
                // TODO В задании "Внутри цикла, используя оператор switch"
                // bool cardCheck;
                //if (cardValue == "J" || cardValue == "Q" || cardValue == "K" || cardValue == "T")
                //{
                //    cardCheck = true;
                //}
                //else
                //{
                //    cardCheck = false;
                //}
                //if (cardCheck == true)
                //{
                //    sum += 10;
                //}
                //else if (cardCheck == false)
                //{
                //    sum += int.Parse(cardValue);
                //}
                #endregion

                switch (cardValue)
                {
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        sum += int.Parse(cardValue);
                        break;
                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        // TODO Здесь получается, что все старшие карты имеют один вес,
                        // разве не должны быть разные?
                        sum += 10;
                        break;
                    default:
                        Console.WriteLine("Неправильный номинал карты.");
                        break;
                }

            }
            Console.WriteLine($"Итоговая сумма карт: {sum}");
            Console.WriteLine("Нажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}
