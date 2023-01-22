namespace Lesson7;

public struct Worker
{
    /// <summary>
    /// Порядковый номер записи
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string Fio { get; set; }

    /// <summary>
    /// Возраст сотрудника
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Рост сотрудника
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Дата рождения сотрудника
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Место рождения сотрудника
    /// </summary>
    public string BirthPlace { get; set; }

    public Worker(int id, string fio, int age, int height, DateTime birthDate, string birthPlace)
    {
        this.Id = id;
        this.CreationDate = DateTime.Now;
        this.Fio = fio;
        this.Age = age;
        this.Height = height;
        this.BirthDate = birthDate;
        this.BirthPlace = birthPlace;
    }
}
