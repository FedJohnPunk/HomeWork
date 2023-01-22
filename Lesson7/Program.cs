namespace Lesson7;

internal partial class Program
{
    static void Main()
    {
        WorkerRepository rep = new WorkerRepository();

        rep.PrintWorkerById(3);

        //rep.AddWorker(new Worker(1, "John", 21, 184, new DateTime(11, 04, 2000), "Krasnodar"));

        //rep.AddWorker(new Worker
        //{
        //    Id = 1,
        //    Fio = "John",
        //    Age = 21,
        //    Height = 184,
        //    BirthDate = new DateTime(11, 04, 2000),
        //    BirthPlace = "Krasnodar"
        //});
        }
    }