using Database.Application.Model;

namespace Database.Application;

public interface ISampleRepository
{
    IReadOnlyCollection<Student> GetStudents();

    Student AddStudent(Student student);
}