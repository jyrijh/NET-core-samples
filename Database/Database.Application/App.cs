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
        _repository.AddSudent(new Model.Student() { FirstMidName = "john", LastName = "doe", EnrollmentDate = DateTime.Now });

        var students = _repository.GetStudents();
    }
}
