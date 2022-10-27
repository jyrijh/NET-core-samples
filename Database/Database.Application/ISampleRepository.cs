using Database.Application.Model;

namespace Database.Application;

public interface ISampleRepository
{
    IReadOnlyCollection<Student> GetStudents();

    Student AddSudent(Student student);
}