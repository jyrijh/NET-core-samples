namespace Database.Application;

public class App
{
    private readonly ISampleRepository _repository;

    public App(ISampleRepository repository)
    {
        _repository = repository;
    }

    public void Run()
    {
        _repository.AddStudent(new Model.Student() { FirstMidName = "John", LastName = "Doe", EnrollmentDate = DateTime.Now });
        _repository.AddStudent(new Model.Student() { FirstMidName = "Mary", LastName = "Smith", EnrollmentDate = DateTime.Now });

        var students = _repository.GetStudents();

        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}
