using Lesson8._4;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lesson8._1;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\\UserData\Записная книга.xml";
        Worker worker = InputWorker();
        SerializeWorker(worker, filePath);
    }

    static Worker InputWorker()
    {
        Worker newWorker = new Worker();
        Console.WriteLine("\nВведите Ф.И.О. сотрудника: ");
        newWorker.Fio = InputStringCheck();
        Console.WriteLine("\nВведите название улицы:");
        newWorker.Street= InputStringCheck();
        Console.WriteLine("\nВведите номер дома:");
        // TODO вообще номер дома не обязательно число
        // но если хочешь число, то это нужно проверить при вводе
        newWorker.HouseNumber = int.Parse(InputStringCheck());
        Console.WriteLine("\nВведите номер квартиры:");
        newWorker.FlatNumber = int.Parse(InputStringCheck());
        Console.WriteLine("\nВведите мобильный телефон:");
        newWorker.MobilePhone = InputStringCheck();
        Console.WriteLine("\nВведите домашний телефон:");
        newWorker.FlatPhone = InputStringCheck();
        return newWorker;
    }

    static void SerializeWorker(Worker newWorker, string Path)
    {
        // TODO как это используется?
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Worker));

        // TODO а без этого не будет работать?
        // но если действительно нужно созавать файл, то это нужно
        // делать перед записью
        Stream stream = new FileStream(Path, FileMode.Create, FileAccess.Write);
        stream.Close();

        // TODO ты сначала создаешь, а потом в обратном порядке заполняешь
        // можно сразу создавать заполняя
        XElement person = new XElement("Person");
        XAttribute xAttributePersonName = new XAttribute("name", $"{newWorker.Fio}");

        XElement address = new XElement("Address");
        XElement phones = new XElement("Phones");

        XElement street = new XElement("Street");
        XElement houseNumber = new XElement("HouseNumber");
        XElement flatNumber = new XElement("FlatNumber");
        XElement mobilePhone = new XElement("MobilePhone");
        XElement flatPhone = new XElement("FlatPhone");

        // TODO у XElement есть конструктор, который принимает одновременно
        // и имя и значение, не нужно отдельно
        street.Add($"{newWorker.Street}");
        houseNumber.Add($"{newWorker.HouseNumber}");
        flatNumber.Add($"{newWorker.FlatNumber}");
        mobilePhone.Add($"{newWorker.MobilePhone}");
        flatPhone.Add($"{newWorker.FlatPhone}");

        address.Add(street, houseNumber, flatNumber);
        phones.Add(mobilePhone, flatPhone);

        person.Add(xAttributePersonName, address, phones);

        person.Save(Path);
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